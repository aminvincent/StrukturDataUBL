using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingConsoleApps
{
    public class Algoritm
    {
        public static void SortingAscending()
        {
            int[] intArray = new int[] { 1, 5, 6, 7, 2, 4 };
            int temp;

            for (int i = 0; i < intArray.Length; i++)
            {
                for (int sort = 0; sort < intArray.Length - 2; sort++)
                {
                    if(intArray[sort] > intArray[sort+1])
                    {
                        temp = intArray[sort + 1];
                        intArray[sort + 1] = intArray[sort];
                        intArray[sort] = temp;
                    }
                }
            }
        }

        public static void WriteDataIntoFile(string strFilePath)
        {
            //        try
            //        {
            //            string strSeperator = ";";
            //            StringBuilder sbOutput = new StringBuilder();

            //            int[][] inaOutput = new int[][]
            //            {
            //                new int[]{1000, 2000, 3000, 4000, 5000},
            //                new int[]{6000, 7000, 8000, 9000, 10000},
            //                new int[]{11000, 12000, 13000, 14000, 15000}
            //            };

            //            int ilength = inaOutput.GetLength(0);
            //            for (int i = 0; i & amp; lt; ilength; i++)
            //sbOutput.AppendLine(string.Join(strSeperator, inaOutput[i]));

            //            // Create and write the csv file
            //            File.WriteAllText(strFilePath, sbOutput.ToString());

            //            // To append more lines to the csv file
            //            File.AppendAllText(strFilePath, sbOutput.ToString());
            //        }
            //        catch (Exception ex)
            //        {

            //            throw new Exception("Error WriteDataIntoFile: " + ex.Message.ToString());
            //        }
        }
    }
}
