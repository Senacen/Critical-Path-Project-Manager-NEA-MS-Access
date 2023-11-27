using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critical_Path_Project_Manager_NEA_MS_Access.Functions
{
    static internal class ExportProjectFunctions
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

        public static string addCheckSum(string text)
        {
            int even1odd2 = 0; // Sum of ascii values with even indices weighted by 1 and odd indices weighted by 2
            int even2odd1 = 0; // Sum of ascii values with even indices weighted by 2 and odd indices weighted by 1
            for(int i = 0; i < text.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even1odd2 += (int)text[i];
                    even2odd1 += (int)text[i] * 2;
                }
                else
                {
                    even1odd2 += (int)text[i] * 2;
                    even2odd1 += (int)text[i];
                }
            }
            // Mod and shift to printable range
            even1odd2 %= 95;
            even2odd1 %= 95;
            even1odd2 += 32;
            even2odd1 += 32;
            return (char)even1odd2 + text + (char)even2odd1;
        }

        public static bool checkCheckSum(string textWithCheckSum)
        {
            if (textWithCheckSum.Length <= 2) return false; // There is no content in the text
            int even1odd2 = textWithCheckSum[0];
            int even2odd1 = textWithCheckSum[textWithCheckSum.Length - 1];
            int checkEven1odd2 = 0;
            int checkEven2odd1 = 0;
            string text = textWithCheckSum.Substring(1, textWithCheckSum.Length - 2);
            for (int i = 0; i < text.Length; i++)
            {
                if (i % 2 == 0)
                {
                    checkEven1odd2 += (int)text[i];
                    checkEven2odd1 += (int)text[i] * 2;
                }
                else
                {
                    checkEven1odd2 += (int)text[i] * 2;
                    checkEven2odd1 += (int)text[i];
                }
            }
            // Shift to mod range
            even1odd2 -= 32;
            even2odd1 -= 32;

            // Mod the check counters
            checkEven1odd2 %= 95;
            checkEven2odd1 %= 95;

            return (checkEven1odd2  == even1odd2 && checkEven2odd1 == even2odd1);
        }

        public static string addSquareParantheses(string text)
        {
            return '[' + text + ']';
        }

        public static string removeSquareParantheses(string textWithSquareParantheses)
        {
            return textWithSquareParantheses.Substring(1, textWithSquareParantheses.Length - 2);
        }
    }
}
