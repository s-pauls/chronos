using System.Runtime.Serialization;

namespace Chronos.Domain.Entities.FeatureRules
{
    [DataContract]
    public class StoryRules
    {
        [DataMember]
        public string Title { get; set; }

        public TitleVariable[] TitleVariables { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string AcceptanceCriteria { get; set; }

        [DataMember]
        public string[] Tags { get; set; }

        public string[] DefaultTags { get; set; }
    }
}
