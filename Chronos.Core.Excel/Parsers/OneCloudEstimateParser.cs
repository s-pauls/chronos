using System;
using System.Collections.Generic;
using System.Linq;
using Chronos.Domain.Entities.Estimate;
using Chronos.Domain.Enums;
using OfficeOpenXml;

namespace Chronos.Core.Excel.Parsers
{
    public class OneCloudEstimateParser : ParserBase
    {
        private const string startCellValue = "Story Cards Names";

        protected override string GetWorkBookNameByDiscipline(Discipline discipline)
        {
            return discipline switch
            {
                Discipline.BA => "BA",
                Discipline.DEV => "DEV",
                Discipline.QA => "QA",
                Discipline.EQA => "AUT",
                _ => throw new ArgumentOutOfRangeException(nameof(discipline), discipline, null)
            };
        }

        protected override IEnumerable<EstimateItem> GetEstimateItems(ExcelWorksheet worksheet, Discipline discipline)
        {
            var startCell = worksheet.FindCellsByValue(startCellValue);

            if (startCell == null)
            {
                return null;
            }

            var rightEndCell = worksheet.FindCellsByValueInRow(startCell.RowIndex, (cellValue) => Equals(cellValue, "Total"), startCell.ColumnIndex);

            if (rightEndCell == null)
            {
                return null;
            }

            var bottomEndCell = worksheet.FindCellsByValueInColumn(startCell.ColumnIndex, (cellValue) => Equals(cellValue, "Total"), startCell.RowIndex);

            if (bottomEndCell == null)
            {
                return null;
            }

            List<EstimateItem> result = new List<EstimateItem>();
            List<string> headers = new List<string>();

            for (int colIndex = startCell.ColumnIndex + 1; colIndex < rightEndCell.ColumnIndex; colIndex++)
            {
                var value = worksheet.Cells[startCell.RowIndex, colIndex].Value;
                headers.Add(value.ToString());
            }

            for (int rowIndex = startCell.RowIndex + 1; rowIndex < bottomEndCell.RowIndex; rowIndex++)
            {
                var name = worksheet.GetCellValue(rowIndex, startCell.ColumnIndex);

                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }

                var number = worksheet.GetCellValue(rowIndex, startCell.ColumnIndex - 1);
                var estimateItem = new EstimateItem
                {
                    Discipline = discipline,
                    EstimateTasks = new List<EstimateTask>(),
                    Name = name,
                    Number = string.IsNullOrEmpty(number) ? 0 : int.Parse(number)
                };

                var i = 0;
                for (int colIndex = startCell.ColumnIndex + 1; colIndex < rightEndCell.ColumnIndex; colIndex++)
                {
                    var value = worksheet.GetCellValue(rowIndex, colIndex);

                    if (string.IsNullOrEmpty(value))
                    {
                        continue;
                    }

                    if (!double.TryParse(value, out var valueDouble))
                    {
                        continue;
                    }

                    if (valueDouble == 0)
                    {
                        continue;
                    }

                    var estimateTask = new EstimateTask
                    {
                        Name = headers[i++],
                        Hours = valueDouble
                    };

                    estimateItem.EstimateTasks.Add(estimateTask);
                }

                if (estimateItem.EstimateTasks.Any())
                {
                    result.Add(estimateItem);
                }
            }

            return result;
        }


    }
}
