using System;
using System.Security.Principal;

namespace UttUserService.Security
{
    public class UttPrincipal : IPrincipal
    {
        private UttIdentity _identity;

        public UttIdentity Identity
        {
            get { return _identity ?? new AnonymousIdentity(); }
            set { _identity = value; }
        }
        

        IIdentity IPrincipal.Identity
        {
            get { return Identity; }
        }

        public bool IsInRole(string role)
        {
            Role r = (Role)Enum.Parse(typeof (Role), role);
            return _identity.Roles.Contains(r);
        }
    }
}