using System.Collections.Generic;

namespace Chronos.Domain.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public IEnumerable<UserRole> Roles { get; set; }
        public string CoherentEmail { get; set; }
        public string EvolutionEmail { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
