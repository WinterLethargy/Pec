using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pec
{
    internal class UserComparer : EqualityComparer<User>
    {
        public override bool Equals(User? x, User? y)
        {
            var s1 = JsonConvert.SerializeObject(x);
            var s2 = JsonConvert.SerializeObject(y);
            return s1 == s2;
        }

        public override int GetHashCode([DisallowNull] User obj)
        {
            var s = JsonConvert.SerializeObject(obj);
            return s.GetHashCode();
        }
    }
}
