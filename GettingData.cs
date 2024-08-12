using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrimalSolver
{
    internal class GettingData
    {
        public string[,] readFile()
        {
            try
            {
                StreamReader sr = new StreamReader("E:\\brand\\Documents\\BC Uni\\3rd Year\\LPR381\\ProgramPrimal\\PrimalSolver\\inputFile.txt");
                List<string[]> rawDataList = new List<string[]>();

                string line = sr.ReadLine();
                while (line != null)
                {
                    // Split each line into an array of words/numbers
                    string[] splitLine = line.Split(' ');
                    rawDataList.Add(splitLine);
                    line = sr.ReadLine();
                }
                sr.Close();

                int numLines = rawDataList.Count;
                int maxElements = rawDataList.Max(array => array.Length);

                string[,] rawData = new string[numLines, maxElements];
                for (int i = 0; i < numLines; i++)
                {
                    for (int j = 0; j < rawDataList[i].Length; j++)
                    {
                        rawData[i, j] = rawDataList[i][j];
                    }
                }

                // Example output
                /*for (int i = 0; i < numLines; i++)
                {
                    for (int j = 0; j < maxElements; j++)
                    {
                        Console.Write(i + " " + j + " --> " + rawData[i, j] + " ");
                    }
                    Console.WriteLine();
                }*/

                return rawData;
            }
            catch
            {
                return new string[,] { { null } };
            }
        }
    }
}
