using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler89
{
    public class Program
    {
        static void Main(string[] args)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("p089_roman.txt");

            int charsSaved = 0;

            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                int charsInLine = line.Length;
                int romanValue = RomanStringToInt(line);
                string minimalRep = IntToRoman(romanValue);
                int minimalChars = minimalRep.Length;
                charsSaved += charsInLine - minimalChars;
            }

            file.Close();

            Console.WriteLine(charsSaved);
            Console.ReadLine();
        }

        static char[] validChars = new char[] { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };

        public static int RomanStringToInt(string roman)
        {
            int n = 0;

            char[] carr = roman.ToCharArray();

            bool usedD = false;
            bool usedL = false;
            bool usedV = false;

            int i = 0;
            while (i < carr.Length)
            {
                if (validChars.Contains(carr[i]) == false)
                    return -1;

                if(carr[i] == 'M')
                {
                    if (n % 1000 > 0) return -1; //out of order, we've seen smaller already
                    n += 1000;
                    i++;
                    continue;
                }

                if(carr[i] == 'D')
                {
                    if (usedD) return -1; //there can only be one D
                    if (n % 500 > 0) return -1; //out of order, we've seen smaller already;

                    usedD = true;
                    n += 500;
                    i++;
                    continue;
                }

                if(carr[i] == 'C')
                {
                    if (n % 100 > 0) return -1; //out of order, we've seen smaller already;
                    if((i < carr.Length - 1) && (carr[i+1] == 'M' || carr[i+1] == 'D'))
                    {
                        if (carr[i + 1] == 'M')
                        {
                            n += 900;
                        }
                        else
                        {
                            n += 400;
                            usedD = true;
                        }
                        i += 2;
                        continue; 
                    }
                    n += 100;
                    i++;
                    continue;
                }

                if (carr[i] == 'L')
                {
                    if (usedL) return -1; //there can only be one D
                    if (n % 50 > 0) return -1; //out of order, we've seen smaller already;

                    usedL = true;
                    n += 50;
                    i++;
                    continue;
                }

                if (carr[i] == 'X')
                {
                    if (n % 10 > 0) return -1; //out of order, we've seen smaller already;
                    if ((i < carr.Length - 1) && (carr[i + 1] == 'L' || carr[i + 1] == 'C'))
                    {
                        if (carr[i + 1] == 'C') n += 90; else n += 40;
                        i += 2;
                        continue;
                    }
                    n += 10;
                    i++;
                    continue;
                }

                if (carr[i] == 'V')
                {
                    if (usedV) return -1; //there can only be one D
                    if (n % 5 > 0) return -1; //out of order, we've seen smaller already;

                    usedV = true;
                    n += 5;
                    i++;
                    continue;
                }

                if (carr[i] == 'I')
                {
                    if ((i < carr.Length - 1) && (carr[i + 1] == 'X' || carr[i + 1] == 'V'))
                    {
                        if (carr[i + 1] == 'X') n += 9; else n += 4;
                        i += 2;
                        continue;
                    }
                    n++;
                    i++;
                    continue;
                }
            }

            return n;
        }

        public static string IntToRoman(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException();

            string s = "";
            while(n >= 1000)
            {
                s += 'M';
                n -= 1000;
            }

            if(n >= 900)
            {
                s += "CM";
                n -= 900;
            }
            if(n >= 500)
            {
                s += 'D';
                n -= 500;
            }
            if(n >= 400)
            {
                s += "CD";
                n -= 400;
            }
            while( n >= 100)
            {
                s += 'C';
                n -= 100;
            }

            if (n >= 90)
            {
                s += "XC";
                n -= 90;
            }
            if (n >= 50)
            {
                s += 'L';
                n -= 50;
            }
            if (n >= 40)
            {
                s += "XL";
                n -= 40;
            }
            while (n >= 10)
            {
                s += 'X';
                n -= 10;
            }

            if (n == 9)
            {
                s += "IX";
                n -= 9;
            }
            if (n >= 5)
            {
                s += 'V';
                n -= 5;
            }
            if (n == 4)
            {
                s += "IV";
                n -= 4;
            }
            while (n >= 1)
            {
                s += 'I';
                n --;
            }

            return s;
        }
    }
}
