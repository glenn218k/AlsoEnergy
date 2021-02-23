using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ChallengeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>();

        private static readonly string[] Colors = new[]
        {
            "Blue", "Green", "Red", "Yellow", "Black", "Brown", "Purple", "Pink", "White", "Orange"
        };

        private static readonly string[] Timezones = new[]
        {
            "HST", "AKST", "PST", "MST", "CST", "EST"
        };

        private static Random rng = new Random();
        private static DateTime start = new DateTime(1987, 1, 1);
        private static int range = (DateTime.Today - start).Days;

        [HttpGet]
        [Route("api/user/{username}")]
        public User Get(string username)
        {
            var user = _users.GetOrAdd(username, u =>
            {
                int permCount = rng.Next(1, 100);
                List<int> perms = new List<int>();
                List<int> allPerms = Enumerable.Range(1, 100).ToList();
                for (int i = 0; i < permCount; i++)
                {
                    int idx = rng.Next(allPerms.Count());
                    perms.Add(allPerms[idx]);
                    allPerms.RemoveAt(idx);
                }

                return new User
                {
                    CreationDate = start.AddDays(rng.Next(range)),
                    FavoriteColor = Colors[rng.Next(Colors.Length)],
                    PermissionSet = new PermissionSet(perms),
                    Timezone = Timezones[rng.Next(Timezones.Length)],
                    Username = username
                };                
            });

            return user;
        }
    }
}
