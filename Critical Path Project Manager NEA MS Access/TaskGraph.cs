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
        private List<string> criticalPath;

        public TaskGraph(string projectName)
        {
            // Retrieve tasks from database
            tasks = DatabaseFunctions.tasksDict(projectName);
            // Create start TaskNode and end TaskNode
            tasks["Start"] = new TaskNode("Start", 0, 0, new List<string>(), new List<string>());
            tasks["End"] = new TaskNode("End", 0, 0, new List<string>(), new List<string>());
            initStartEnd();
            forwardPass();
            backwardPass();
            calculateFloats();
            criticalPath = criticalTasks.OrderBy(name => tasks[name].earliestStartTime).ToList();
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
                foreach (string predecessor in node.predecessorNames)
                {
                    predecessors += predecessor + " | ";
                }
                foreach (string successor in node.successorNames)
                {
                    successors += successor + " | ";
                }
                MessageBox.Show($"Name: {node.name} \n Duration: {node.duration} \n NumWorkers: {node.numWorkers} \n Earliest Start Time: {node.earliestStartTime} " +
                    $" \n Earliest Finish Time: {node.earliestFinishTime} \n Latest Start Time: {node.latestStartTime} \n Latest Finish Time: {node.latestFinishTime} " +
                    $"\n Total Float: {node.totalFloat} \n Independent Float: {node.independentFloat} \n Interfering Float: {node.interferingFloat} \n PredecessorNames: {predecessors} \n SuccessorNames: {successors}");
            }

        }

        public void initStartEnd()
        {
            foreach (string name in tasks.Keys)
            {
                if (name == "Start" || name == "End")
                {
                    continue;
                }
                // Passes by reference
                TaskNode currTaskNode = tasks[name];

                // Connect tasks that do not have a predecessor to start 
                if (currTaskNode.predecessorNames.Count == 0)
                {
                    currTaskNode.predecessorNames.Add("Start");
                    tasks["Start"].successorNames.Add(currTaskNode.name);
                }

                // Connect tasks that do not have a successor to end
                if (currTaskNode.successorNames.Count == 0)
                {
                    currTaskNode.successorNames.Add("End");
                    tasks["End"].predecessorNames.Add(currTaskNode.name);
                }
            }
        }

        public void setAllProcessedFalse()
        {
            foreach (string name in tasks.Keys)
            {
                TaskNode currTaskNode = tasks[name];
                currTaskNode.processed = false;
            }
        }

        public void forwardPass()
        {
            setAllProcessedFalse();
            // Initialise Start TaskNode
            tasks["Start"].earliestStartTime = 0;
            tasks["Start"].earliestFinishTime = 0;
            tasks["Start"].processed = true;

            // BFSQueue only stores the names of each TaskNode, to save space
            Queue<string> BFSQueue = new Queue<string>();

            // Enqueue all tasks that are successors of Start
            foreach (string name in tasks["Start"].successorNames)
            {
                BFSQueue.Enqueue(name);
            }

            // Perform BFS forward pass
            while (BFSQueue.Count > 0)
            {
                TaskNode currTaskNode = tasks[BFSQueue.Dequeue()];
                int maxPredecessorEarliestFinishTime = 0;
                foreach (string predecessorName in currTaskNode.predecessorNames)
                {
                    maxPredecessorEarliestFinishTime = Math.Max(maxPredecessorEarliestFinishTime, tasks[predecessorName].earliestFinishTime);
                }
                currTaskNode.earliestStartTime = maxPredecessorEarliestFinishTime;
                currTaskNode.earliestFinishTime = currTaskNode.earliestStartTime + currTaskNode.duration;
                currTaskNode.processed = true;

                // Check every successor if its predecessors have been processed, to then enqueue
                // Need to make logic more efficient, possible using predecessorProcessedCount
                foreach (string successorName in currTaskNode.successorNames)
                {
                    TaskNode successorTaskNode = tasks[successorName];
                    bool predecessorsAllProcessed = true;
                    foreach (string predecessorName in successorTaskNode.predecessorNames)
                    {
                        if (tasks[predecessorName].processed == false)
                        {
                            predecessorsAllProcessed = false;
                            break;
                        }
                    }
                    if (predecessorsAllProcessed)
                    {
                        BFSQueue.Enqueue(successorTaskNode.name);
                    }
                }

            }

        }

        public void backwardPass()
        {
            setAllProcessedFalse();
            // Initialise End TaskNode
            tasks["End"].latestFinishTime = tasks["End"].earliestFinishTime;
            tasks["End"].latestStartTime = tasks["End"].latestFinishTime;
            tasks["End"].processed = true;

            // BFSQueue only stores the names of each TaskNode, to save space
            Queue<string> BFSQueue = new Queue<string>();

            // Enqueue all tasks that are successors of Start
            foreach (string name in tasks["End"].predecessorNames)
            {
                BFSQueue.Enqueue(name);
            }

            // Perform BFS backward pass
            while (BFSQueue.Count > 0)
            {
                TaskNode currTaskNode = tasks[BFSQueue.Dequeue()];
                int minSuccessorLatestStartTime = int.MaxValue;
                foreach (string successorName in currTaskNode.successorNames)
                {
                    minSuccessorLatestStartTime = Math.Min(minSuccessorLatestStartTime, tasks[successorName].latestStartTime);
                }
                currTaskNode.latestFinishTime = minSuccessorLatestStartTime;
                currTaskNode.latestStartTime = currTaskNode.latestFinishTime - currTaskNode.duration;
                currTaskNode.processed = true;

                // Check every successor if its predecessors have been processed, to then enqueue
                // Need to make logic more efficient, possible using predecessorProcessedCount
                foreach (string predecessorName in currTaskNode.predecessorNames)
                {
                    TaskNode predecessorTaskNode = tasks[predecessorName];
                    bool successorsAllProcessed = true;
                    foreach (string successorName in predecessorTaskNode.successorNames)
                    {
                        if (tasks[successorName].processed == false)
                        {
                            successorsAllProcessed = false;
                            break;
                        }
                    }
                    if (successorsAllProcessed)
                    {
                        BFSQueue.Enqueue(predecessorTaskNode.name);
                    }
                }

            }
        }

        // Issue - floats are all wrong. Check TLMaths cpa 13 calculating floats example
        public void calculateFloats()
        {
            foreach (string name in tasks.Keys)
            {
                if (name == "Start" || name == "End")
                {
                    continue;
                }
                TaskNode currTaskNode = tasks[name];
                // How much the task can be delayed by without delaying the end of the project
                currTaskNode.totalFloat = currTaskNode.latestFinishTime - currTaskNode.earliestFinishTime; // or currTaskNode.latestFinishTime - currTaskNode.earliestStartTime - currTaskNode.duration
                int minSuccessorEarliestStartTime = int.MaxValue;
                foreach (string successorName in currTaskNode.successorNames)
                {
                    minSuccessorEarliestStartTime = Math.Min(minSuccessorEarliestStartTime, tasks[successorName].earliestStartTime);
                }
                // How much the task can be moved around without causing another task to move 
                currTaskNode.independentFloat = minSuccessorEarliestStartTime - currTaskNode.earliestFinishTime;
                // 
                if (currTaskNode.independentFloat < 0) currTaskNode.independentFloat = 0;
                // How much the task can be moved with it causing another task to move
                currTaskNode.interferingFloat = currTaskNode.totalFloat - currTaskNode.independentFloat;

                if (currTaskNode.totalFloat == 0)
                {
                    criticalTasks.Add(currTaskNode.name);
                }
            }
        }

        public int getTotalDuration()
        {
            return tasks["End"].earliestFinishTime;
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
