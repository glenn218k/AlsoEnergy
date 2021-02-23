using AE.CoreUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenge
{
    public class PermissionSet
    {
        public PermissionSet(IEnumerable<int> permissions)
        {
            // if any passed in permission is > 100 or <= 0, throw
            if (permissions != null && permissions.Any(p => p > 100 || p <= 0))
                throw new Exception(nameof(permissions));

            Permissions = permissions?.ToList() ?? new List<int>();
        }

        public PermissionSet(byte[] bytes)
        {
            // if we dont't have any bytes, just set an empty list
            if (bytes?.Any() != true)
            {
                Permissions = new List<int>();
                return;
            }

            List<int> permissions = Enumerable.Range(0, bytes.Length / 4).Select(i => BitConverter.ToInt32(bytes, i * 4)).ToList();

            // if any passed in permission is > 100 or <= 0, throw
            if (permissions != null && permissions.Any(p => p > 100 || p <= 0))
                throw new Exception(nameof(permissions));

            Permissions = permissions;
        }

        public byte[] ToByteArray()
        {
            return Permissions.SelectMany(BitConverter.GetBytes).ToArray();
        }

        public List<int> Permissions { get; }
    }
}