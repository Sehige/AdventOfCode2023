using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day2
    {
        public static string[] sColorList = { "red", "green", "blue" };

        public static void Solve()
        {
            string[] sText = AdventOfCode.GetData(2);

            //Part 1
            int nTotal = 0;
            bool bError = false;
            //Part2
            int nGameTotal = 1;

            for (int i = 0; i < sText.Length; i++)
            {
                bError = false;
                string sLine = sText[i];
                sLine = sLine.Split(':')[1];
                string[] sPulls = sLine.Split(";");

                List<int> listMax = new() { 1, 1, 1 };
                foreach (string sPull in sPulls)
                {
                    List<int> listData = new();
                    if (bError) break;

                    string[] sData = sPull.Split(",");
                    foreach (string sDataSingle in sData)
                    {
                        // Part 1
                        //bError |= GetColor(sDataSingle);

                        //Part 2
                        listData = GetListValues(sDataSingle);
                        GetMaxValue(ref listMax, listData);
                    }
                }

                //Part1
                //if (bError == false)
                //{
                //    nTotal += i + 1;
                //}

                //Part 2
                foreach (int nNr in listMax)
                {
                    nGameTotal *= nNr;
                }
                nTotal += nGameTotal;
                nGameTotal = 1;
            }

            Console.WriteLine(nTotal);
        }

        private static bool GetColor(string sData)
        {
            foreach (string sColor in sColorList)
            {
                if (sData.Contains(sColor) == false) continue;

                string sNr = sData.Replace(sColor, "");
                int.TryParse(sNr, out int nNr);
                if (nNr > 14) return true;
                else if (nNr > 14 && sColor == sColorList[2]) return true; //blue
                else if (nNr > 13 && sColor == sColorList[1]) return true; //green
                else if (nNr > 12 && sColor == sColorList[0]) return true; //red

            }

            return false;
        }

        private static List<int> GetListValues(string sData)
        {
            List<int> result = new() { 1, 1, 1 };

            for (int i = 0; i < sColorList.Length; i++)
            {
                string sColor = sColorList[i];
                if (sData.Contains(sColor) == false) continue;

                string sNr = sData.Replace(sColor, "");
                int.TryParse(sNr, out int nNr);

                result[i] = nNr;
            }

            return result;
        }

        private static void GetMaxValue(ref List<int> listMax, List<int> listData)
        {
            for (int i = 0; i < 3; i++)
            {
                if (listData[i] > listMax[i]) listMax[i] = listData[i];
            }
        }
    }
}
