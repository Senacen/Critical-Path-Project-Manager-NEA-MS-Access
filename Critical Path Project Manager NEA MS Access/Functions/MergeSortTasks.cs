using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Critical_Path_Project_Manager_NEA_MS_Access.Functions
{
    static internal class MergeSortTasks
    {
        // Note: the entire tasks CustomDictionary is passed as an argument, which contains a lot of irelevant data for this merge sort
        // such as numWorkers, predecessor and successor lists.
        // However, this is not an issue for efficiency, as objects are passed by reference not by value.
        public static List<string> sort(List<string> tasksToBeSorted, CustomDictionary<string, TaskNode> tasks) {

            // Base case when list only contains 1 or 0 elements
            if (tasksToBeSorted.Count <= 1) return tasksToBeSorted;

            // Divide the list into 2 halves
            int middle = tasksToBeSorted.Count / 2;
            List<string> left = tasksToBeSorted.GetRange(0, middle);
            List<string> right = tasksToBeSorted.GetRange(middle, tasksToBeSorted.Count - middle);

            // Recursively sort each half
            left = sort(left, tasks);
            right = sort(right, tasks);

            // Merge the sorted halves 
            return mergeHalves(left, right, tasks);

        }

        private static List<string> mergeHalves(List<string> left, List<string> right, CustomDictionary<string, TaskNode> tasks)
        {
            List<string> mergedResult = new List<string>();

            // Initialise pointers to the start of each list
            int leftIndex = 0, rightIndex = 0;

            // Compare the Earliest Start Time of each task at the pointer of each list, and add it to the mergedResult list if it is the earlier one
            // Until one list has been fully added
            while(leftIndex < left.Count && rightIndex < right.Count) {
                if (tasks.getValue(left[leftIndex]).getEarliestStartTime() < tasks.getValue(right[rightIndex]).getEarliestStartTime())
                {
                    mergedResult.Add(left[leftIndex]);
                    leftIndex++;
                } 
                else
                {
                    mergedResult.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            // Add the remaining tasks to the mergedResult
            while (leftIndex < left.Count)
            {
                mergedResult.Add(left[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < right.Count)
            {
                mergedResult.Add(right[rightIndex]);
                rightIndex++;
            }

            return mergedResult;
        }
    }
}
