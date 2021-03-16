using System;

namespace Chronos.Domain.Entities
{
    public class Release
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CodeCompleteData { get; set; }
        public DateTime TestCompleteData { get; set; }
        public DateTime ReleaseData { get; set; }
    }
}
