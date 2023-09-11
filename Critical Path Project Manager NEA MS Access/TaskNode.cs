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
        public string name;
        public int duration;
        public int numWorkers;
        public List<string> predecessorNames;
        public List<string> successorNames;

        // Calculated through forward and backward BFS passes
        public int earliestStartTime;
        public int latestStartTime;
        public int earliestFinishTime;
        public int latestFinishTime;
        public int totalFloat;
        public int independentFloat;
        public int interferingFloat;

        // Used in the forward and backward BFS passes to mark which TaskNodes are already processed
        public bool processed;

        public TaskNode(string name, int duration, int numWorkers, List<string> predecessorNames, List<string> successorNames)
        {
            this.name = name;
            this.duration = duration;
            this.numWorkers = numWorkers;
            this.predecessorNames = predecessorNames;
            this.successorNames = successorNames;
        }
    }
}
