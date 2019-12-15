using System;
using System.Collections.Generic;
using System.Text;
using ClosedXML.Excel;

namespace ITiROD_Lab_1
{
    public class ExcelWriter
    {
        public static void Write(Group group, string path)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Лист1");
            worksheet.Cell("A" + 1).Value = group.Headers[0];
            worksheet.Cell("B" + 1).Value = group.Headers[1];
            worksheet.Cell("C" + 1).Value = group.Headers[2];
            worksheet.Cell("D" + 1).Value = "Средний балл";

            for (int i = 0; i < group.Students.Count; i++)
            {
                worksheet.Cell("A" + (i + 2)).Value = group.Students[i].Surname;
                worksheet.Cell("B" + (i + 2)).Value = group.Students[i].Name;
                worksheet.Cell("C" + (i + 2)).Value = group.Students[i].Patronymic;
                worksheet.Cell("D" + (i + 2)).Value = group.Students[i].Avg;
            }

            int k = group.Students.Count;
            k++;
            double sum = 0;

            for (int j = 1; j < group.Headers.Length - 2; j++)
            {
                worksheet.Cell("A" + (k + j)).Value = "Предмет_" + j;
                worksheet.Cell("B" + (k + j)).Value = group.ArgMarks[j-1];
                sum += group.ArgMarks[j-1];
            }

            worksheet.Cell("A" + (k + group.Headers.Length - 2)).Value = "Среднее по группе";
            worksheet.Cell("B" + (k + group.Headers.Length - 2)).Value = Math.Round(sum / (group.Headers.Length - 3), 1);

            worksheet.Columns().AdjustToContents();
            workbook.SaveAs(path + "ITiROD_Lab_1.xlsx");
        }
    }
}
