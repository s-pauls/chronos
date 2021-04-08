using System.Runtime.Serialization;

namespace Chronos.Domain.Entities.FeatureRules
{
    [DataContract]
    public class FeatureRules
    {
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public TaskRules FeatureTaskRules { get; set; }

        [DataMember]
        public StoryRules ZeroStoryRules { get; set; }

        [DataMember]
        public TaskRules ZeroTaskRules { get; set; }

        [DataMember]
        public StoryRules StoryRules { get; set; }

        [DataMember]
        public TaskRules TaskRules { get; set; }
    }
}
