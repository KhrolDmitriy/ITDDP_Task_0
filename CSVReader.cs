using CsvHelper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ITiROD_Lab_1
{
    class CSVReader
    {
        public static void Read(string path, Group group)
        {
            using (var csvReader = new StreamReader(path))
            {                
                string head = csvReader.ReadLine();
                group.Headers = new string[head.Length];
                group.Headers = head.Split(';');               

                while (!csvReader.EndOfStream)
                {
                    Student st = new Student();
                    st.Marks = new List<int>();
                    string line = csvReader.ReadLine();
                    string[] fields = line.Split(';');

                    st.Name = fields[0];
                    st.Surname = fields[1];
                    st.Patronymic = fields[2];
                    for (int i = 3; i < fields.Length; i++)
                    {
                        int mark = int.Parse(fields[i]);
                        st.Marks.Add(mark);
                    }
                    group.Students.Add(st);
                }
            }            
        }
    }
}
