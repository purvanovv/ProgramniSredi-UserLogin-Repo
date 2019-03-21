using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginValidation validation = new LoginValidation(PrintErrorMsg);
            User user = new User();
            if (validation.ValidateUserInput(ref user))
            {
                UserRoles role = LoginValidation.currentUserRole;
                switch (role)
                {
                    case UserRoles.ANONYMOUS:
                        {
                            Console.WriteLine($"User with username ${user.Username} is anonymous.");
                            break;
                        }
                    case UserRoles.ADMIN:
                        {
                            ActionAdminMenu();
                            break;
                        }
                    case UserRoles.INSPECTOR:
                        {
                            Console.WriteLine($"User with username ${user.Username} is inspector.");
                            break;
                        }
                    case UserRoles.PROFESSOR:
                        {
                            Console.WriteLine($"User with username ${user.Username} is professor.");
                            break;
                        }
                    case UserRoles.STUDENT:
                        {
                            Console.WriteLine($"User with username ${user.Username} is student.");
                            break;
                        }
                }

            }
        }
        public static void PrintErrorMsg(string errorMsg)
        {
            Console.WriteLine($"!!! {errorMsg} !!!");
        }

        public static void PrintAllUsers(Dictionary<String, int> users)
        {
            Console.WriteLine("Users");
            foreach (var pair in users)
            {
                Console.WriteLine($"id:{pair.Value}; username:{pair.Key}");
            }
        }

        public static void PrintText(String text)
        {
            Console.WriteLine(text);
        }

        public static void ActionAdminMenu()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("* 0: Exit                          *");
            Console.WriteLine("* 1: Change user role              *");
            Console.WriteLine("* 2: Change user active until      *");
            Console.WriteLine("* 3: List all users                *");
            Console.WriteLine("* 4: Show current activit          *");
            Console.WriteLine("* 5: Show all users activity       *");
            Console.WriteLine("************************************");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    {

                        break;
                    }
                case 1:
                    {
                        Dictionary<String, int> allUsers = UserData.AllUsersUsernames();
                        PrintAllUsers(allUsers);

                        Console.WriteLine("Enter username:");
                        String username = Console.ReadLine();
                        Console.WriteLine("Enter role:");
                        UserRoles role = (UserRoles)int.Parse(Console.ReadLine());
                        UserData.AssignUserRole(allUsers[username], role);
                        break;
                    }
                case 2:
                    {
                        Dictionary<String, int> allUsers = UserData.AllUsersUsernames();
                        PrintAllUsers(allUsers);

                        Console.WriteLine("Enter username:");
                        String username = Console.ReadLine();
                        Console.WriteLine("Enter date:");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        UserData.SetUserActiveTo(allUsers[username], date);
                        break;
                    }
                case 3:
                    {
                        Dictionary<String, int> allUsers = UserData.AllUsersUsernames();
                        PrintAllUsers(allUsers);
                        break;
                    }
                case 4:
                    {
                        String result = Logger.GetCurrentSessionActivities();
                        PrintText(result);
                        break;
                    }
                case 5:
                    {
                        String result = Logger.GetAllUsersActivity();
                        PrintText(result);
                        break;
                    }
            }
        }
    }

}
