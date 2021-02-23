using System;

namespace ChallengeApi
{
    public class User
    {
        public DateTime CreationDate { get; set; }
        public string FavoriteColor { get; set; }
        public PermissionSet PermissionSet { get; set; }
        public string Timezone { get; set; }
        public string Username { get; set; }
    }
}
