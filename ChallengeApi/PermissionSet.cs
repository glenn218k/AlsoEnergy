using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeApi
{
    public class PermissionSet
    {
        public PermissionSet(List<int> permissions)
        {
            Permissions = permissions;
        }

        public List<int> Permissions { get; }
    }
}
