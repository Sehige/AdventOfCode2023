using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day4
    {
        public static void Solve()
        {
            string[] sText = AdventOfCode.GetData(4);
            double nSum = 0;
            List<int> listMatches = Enumerable.Repeat(0, sText.Length).ToList();

            for (int index = 0; index < sText.Length; index++)
            {
                string s = sText[index];
                GetListNumbers(out List<int> listNumber1, out List<int> listNumber2, s);

                int nMatches = 0;

                for (int i = 0; i < listNumber1.Count; i++)
                {
                    int nNr1 = listNumber1[i];

                    for (int j = 0; j < listNumber2.Count; j++)
                    {
                        int nNr2 = listNumber2[j];

                        if (nNr1 != nNr2) continue;

                        nMatches++;
                        break;
                    }
                }

                /// Part 1
                //if (nMatches > 0)
                //{
                //    nSum += Math.Pow(2, nMatches - 1);
                //}

                /// Part 2
                listMatches[index]++;
                if (nMatches > 0 && index + 1 < sText.Length)
                {
                    int nMax = index + nMatches;
                    for (int indexMatch = index; indexMatch < nMax; indexMatch++)
                    {
                        if (indexMatch + 1 > listMatches.Count) break;

                        listMatches[indexMatch + 1] += listMatches[index];
                    }
                }
            }

            /// Part 2
            foreach (int i in listMatches) 
            {
                nSum += i;
            }

            Console.WriteLine(nSum);
        }

        private static void GetListNumbers(out List<int> listNumbers1, out List<int> listNumbers2, string s)
        {
            string[] fistSplit = s.Split("|");
            string[] secondSplit = fistSplit[0].Split(":");

            string sFistNumbers = secondSplit[1];
            string sSecondNumbers = fistSplit[1];

            string[] sFirstNumbersList = sFistNumbers.Split(" ");
            sFirstNumbersList = sFirstNumbersList.Where(str => !string.IsNullOrEmpty(str)).ToArray();
            listNumbers1 = sFirstNumbersList.Select(int.Parse).ToList();
            listNumbers1.Sort();

            string[] sSecondNumbersList = sSecondNumbers.Split(" ");
            sSecondNumbersList = sSecondNumbersList.Where(str => !string.IsNullOrEmpty(str)).ToArray();
            listNumbers2 = sSecondNumbersList.Select(int.Parse).ToList();
            listNumbers2.Sort();
        }
    }
}
