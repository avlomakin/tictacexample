using System.Collections.Generic;


namespace UttUserService.Security
{
    public class AnonymousIdentity : UttIdentity
    {
        public AnonymousIdentity()
            : base(string.Empty, new List<Role>())
        { }
    }
}