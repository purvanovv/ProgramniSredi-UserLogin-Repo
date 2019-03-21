using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class LoginValidation
    {
        public static UserRoles currentUserRole { get; private set; }
        public static String Username;
        public static String Password;
        private ActionOnError actionOnError;

        public LoginValidation(ActionOnError actionOnError)
        {
            Console.WriteLine("Enter username:");
            String username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            String password = Console.ReadLine();
            this.actionOnError = new ActionOnError(actionOnError);
            new LoginValidation(username, password);
        }

        public LoginValidation(String username, String password)
        {
            Username = username;
            Password = password;
        }

        public bool ValidateUserInput(ref User user)
        {
            String _errorLog;
            currentUserRole = UserRoles.ANONYMOUS;

            if (Username.Equals(String.Empty))
            {
                _errorLog = "Username is empty!";
                actionOnError(_errorLog);
                return false;
            }
            else if (Password.Equals(String.Empty))
            {
                _errorLog = "Password is empty!";
                actionOnError(_errorLog);
                return false;
            }
            else if(Username.Length < 5)
            {
                _errorLog = "Username must be 5 or more symbols!";
                actionOnError(_errorLog);
                return false;
            }
            else if (Password.Length < 5)
            {
                _errorLog = "Password must be 5 or more symbols!";
                actionOnError(_errorLog);
                return false;
            }

            user = UserData.IsUserPassCorrect(Username,Password);
            if(user != null)
            {
                currentUserRole = user.Role;
                Logger.LogActivity("Succesfull login.");
                return true;
            }
            else
            {
                _errorLog = $"User with username: {Username} or password: ******** does not exists!";
                actionOnError(_errorLog);
                return false;
            }
        }

        public delegate void ActionOnError(String errorMsg);

    }
}
