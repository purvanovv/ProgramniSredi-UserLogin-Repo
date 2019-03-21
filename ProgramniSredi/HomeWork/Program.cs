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
                //switch by user role
                Console.WriteLine($"currentUserRole:{LoginValidation.currentUserRole}");
                Console.WriteLine($"username:{user.Username}");
            }
        }
        public static void PrintErrorMsg(string errorMsg)
        {
            Console.WriteLine($"!!! {errorMsg} !!!");
        }
    }

}
