using System;
namespace Learn_Oop
{
    public class Auth
    {
        public static void Login(bool user, bool pass)
        {   
            if (user == true || pass == true)
            {
                Console.WriteLine("Log in");
            } else
            {
                Console.WriteLine("Please Log in");
            }
        }
    }
}
