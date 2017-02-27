using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Bytescout.Spreadsheet;
using System.Diagnostics;
using System.IO;

namespace Pearson.Pegasus.TestAutomation.Frameworks
{
   public class ExcelReadWrite
    {
       
       
       
        private static Spreadsheet document = null;
        private static Worksheet worksheet = null;

        public Spreadsheet GetExcelInstance(string name)
        {
           
            document=new Spreadsheet();
            worksheet = document.Workbook.Worksheets.Add(name);
            return document;

         
        }
     

        public Spreadsheet AddHeaders(int numberOfHeaders, string[] headerNames)
        {
            for (int i =0;i<numberOfHeaders;i++)
            {

                worksheet.Cell(0, i ).Value = headerNames[i];
            }
            return document;
        }


        public Spreadsheet AddRowData(int rowNumber,int columnCount,string[] rowValues)
        {
            for (int i = 0; i < columnCount; i++)
            {

                worksheet.Cell(rowNumber, i ).Value = rowValues[i];
            }
            return document;
        }

       public void SaveExcelFile(string fileName)
        {
            document.SaveAs(@"D:\AutomationGeneratedExcelFiles\"+fileName+".xlsx");
            document.Close();
            
        }

       public Spreadsheet OpenExcelFile(string filePath,string sheetName)
       {
           document = new Spreadsheet();
           document.LoadFromFile(filePath);
           worksheet = document.Workbook.Worksheets.ByName(sheetName);
           return document;
       }

       public string ReadExcelCellData(int rowCount,int colCount)
       {
           string value = string.Empty;
           value = worksheet.Cell(rowCount, colCount).Value.ToString();
           return value;
       }

       public string[] ReadExcelCellDataValues(int rowCount,int colCount)
       {
           string[] valueArray = new string[colCount];
           for (int i=0;i<colCount;i++)
           {
               valueArray[i] = worksheet.Cell(rowCount, i).Value.ToString();
                
           }

           return valueArray;
       }

       public void CloseExcel()
       {
           document.Close();
       }
    }
}
