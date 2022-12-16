using System.IO;
using System.Collections.Generic;
using System;

namespace integer_reader
{
    class Program
    {
        static void Main(string[] args)
        {
          using(var reader = new StreamReader(@"C:\intfile.csv"))
            {
                List<string> listA = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    listA.Add(line);
                }

                string combinedString = string.Join(",", listA.ToArray());

                int[] csvnumbers = StringToIntArray(combinedString);

                for (int index1 = 0; index1 < csvnumbers.Length - 1; index1++)
                {
                    for (int index = 0; index < csvnumbers.Length - 1; index++)
                    {
                        int tempnum = 0;

                        if (csvnumbers[index + 1] < csvnumbers[index])
                        {
                            tempnum = csvnumbers[index];
                            csvnumbers[index] = csvnumbers[index + 1];
                            csvnumbers[index + 1] = tempnum;
                        }
                    }
                }

                for (int i = 0; i < csvnumbers.Length; i++)
                {
                    Console.WriteLine(csvnumbers[i]);
                }

                String filePath = @"E:\Output.csv";
                var csvstring = String.Join(",", csvnumbers);
                File.WriteAllText(filePath, csvstring);

                Console.WriteLine("Numbers Processed: ");
                Console.Write(csvnumbers.Length.ToString());
            }
        }

        private static int[] StringToIntArray(string myNumbers)
        {
            List<int> myIntegers = new List<int>();
            Array.ForEach(myNumbers.Split(",".ToCharArray()), s =>
            {
                int currentInt;
                if (Int32.TryParse(s, out currentInt))
                    myIntegers.Add(currentInt);
            });
            return myIntegers.ToArray();
        }
    }
}
