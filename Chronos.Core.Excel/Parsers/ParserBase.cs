using System.Collections.Generic;
using System.IO;
using Chronos.Domain.Entities.Estimate;
using Chronos.Domain.Enums;
using Chronos.Domain.Interfaces;
using OfficeOpenXml;

namespace Chronos.Core.Excel.Parsers
{
    public abstract class ParserBase : IEstimateParser
    {
        private readonly Discipline[] _disciplines = new Discipline[ ] { Discipline.BA, Discipline.DEV, Discipline.QA, Discipline.EQA};

        public List<EstimateItem> Parse(string fileName)
        {
            var result = new List<EstimateItem>();

            using (ExcelPackage excelEstimate = new ExcelPackage(new FileInfo(fileName)))
            {
                foreach (var discipline in _disciplines)
                {
                    var worksheetName = GetWorkBookNameByDiscipline(discipline);
                    var worksheet = excelEstimate.Workbook.Worksheets[worksheetName];
                    var estimateItems = GetEstimateItems(worksheet, discipline);
                    result.AddRange(estimateItems);
                }
            }

            return result;
        }

        protected abstract IEnumerable<EstimateItem> GetEstimateItems(ExcelWorksheet worksheet, Discipline discipline);

        protected abstract string GetWorkBookNameByDiscipline(Discipline discipline);
    }
}
