using System;
using System.Collections.Generic;

namespace ITiROD_Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            Group group = new Group();
            group.Students = new List<Student>();
            group.ArgMarks = new List<double>();

            //start ITiROD_Lab_1.exe -i data.csv -o D:\ -f JSON

            //args[0] = "-i";
            //args[1] = "data.csv";
            //args[2] = "-o";
            //args[3] = @"D:\";
            //args[4] = "-f";
            //args[5] = "JSON";

            try
            {
                if (args[0] == "-i" && args[2] == "-o" && args[4] == "-f")
                {                    
                    CSVReader.Read(/*"data.csv"*/args[1], group);
                    foreach(Student st in group.Students)
                    {
                        st.CalculateAvg();
                    }
                    
                    group.CalcArg();                   

                    if (args[5] == "JSON")
                        JsonWriter.Write(group, /*"D:\\"*/ args[3] + ".json");
                    else if (args[5] == "EXCEL")
                         ExcelWriter.Write(group, /*"D:\\"*/ args[3]);
                }
                else
                    throw new Exception("bad params");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Работа закончена");
        }
    }
}
