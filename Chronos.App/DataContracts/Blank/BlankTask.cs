using System.Collections.Generic;

namespace Chronos.App.DataContracts.Blank
{
    public class BlankTask
    {
        public int TaskId { get; set; }

        public string Name { get; set; }

        public decimal OriginalEstimate { get; set; }

        public string Activity { get; set; }

        public List<string> Tags { get; set; }

        public List<string> SuggestedTags { get; set; }
    }
}
