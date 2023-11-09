using Critical_Path_Project_Manager_NEA_MS_Access.Functions;
using Critical_Path_Project_Manager_NEA_MS_Access.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    internal class TaskGraph
    {
        private Dictionary<string, TaskNode> tasks;
        private List<string> criticalTasks = new List<string>();
        private List<string> criticalPath = new List<string>();

        public TaskGraph(string projectName)
        {
            // Retrieve tasks from database
            tasks = DatabaseFunctions.tasksDict(projectName);
            initStartEnd();
            forwardPass();
            backwardPass();
            calculateFloats();
            criticalPath = sortCriticalTasks();
            List<string>criticalPathTest = criticalTasks.OrderBy(name => tasks[name].getEarliestStartTime()).ToList();
            string cptest = "";
            foreach (string task in criticalPathTest)
            {
                cptest += task;
            }
            MessageBox.Show(cptest);
            //outputCPA();
        }

        // For checking tasks 
        public void outputCPA()
        {
            string criticalPathString = "";
            foreach (string name in criticalPath)
            {
                criticalPathString += " | " + name;
            }
            MessageBox.Show(criticalPathString);
            foreach (TaskNode node in tasks.Values)
            {
                string predecessors = "", successors = "";
                foreach (string predecessor in node.getPredecessorNames())
                {
                    predecessors += predecessor + " | ";
                }
                foreach (string successor in node.getSuccessorNames())
                {
                    successors += successor + " | ";
                }
                MessageBox.Show($"Name: {node.getName()} \n Duration: {node.getDuration()} \n NumWorkers: {node.getNumWorkers()} \n Earliest Start Time: {node.getEarliestStartTime()} " +
                    $" \n Earliest Finish Time: {node.getEarliestFinishTime()} \n Latest Start Time: {node.getLatestStartTime()} \n Latest Finish Time: {node.getLatestFinishTime()} " +
                    $"\n Total Float: {node.getTotalFloat()} \n Independent Float: {node.getIndependentFloat()} \n Interfering Float: {node.getInterferingFloat()} \n PredecessorNames: {predecessors} \n SuccessorNames: {successors}");
            }
        }

        private void initStartEnd()
        {
            // Create start TaskNode and end TaskNode
            tasks["Start"] = new TaskNode("Start", 0, 0, new List<string>(), new List<string>());
            tasks["End"] = new TaskNode("End", 0, 0, new List<string>(), new List<string>());

            // Connect them
            foreach (string name in tasks.Keys)
            {
                if (name == "Start" || name == "End")
                {
                    continue;
                }
                // Passes by reference
                TaskNode currTaskNode = tasks[name];

                // Connect tasks that do not have a predecessor to start 
                if (currTaskNode.getPredecessorNames().Count == 0)
                {
                    currTaskNode.getPredecessorNames().Add("Start");
                    tasks["Start"].getSuccessorNames().Add(currTaskNode.getName());
                }

                // Connect tasks that do not have a successor to end
                if (currTaskNode.getSuccessorNames().Count == 0)
                {
                    currTaskNode.getSuccessorNames().Add("End");
                    tasks["End"].getPredecessorNames().Add(currTaskNode.getName());
                }
            }
        }

        private void setAllProcessedFalse()
        {
            foreach (string name in tasks.Keys)
            {
                TaskNode currTaskNode = tasks[name];
                currTaskNode.setProcessed(false);
            }
        }

        private void forwardPass()
        {
            setAllProcessedFalse();
            // Initialise Start TaskNode
            tasks["Start"].setEarliestStartTime(0);
            tasks["Start"].setEarliestFinishTime(0);
            tasks["Start"].setProcessed(true);

            // BFSQueue only stores the names of each TaskNode, to save space
            LinkedListQueue<string> BFSQueue = new LinkedListQueue<string>();

            // Enqueue all tasks that are successors of Start
            foreach (string name in tasks["Start"].getSuccessorNames())
            {
                BFSQueue.enqueue(name);
            }

            // Perform BFS forward pass
            while (!BFSQueue.isEmpty())
            {
                TaskNode currTaskNode = tasks[BFSQueue.dequeue()];
                int maxPredecessorEarliestFinishTime = 0;
                foreach (string predecessorName in currTaskNode.getPredecessorNames())
                {
                    maxPredecessorEarliestFinishTime = Math.Max(maxPredecessorEarliestFinishTime, tasks[predecessorName].getEarliestFinishTime());
                }
                currTaskNode.setEarliestStartTime(maxPredecessorEarliestFinishTime);
                currTaskNode.setEarliestFinishTime(currTaskNode.getEarliestStartTime() + currTaskNode.getDuration());
                currTaskNode.setProcessed(true);

                // Check every successor if its predecessors have been processed, to then enqueue
                // Need to make logic more efficient, possible using predecessorProcessedCount
                foreach (string successorName in currTaskNode.getSuccessorNames())
                {
                    TaskNode successorTaskNode = tasks[successorName];
                    bool predecessorsAllProcessed = true;
                    foreach (string predecessorName in successorTaskNode.getPredecessorNames())
                    {
                        if (!tasks[predecessorName].getProcessed())
                        {
                            predecessorsAllProcessed = false;
                            break;
                        }
                    }
                    if (predecessorsAllProcessed)
                    {
                        BFSQueue.enqueue(successorTaskNode.getName());
                    }
                }
            }
        }

        private void backwardPass()
        {
            setAllProcessedFalse();
            // Initialise End TaskNode
            tasks["End"].setLatestFinishTime(tasks["End"].getEarliestFinishTime());
            tasks["End"].setLatestStartTime(tasks["End"].getLatestFinishTime());
            tasks["End"].setProcessed(true);

            // BFSQueue only stores the names of each TaskNode, to save space
            LinkedListQueue<string> BFSQueue = new LinkedListQueue<string>();

            // Enqueue all tasks that are successors of Start
            foreach (string name in tasks["End"].getPredecessorNames())
            {
                BFSQueue.enqueue(name);
            }

            // Perform BFS backward pass
            while (!BFSQueue.isEmpty())
            {
                TaskNode currTaskNode = tasks[BFSQueue.dequeue()];
                int minSuccessorLatestStartTime = int.MaxValue;
                foreach (string successorName in currTaskNode.getSuccessorNames())
                {
                    minSuccessorLatestStartTime = Math.Min(minSuccessorLatestStartTime, tasks[successorName].getLatestStartTime());
                }
                currTaskNode.setLatestFinishTime(minSuccessorLatestStartTime);
                currTaskNode.setLatestStartTime(currTaskNode.getLatestFinishTime() - currTaskNode.getDuration());
                currTaskNode.setProcessed(true);

                // Check every successor if its predecessors have been processed, to then enqueue
                // Need to make logic more efficient, possible using predecessorProcessedCount
                foreach (string predecessorName in currTaskNode.getPredecessorNames())
                {
                    TaskNode predecessorTaskNode = tasks[predecessorName];
                    bool successorsAllProcessed = true;
                    foreach (string successorName in predecessorTaskNode.getSuccessorNames())
                    {
                        if (!tasks[successorName].getProcessed())
                        {
                            successorsAllProcessed = false;
                            break;
                        }
                    }
                    if (successorsAllProcessed)
                    {
                        BFSQueue.enqueue(predecessorTaskNode.getName());
                    }
                }
            }
        }

        // Issue - floats are all wrong. Check TLMaths cpa 13 calculating floats example
        private void calculateFloats()
        {
            foreach (string name in tasks.Keys)
            {
                if (name == "Start" || name == "End")
                {
                    continue;
                }
                TaskNode currTaskNode = tasks[name];
                // How much the task can be delayed by without delaying the end of the project
                currTaskNode.setTotalFloat(currTaskNode.getLatestFinishTime() - currTaskNode.getEarliestFinishTime()); // or currTaskNode.getLatestFinishTime() - currTaskNode.getEarliestStartTime() - currTaskNode.getDuration()
                int minSuccessorEarliestStartTime = int.MaxValue;
                foreach (string successorName in currTaskNode.getSuccessorNames())
                {
                    minSuccessorEarliestStartTime = Math.Min(minSuccessorEarliestStartTime, tasks[successorName].getEarliestStartTime());
                }
                // How much the task can be moved around without causing another task to move 
                currTaskNode.setIndependentFloat(minSuccessorEarliestStartTime - currTaskNode.getEarliestFinishTime());
                // 
                if (currTaskNode.getIndependentFloat() < 0) currTaskNode.setIndependentFloat(0);
                // How much the task can be moved with it causing another task to move
                currTaskNode.setInterferingFloat(currTaskNode.getTotalFloat() - currTaskNode.getIndependentFloat());

                if (currTaskNode.getTotalFloat() == 0)
                {
                    criticalTasks.Add(currTaskNode.getName());
                }
            }
        }

        private List<string> sortCriticalTasks()
        {
            return MergeSortTasks.sort(criticalTasks, tasks);
        }

        public int getTotalDuration()
        {
            return tasks["End"].getEarliestFinishTime();
        }

        public List<string> getCriticalPath()
        {
            return criticalPath;
        }

        public Dictionary<string, TaskNode> getTasks()
        {
            return tasks;
        }
    }
}

