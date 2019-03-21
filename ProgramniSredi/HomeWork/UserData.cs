using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {
        public static List<User> _testUsers;
        public static List<User> TestUsers { get { ResetTestUSerData(); return _testUsers; } set { } }

        private static void ResetTestUSerData()
        {
            _testUsers = new List<User>();
            User admin = new User
            {
                Username = "UserAdmin",
                Password = "admin",
                FakNumber = "123456",
                Role = UserRoles.ADMIN
            };
            User student1 = new User
            {
                Username = "UserStudent1",
                Password = "student1",
                FakNumber = "123456",
                Role = UserRoles.STUDENT
            };
            User student2 = new User
            {
                Username = "UserStudent2",
                Password = "student2",
                FakNumber = "123456",
                Role = UserRoles.STUDENT
            };
            _testUsers.Add(admin);
            _testUsers.Add(student1);
            _testUsers.Add(student2);
        }

        public static User IsUserPassCorrect(String username, String password)
        {
            foreach (User user in TestUsers)
            {
                if(user.Username.Equals(username) && user.Password.Equals(password))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
