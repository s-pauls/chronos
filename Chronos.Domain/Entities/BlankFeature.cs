using System.Collections.Generic;

namespace Chronos.Domain.Entities
{
    public class BlankFeature
    {
        public int FeatureId { get; set; }

        public List<BlankTask> Tasks { get; set; }

        public List<BlankStory> Stories { get; set; }

        public BlankStory ZeroStory { get; set; }
    }
}
