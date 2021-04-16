using System;
using Chronos.Core.Excel.Models;
using OfficeOpenXml;

namespace Chronos.Core.Excel
{
    internal static class ExcelWorksheetExtensions
    {
        public static Cell FindCellsByValue(this ExcelWorksheet worksheet, string value)
        {
            for (int rowIndex = 1; rowIndex < 100; rowIndex++)
                for (int colIndex = 1; colIndex < 100; colIndex++)
                {
                    var cell = worksheet.Cells[rowIndex, colIndex];

                    if (Equals(cell.Value, value))
                    {
                        return new Cell
                        {
                            RowIndex = cell.Start.Row,
                            ColumnIndex = cell.Start.Column,
                            Value = cell.Value
                        };
                    }
                }

            return null;
        }

        public static Cell FindCellsByValueInColumn(this ExcelWorksheet worksheet, int columnIndex, Predicate<object> condition, int startRowIndex = 1)
        {
            for (int rowIndex = startRowIndex; rowIndex < 1000; rowIndex++)
            {
                var cell = worksheet.Cells[rowIndex, columnIndex];

                if (condition(cell.Value))
                {
                    return new Cell
                    {
                        RowIndex = cell.Start.Row,
                        ColumnIndex = cell.Start.Column,
                        Value = cell.Value
                    };
                }
            }

            return null;
        }

        public static Cell FindCellsByValueInRow(this ExcelWorksheet worksheet, int rowIndex, Predicate<object> condition, int startColumnIndex = 1)
        {
            for (int colIndex = startColumnIndex; colIndex < 100; colIndex++)
            {
                var cell = worksheet.Cells[rowIndex, colIndex];

                if (condition(cell.Value))
                {
                    return new Cell
                    {
                        RowIndex = cell.Start.Row,
                        ColumnIndex = cell.Start.Column,
                        Value = cell.Value
                    };
                }
            }

            return null;
        }

        public static string GetCellValue(this ExcelWorksheet worksheet, int rowIndex, int columnIndex)
        {
            var cell = worksheet.Cells[rowIndex, columnIndex];
            return cell?.Value?.ToString();
        }
    }
}
