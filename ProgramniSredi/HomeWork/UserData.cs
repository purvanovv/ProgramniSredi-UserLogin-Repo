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
            DateTime current = DateTime.Now;
            DateTime activeUntil = DateTime.MaxValue;
            _testUsers = new List<User>();
            User admin = new User
            {
                Username = "UserAdmin",
                Password = "admin",
                FakNumber = "123456",
                Role = UserRoles.ADMIN,
                Created = current,
                ActiveUntil = activeUntil
            };
            User student1 = new User
            {
                Username = "UserStudent1",
                Password = "student1",
                FakNumber = "123456",
                Role = UserRoles.STUDENT,
                Created = current,
                ActiveUntil = activeUntil
            };
            User student2 = new User
            {
                Username = "UserStudent2",
                Password = "student2",
                FakNumber = "123456",
                Role = UserRoles.STUDENT,
                Created = current,
                ActiveUntil = activeUntil
            };
            _testUsers.Add(admin);
            _testUsers.Add(student1);
            _testUsers.Add(student2);
        }

        public static User IsUserPassCorrect(String username, String password)
        {
            foreach (User user in TestUsers)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    return user;
                }
            }
            return null;
        }

        public static void SetUserActiveTo(int userIndex, DateTime activeUntil)
        {

            UserData.TestUsers[userIndex].ActiveUntil = activeUntil;
            Logger.LogActivity($"Changed active until on user {UserData.TestUsers[userIndex].Username}");
        }

        public static void AssignUserRole(int userIndex, UserRoles role)
        {
            UserData.TestUsers[userIndex].Role = role;
            Logger.LogActivity($"Changed role on user {UserData.TestUsers[userIndex].Username}");

        }

        public static Dictionary<String, int> AllUsersUsernames()
        {
            Dictionary<String, int> result = new Dictionary<string, int>();
            for (int i = 0; i < TestUsers.Count; i++)
            {
                result.Add(TestUsers[i].Username, i);
            }
            return result;
        }
    }
}
