using System.Collections.Generic;
using System.Security.Principal;

namespace UttUserService.Security
{
    public class UttIdentity : IIdentity
    {
        public UttIdentity(string name, List<Role> roles)
        {
            Name = name;
            Roles = roles;
        }

        public List<Role> Roles { get; private set; }
        public string Name { get; private set; }

        public string AuthenticationType { get { return "Utt auth"; } }
        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }
    }
}