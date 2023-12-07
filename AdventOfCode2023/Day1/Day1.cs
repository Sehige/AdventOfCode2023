using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day1
    {
        public static void Solve()
        {
            string filePath = "\\Day1\\Day1.txt";
            string workingDirectory = Environment.CurrentDirectory;
            string sDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string[] sText = File.ReadAllLines(sDirectory + filePath);

            int nTotal = 0;
            foreach (string s in sText)
            {
                List<int> numbers = GetFirstNumberInString(s);

                int cNr1 = numbers[0];
                int cNr2 = numbers.Last(); 

                int nNrFinal = cNr1 * 10 + cNr2;
                Console.WriteLine(nNrFinal);
                nTotal += nNrFinal;
            }

            Console.WriteLine(nTotal);
        }

        private static int GetFirstNumber(string sLine)
        {
            foreach (char c in sLine)
            {
                if (int.TryParse(c.ToString(), out int nNr) == false) continue;

                return nNr;
            }

            return 0;
        }

        private static List<int> GetFirstNumberInString(string sLine)
        {
            List<int> numbers = new List<int>();

            int nSpaces = sLine.Length < 5 ? sLine.Length : 5;
            int nStart = 0; int nEnd = 4;
            do
            {
                nEnd++;
                if (nStart + 5 > sLine.Length)
                    nSpaces = sLine.Length - nStart;

                string sSegment = sLine.Substring(nStart, nSpaces);
                int nNumberSearch = SearchForNumber(sSegment, out int nIndexString);
                bool bContainsNr = ContainsNumber(sSegment);
                int nIndexNumber = sSegment.IndexOf(GetFirstNumber(sSegment).ToString());

                if (bContainsNr)
                {
                    nStart += nIndexNumber;
                    nEnd = nStart + 4;
                    if (nEnd + 1 >= sLine.Length)
                    {
                        nSpaces = sLine.Length - nStart - 2;
                        nEnd = sLine.Length - 1;
                    }
                }

                if (nNumberSearch != 0 && bContainsNr)
                {
                    if (nIndexString < nIndexNumber)
                    {
                        numbers.Add(nNumberSearch);
                        numbers.Add(GetFirstNumber(sSegment));
                    }
                    else
                    {
                        numbers.Add(GetFirstNumber(sSegment));
                        numbers.Add(nNumberSearch);
                    }
                }
                else if (nNumberSearch != 0)
                {
                    numbers.Add(nNumberSearch);
                }
                else if (ContainsNumber(sSegment))
                {
                    numbers.Add(GetFirstNumber(sSegment));
                }

                nStart++;
            } while (nEnd < sLine.Length);

            return numbers;
        }


        private static bool ContainsNumber(string sSegment)
        {
            Regex regex = new("[1-9]");
            return regex.IsMatch(sSegment);
        }

        private static int SearchForNumber(string sSegment, out int nIndex)
        {
            nIndex = -1;

            if (sSegment.Contains("one"))
            {
                nIndex = sSegment.IndexOf("one");
                return 1;
            }
            else if (sSegment.Contains("two"))
            {
                nIndex = sSegment.IndexOf("two");
                return 2;
            }
            else if (sSegment.Contains("three"))
            {
                nIndex = sSegment.IndexOf("three");
                return 3;
            }
            else if (sSegment.Contains("four"))
            {
                nIndex = sSegment.IndexOf("four");
                return 4;
            }
            else if (sSegment.Contains("five"))
            {
                nIndex = sSegment.IndexOf("five");
                return 5;
            }
            else if (sSegment.Contains("six"))
            {
                nIndex = sSegment.IndexOf("six");
                return 6;
            }
            else if (sSegment.Contains("seven"))
            {
                nIndex = sSegment.IndexOf("seven");
                return 7;
            }
            else if (sSegment.Contains("eight"))
            {
                nIndex = sSegment.IndexOf("eight");
                return 8;
            }
            else if (sSegment.Contains("nine"))
            {
                nIndex = sSegment.IndexOf("nine");
                return 9;
            }
            else return 0;
        }

    }
}
