using System.Collections.Generic;
using Chronos.Domain.Enums;

namespace Chronos.Domain.Entities.User
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public List<UserRole> Roles { get; set; }
        public string CoherentEmail { get; set; }
        public string EvolutionEmail { get; set; }
    }
}
