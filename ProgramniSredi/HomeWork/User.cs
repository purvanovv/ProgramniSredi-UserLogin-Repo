using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class User
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String FakNumber { get; set; }
        public UserRoles Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime ActiveUntil { get; set; }

    }
}
