using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    internal class TaskNode
    {
        // Retrieved from database
        private string name;
        private int duration;
        private int numWorkers;
        public List<string> predecessorNames;
        public List<string> successorNames;

        // Calculated through forward and backward BFS passes
        private int earliestStartTime;
        private int latestStartTime;
        private int earliestFinishTime;
        private int latestFinishTime;
        private int totalFloat;
        private int independentFloat;
        private int interferingFloat;

        // Used in the forward and backward BFS passes to mark which TaskNodes are already processed
        private bool processed;

        public TaskNode(string name, int duration, int numWorkers, List<string> predecessorNames, List<string> successorNames)
        {
            this.name = name;
            this.duration = duration;
            this.numWorkers = numWorkers;
            this.predecessorNames = predecessorNames;
            this.successorNames = successorNames;
        }

        // Getters for attributes retrieved from the database
        public string getName()
        {
            return name;
        }
        public int getDuration()
        {
            return duration;
        }
        public int getNumWorkers()
        {
            return numWorkers;
        }
        public List<string> getPredecessorNames()
        {
            return predecessorNames;
        }
        public List<string> getSuccessorNames()
        {
            return successorNames;
        }

        // Getters and setters for calculated attributes
        public int getEarliestStartTime()
        {
            return earliestStartTime;
        }
        public void setEarliestStartTime(int value)
        {
            earliestStartTime = value;
        }
        public int getLatestStartTime()
        {
            return latestStartTime;
        }
        public void setLatestStartTime(int value)
        {
            latestStartTime = value;
        }
        public int getEarliestFinishTime()
        {
            return earliestFinishTime;
        }
        public void setEarliestFinishTime(int value)
        {
            earliestFinishTime = value;
        }
        public int getLatestFinishTime()
        {
            return latestFinishTime;
        }
        public void setLatestFinishTime(int value)
        {
            latestFinishTime = value;
        }
        public int getTotalFloat()
        {
            return totalFloat;
        }
        public void setTotalFloat(int value)
        {
            totalFloat = value;
        }
        public int getIndependentFloat()
        {
            return independentFloat;
        }
        public void setIndependentFloat(int value)
        {
            independentFloat = value;
        }
        public int getInterferingFloat()
        {
            return interferingFloat;
        }
        public void setInterferingFloat(int value)
        {
            interferingFloat = value;
        }
        public bool getProcessed()
        {
            return processed;
        }
        public void setProcessed(bool value)
        {
            processed = value;
        }
    }
}
