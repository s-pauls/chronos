using System.Collections.Generic;

namespace Chronos.App.DataContracts.Blank
{
    public class BlankFeature
    {
        public string Name { get; set; }
        
        public int FeatureId { get; set; }

        public List<BlankTask> Tasks { get; set; }

        public List<BlankStory> Stories { get; set; }

        public BlankStory ZeroStory { get; set; }
    }
}
