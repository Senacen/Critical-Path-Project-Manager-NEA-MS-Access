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
        private CustomDictionary<string, TaskNode> tasks;
        private List<string> criticalTasks = new List<string>();
        private List<string> criticalPath = new List<string>();

        public TaskGraph(string projectName)
        {
            // Retrieve tasks from database
            tasks = DatabaseFunctions.tasksDict(projectName);

            // Initialise the task graph to add a dummy start and end node
            initStartEnd();

            // Perform the forward and backward pass
            forwardPass();
            backwardPass();

            // Floats can be calculated from each task's CPA results
            calculateFloats();

            // Sorting the critical tasks by their earliest start time gives the order they must be completed in, which is the critical path
            criticalPath = sortCriticalTasks();
        }

        private void initStartEnd()
        {
            // Create start TaskNode and end TaskNode
            tasks.add("Start", new TaskNode("Start", 0, 0, false, new List<string>(), new List<string>()));
            tasks.add("End", new TaskNode("End", 0, 0, false, new List<string>(), new List<string>()));

            // Connect them
            foreach (string name in tasks.keys)
            {
                if (name == "Start" || name == "End")
                {
                    continue;
                }
                // Passes by reference
                TaskNode currTaskNode = tasks.getValue(name);

                // Connect tasks that do not have a predecessor to start 
                if (currTaskNode.getPredecessorNames().Count == 0)
                {
                    currTaskNode.getPredecessorNames().Add("Start");
                    tasks.getValue("Start").getSuccessorNames().Add(currTaskNode.getName());
                }

                // Connect tasks that do not have a successor to end
                if (currTaskNode.getSuccessorNames().Count == 0)
                {
                    currTaskNode.getSuccessorNames().Add("End");
                    tasks.getValue("End").getPredecessorNames().Add(currTaskNode.getName());
                }
            }
        }

        // Used to initialise all tasks back to unprocessed before each pass
        private void setAllProcessedFalse()
        {
            foreach (string name in tasks.keys)
            {
                TaskNode currTaskNode = tasks.getValue(name);
                currTaskNode.setProcessed(false);
            }
        }

        private void forwardPass()
        {

            setAllProcessedFalse();

            // Initialise Start TaskNode
            tasks.getValue("Start").setEarliestStartTime(0);
            tasks.getValue("Start").setEarliestFinishTime(0);
            tasks.getValue("Start").setProcessed(true);

            // BFSQueue only stores the names of each TaskNode, to save space
            LinkedListQueue<string> BFSQueue = new LinkedListQueue<string>();

            // Enqueue all tasks that are successors of Start to initialise the queue
            foreach (string name in tasks.getValue("Start").getSuccessorNames())
            {
                BFSQueue.enqueue(name);
            }

            // Perform BFS forward pass
            while (!BFSQueue.isEmpty())
            {
                TaskNode currTaskNode = tasks.getValue(BFSQueue.dequeue());

                // Calculate the maximum of all the predecessors' earliest finish times, as this will be the current TaskNode's earliest start time
                int maxPredecessorEarliestFinishTime = 0;
                foreach (string predecessorName in currTaskNode.getPredecessorNames())
                {
                    maxPredecessorEarliestFinishTime = Math.Max(maxPredecessorEarliestFinishTime, tasks.getValue(predecessorName).getEarliestFinishTime());
                }
                currTaskNode.setEarliestStartTime(maxPredecessorEarliestFinishTime);

                // Earliest finish time of a task is just earlist start time + duration
                currTaskNode.setEarliestFinishTime(currTaskNode.getEarliestStartTime() + currTaskNode.getDuration());

                // Mark that the node has been processed
                currTaskNode.setProcessed(true);

                // Check every successor if all its predecessors have been processed, to then enqueue
                foreach (string successorName in currTaskNode.getSuccessorNames())
                {
                    TaskNode successorTaskNode = tasks.getValue(successorName);
                    bool predecessorsAllProcessed = true;
                    foreach (string predecessorName in successorTaskNode.getPredecessorNames())
                    {
                        if (!tasks.getValue(predecessorName).getProcessed())
                        {
                            // If any predecessor has not been processed yet, set predecessorsAllProcessed to false and break
                            predecessorsAllProcessed = false;
                            break;
                        }
                    }

                    // If no predecessors were found that have not yet been processed
                    if (predecessorsAllProcessed)
                    {
                        // Add the current succesor to the queue to be processed
                        BFSQueue.enqueue(successorTaskNode.getName());
                    }
                }
            }
        }

        private void backwardPass()
        {
            setAllProcessedFalse();
            // Initialise End TaskNode
            tasks.getValue("End").setLatestFinishTime(tasks.getValue("End").getEarliestFinishTime());
            tasks.getValue("End").setLatestStartTime(tasks.getValue("End").getLatestFinishTime());
            tasks.getValue("End").setProcessed(true);

            // BFSQueue only stores the names of each TaskNode, to save space
            LinkedListQueue<string> BFSQueue = new LinkedListQueue<string>();

            // Enqueue all tasks that are predecessors of End to initialise the queue
            foreach (string name in tasks.getValue("End").getPredecessorNames())
            {
                BFSQueue.enqueue(name);
            }

            // Perform BFS backward pass
            while (!BFSQueue.isEmpty())
            {
                TaskNode currTaskNode = tasks.getValue(BFSQueue.dequeue());

                // Calculate the minimum of all the successors' latest start times, as this will be the current TaskNode's latest finish time
                int minSuccessorLatestStartTime = int.MaxValue;
                foreach (string successorName in currTaskNode.getSuccessorNames())
                {
                    minSuccessorLatestStartTime = Math.Min(minSuccessorLatestStartTime, tasks.getValue(successorName).getLatestStartTime());
                }
                currTaskNode.setLatestFinishTime(minSuccessorLatestStartTime);

                // Latest start time of a task is just latest finish time - duration
                currTaskNode.setLatestStartTime(currTaskNode.getLatestFinishTime() - currTaskNode.getDuration());

                // Mark that the node has been processed
                currTaskNode.setProcessed(true);

                // Check every predecessor if all its successors have been processed, to then enqueue
                foreach (string predecessorName in currTaskNode.getPredecessorNames())
                {
                    TaskNode predecessorTaskNode = tasks.getValue(predecessorName);
                    bool successorsAllProcessed = true;
                    foreach (string successorName in predecessorTaskNode.getSuccessorNames())
                    {
                        if (!tasks.getValue(successorName).getProcessed())
                        {
                            // If any successor has not been processed yet, set successorsAllProcessed to false and break
                            successorsAllProcessed = false;
                            break;
                        }
                    }

                    // If no successers were found that have not yet been processed
                    if (successorsAllProcessed)
                    {
                        // Add the current predecessor to the queue to be processed
                        BFSQueue.enqueue(predecessorTaskNode.getName());
                    }
                }
            }
        }

        // Issue - floats are all wrong. Check TLMaths cpa 13 calculating floats example
        private void calculateFloats()
        {
            foreach (string name in tasks.keys)
            {
                if (name == "Start" || name == "End")
                {
                    continue;
                }
                TaskNode currTaskNode = tasks.getValue(name);
                // How much the task can be delayed by without delaying the end of the project
                currTaskNode.setTotalFloat(currTaskNode.getLatestFinishTime() - currTaskNode.getEarliestFinishTime()); // or currTaskNode.getLatestFinishTime() - currTaskNode.getEarliestStartTime() - currTaskNode.getDuration()
                int minSuccessorEarliestStartTime = int.MaxValue;
                foreach (string successorName in currTaskNode.getSuccessorNames())
                {
                    minSuccessorEarliestStartTime = Math.Min(minSuccessorEarliestStartTime, tasks.getValue(successorName).getEarliestStartTime());
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
            // Minimum possible duration of the project is the End node's EarliestFinishTime
            return tasks.getValue("End").getEarliestFinishTime();
        }

        public List<string> getCriticalPath()
        {
            return criticalPath;
        }

        public CustomDictionary<string, TaskNode> getTasks()
        {
            return tasks;
        }
    }
}

