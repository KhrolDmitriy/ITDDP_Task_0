using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ITiROD_Lab_1
{
    [Serializable]
    public class Group
    {
        public List<Student> Students { get; set; }

        public string[] Headers { get; set; }

        public List<double> ArgMarks { get; set; }

        public void CalcArg()
        {
            double marks;
            for (int j = 0; j < Headers.Length - 3; j++)
            {
                marks = 0;
                for (int i = 0; i < Students.Count; i++)
                {
                    marks += Students[i].Marks[j];
                }
                marks /= Students.Count;
                ArgMarks.Add(Math.Round(marks, 1));
            }
        }
    }
}
