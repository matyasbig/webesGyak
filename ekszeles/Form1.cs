using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using ekszeles.Models;

namespace ekszeles
{
    public partial class Form1 : Form
    {
        Excel.Application xlApp;
        Excel.Workbook xlWb;
        Excel.Worksheet xlWs;

        public Form1()
        {
            InitializeComponent();

            try { CreateExcel(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                xlWb.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWb = null;
                xlApp = null;
            }
        }

        private void CreateExcel()
        {
            xlApp = new Excel.Application();
            xlWb = xlApp.Workbooks.Add(Missing.Value);
            xlWs = xlWb.ActiveSheet;
            
            CreateTable();

            xlApp.Visible = true;
            xlApp.UserControl = true;
        }

        private void CreateTable()
        {
            string[] headers = new string[]
            {
                "Kérdés",
                "1. válasz",
                "2. válasz",
                "3. válasz",
                "Helyes válasz",
                "kép"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                xlWs.Cells[1, i + 1] = headers[i];
            }

            HajosContext context = new();
            var questions = context.Questions.ToList();

            object[,] data = new object[questions.Count, headers.Length];

            for (int i = 0; i < questions.Count; i++)
            {
                data[i, 0] = questions[i].Question1;
                data[i, 1] = questions[i].Answer1;
                data[i, 2] = questions[i].Answer2;
                data[i, 3] = questions[i].Answer3;
                data[i, 4] = questions[i].CorrectAnswer;
                data[i, 5] = questions[i].Image;
            }

            int rowCount = data.GetLength(0);
            int colCount = data.GetLength(1);

            Excel.Range range = xlWs.get_Range("A2", Type.Missing).get_Resize(rowCount, colCount);
            range.Value2 = data;

            FormatTable();
        }

        private void FormatTable()
        {
            Excel.Range headerRange = xlWs.get_Range("A1", Type.Missing).get_Resize(1, 6);

            headerRange.Font.Bold = true;

            headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            headerRange.HorizontalAlignment= Excel.XlHAlign.xlHAlignCenter;

            headerRange.EntireColumn.AutoFit();
            headerRange.RowHeight = 40;
        }
    }
}