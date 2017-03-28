using System.Collections.Generic;
using UttUserService.DB.Entities;

namespace UttUserService.Security
{
    public class AnonymousIdentity : UttIdentity
    {
        public AnonymousIdentity()
            : base(string.Empty, new List<Role>())
        { }
    }
}