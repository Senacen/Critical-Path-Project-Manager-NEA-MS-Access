using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access
{
    static internal class djb2HashFunction
    {
        public static int djb2(string password)
        {
            int hash = 5381;
            foreach (char c in password)
            {
                hash = ((hash << 5) + hash) + (int)c;
            }
            return hash;
        }
    }
}
