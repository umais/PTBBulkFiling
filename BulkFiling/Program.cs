using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BulkFiling
{
    class Program
    {
        

        static void Main(string[] args)
        {

            Console.WriteLine("Enter the following filename PROT-2020-aa-XXX-nnnnn.TXT \n where aa is the sequence number of your file if more than one is submitted,\n XXX is your Representative Code and nnnnn is the number of records on the file.");

            string fileName = Console.ReadLine();
                    List<String> lst = Data("bulkupload.csv");
            StreamWriter writer = new StreamWriter(fileName);
            foreach(String s in lst)
            {
                writer.WriteLine(s);
            }
            Console.Write("Done");
            Console.ReadKey();
        }

      


        public static List<String> Data(string fileName)
        {
            string colwidths = "23, 67, 1, 1, 50, 50, 11, 5, 8, 4, 11, 1, 1, 11, 9, 1, 1, 1, 15, 15, 20, 20, 1, 1, 11, 1, 20, 50, 1, 1, 4, 12, 1, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 20, 1, 4, 1, 1, 4, 4, 4, 4, 4, 50, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 50, 11, 8, 1, 4, 11, 3, 5, 11, 60, 1";
            String[] widths = colwidths.Split(',');
            int[] arr=Array.ConvertAll(widths, s => int.Parse(s));
            StreamReader sr = new StreamReader(fileName);
            String[] columns = new String[83];
            columns = Enumerable.Repeat(string.Empty, columns.Length).ToArray();
            string myStringRow = sr.ReadLine();
            myStringRow = sr.ReadLine();
           
            List<String> lst = new List<string>();
            while (myStringRow != null)
            {
                var rows = myStringRow.Split(',');

                columns[0] = rows[0];
                columns[1] = rows[1];
                columns[6] = rows[2];
                columns[9] = rows[3];
                columns[10] = rows[4];
                columns[11] = rows[5];
                columns[12] = rows[6];
                columns[13] = rows[7];
                columns[15] = rows[8];
                columns[16] = rows[9];
                columns[17] = rows[10];
                columns[81] = rows[11];
                columns[82] = rows[12];
                string s1 = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    s1 += AddSpace(arr[i] - columns[i].Length, columns[i],i);
                }
                lst.Add(s1);
                myStringRow = sr.ReadLine();
            }
            sr.Close();
            sr.Dispose();

            return lst;
        }

        public static string AddSpace(int number,string column,int fieldPosition)
        {

            StringBuilder sb = new StringBuilder();
            if(fieldPosition==0 || fieldPosition==1)
                sb.Append(column);
            for (int i=1;i<=number;i++)
            {
                sb.Append(" ");
            }
            if(fieldPosition !=0 && fieldPosition!=1)
            sb.Append(column);

            return sb.ToString();
        }
    }
}
