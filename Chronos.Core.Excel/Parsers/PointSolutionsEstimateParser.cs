using System;
using System.Collections.Generic;
using System.Linq;
using Chronos.Domain.Entities.Estimate;
using Chronos.Domain.Enums;
using OfficeOpenXml;

namespace Chronos.Core.Excel.Parsers
{
    public class PointSolutionsEstimateParser : ParserBase
    {
        private const string startCellValue = "Task / Estimation Item";

        protected override string GetWorkBookNameByDiscipline(Discipline discipline)
        {
            return discipline switch
            {
                Discipline.BA => "BA",
                Discipline.DEV => "DEV",
                Discipline.QA => "QA",
                Discipline.EQA => "AUTO",
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

            var lastColumnName = GetLastColumnName(discipline);

            var rightEndCell = worksheet.FindCellsByValueInRow(startCell.RowIndex, (cellValue) => cellValue?.ToString().Contains(lastColumnName) ?? false, startCell.ColumnIndex);

            if (rightEndCell == null)
            {
                return null;
            }

            var lastRowName = GetLastRowName(discipline);
            var bottomEndCell = worksheet.FindCellsByValueInColumn(startCell.ColumnIndex, (cellValue) => Equals(cellValue, lastRowName), startCell.RowIndex);

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

                var assumptions = worksheet.GetCellValue(rowIndex, startCell.ColumnIndex - 1);
                var estimateItem = new EstimateItem
                {
                    Discipline = discipline,
                    EstimateTasks = new List<EstimateTask>(),
                    Name = name,
                    Assumptions = assumptions,
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

        private string GetLastColumnName(Discipline discipline)
        {
            switch (discipline)
            {
                case Discipline.BA:
                case Discipline.DEV:
                case Discipline.EQA:
                    return "Summary: Subtotal";
                case Discipline.QA:
                    return "Total";
                default:
                    throw new ArgumentOutOfRangeException(nameof(discipline), discipline, null);
            }
        }

        private string GetLastRowName(Discipline discipline)
        {
            switch (discipline)
            {
                case Discipline.BA:
                    return "Estimated by:";
                case Discipline.DEV:
                case Discipline.EQA:
                case Discipline.QA:
                    return "Total";
                default:
                    throw new ArgumentOutOfRangeException(nameof(discipline), discipline, null);
            }
        }
    }
}
