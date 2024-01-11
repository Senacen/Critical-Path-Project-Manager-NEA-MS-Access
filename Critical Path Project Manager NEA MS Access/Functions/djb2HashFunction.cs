using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    static internal class djb2HashFunction
    {
        public static int djb2(string input)
        {
            // Starting hash value
            int hash = 5381;

            // For each character in the input
            foreach (char c in input)
            {
                // Multiply the hash value by 33 and add the int representation of the character 
                // Using bitwise operations as it is faster
                hash = ((hash << 5) + hash) + (int)c;
            }
            return hash;
        }
    }
}
