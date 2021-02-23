using AE.CoreUtility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Challenge
{
    public class User
    {
        public BlobIO ToBlobIO()
        {
            BlobIO blob = null;
            blob += CreationDate;
            blob += FavoriteColor;
            blob += PermissionSet;
            blob += Timezone;
            blob += Username;

            return blob;
        }

        public DateTime CreationDate { get; set; }
        public string FavoriteColor { get; set; }
        public PermissionSet PermissionSet { get; set; }
        public string Timezone { get; set; }
        public string Username { get; set; }
    }
}
