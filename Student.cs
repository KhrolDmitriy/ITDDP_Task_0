using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ITiROD_Lab_1
{
    [Serializable]
    public class Student
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public List<int> Marks { get; set; }
        
        public double Avg { get; set; }
        public void CalculateAvg()
        {
            double sum = 0;
            for (int i = 0; i < Marks.Count; i++)
            {
                sum += Marks[i];
            }
            Avg = Math.Round(sum / Marks.Count, 1);
        }
    }
}
