using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access.Functions
{
    static internal class StringEncryptionFunction
    {
        public static string encrypt(string plaintext)
        {
            string ciphertext = "";
            for (int i = 0; i < plaintext.Length; i++)
            {
                int asciiCode = (int)plaintext[i]; // This is between 32 and 126 (the printable characters)
                asciiCode -= 32; // Shift it to between 0 and 95
                asciiCode += i;
                asciiCode %= 95; // Cycle within 0 to 95
                asciiCode += 32; // Shift back to 32 and 126 (the printable characters)
                ciphertext += (char)asciiCode;
            }
            return ciphertext;
        }

        public static string decrypt(string ciphertext) 
        {
            string plaintext = "";
            for(int i = 0; i < ciphertext.Length; i++)
            {
                int asciiCode = (int)ciphertext[i]; // This is between 32 and 126 (the printable characters)
                asciiCode -= 32;  // Shift it to between 0 and 95
                asciiCode -= i;
                // If -i made it go very negative, add 95 until between 0 and 95 again
                while(asciiCode < 0)
                {
                    asciiCode += 95;
                }
                asciiCode += 32; // Shift back to 32 and 126 (the printable characters)
                plaintext += (char)asciiCode;
            }
            return plaintext;
        }
    }
}
