using Microsoft.Office.Interop.Excel;

namespace ContractEndDateModifier
{
    public static class Excel
    {
        public static Application ExcelApp = new Application();

        public static IList<Contracts> GetNumberOfUsedRows()
        {
            string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Contracts.xlsx";
            Workbook wb = ExcelApp.Workbooks.Open(FilePath);
            Worksheet ws = (Worksheet)wb.Worksheets[1];
            var RowsNumber = ws.UsedRange.Rows.Count;
            Console.WriteLine(RowsNumber);
            IList<Contracts> ContractsList = new List<Contracts>();
            for (int i = 1; i <= RowsNumber; i++)
            {
                Contracts Contract = new(
                    Convert.ToString(ws.Cells[i, 1].Value),
                    Convert.ToString(ws.Cells[i, 2].Value),
                    Convert.ToString(ws.Cells[i, 3].Value)
                    );
            ContractsList.Add(Contract);
            }
            ExcelApp.Quit();
            return ContractsList;
        }
    }
}