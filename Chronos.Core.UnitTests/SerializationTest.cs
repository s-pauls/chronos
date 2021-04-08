using AutoBogus;
using Chronos.Domain.Entities.FeatureRules;
using Newtonsoft.Json;
using Xunit;

namespace Chronos.Core.UnitTests
{
    public class SerializationTest
    {
        [Fact]
        public void FeatureRules_Serialize_Deserialize()
        {
            var featureRules = new AutoFaker<FeatureRules>().Generate();
            var json = JsonConvert.SerializeObject(featureRules);
            var featureRulesClon = JsonConvert.DeserializeObject<FeatureRules>(json);

            Assert.NotNull(featureRulesClon);
        }

    }
}
