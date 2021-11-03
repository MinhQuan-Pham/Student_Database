using System;
using System.IO;

namespace StudentDatabase
{
    public class User
    {
        public string userName;
        public string password;

        public static void SignUp()
        {
            Console.WriteLine("--- Signing Up ---");
            User user1 = new User();

            Console.WriteLine("Please enter your User Name");
            user1.userName = Console.ReadLine();
            Console.WriteLine("Please enter your Password");
            user1.password = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(File.Create("/Users/mike/Projects/StudentDatabase/user_information.csv")))
            {
                sw.WriteLine(user1.userName);
                sw.WriteLine(user1.password);
                sw.Close();
            }

            Console.WriteLine("Sign Up Successfully");
        }

        public static bool Login()
        {
            Console.WriteLine("--- Login ---");
            Console.WriteLine("User Name: ");
            string userNameCheck = Console.ReadLine();
            Console.WriteLine("Password: ");
            string passwordCheck = Console.ReadLine();

            User userOriginal = new User();

            using (StreamReader sr = new StreamReader(File.Open("/Users/mike/Projects/StudentDatabase/user_information.csv", FileMode.Open)))
            {
                userOriginal.userName = sr.ReadLine();
                userOriginal.password = sr.ReadLine();
                sr.Close();
            }

            if (userNameCheck == userOriginal.userName && passwordCheck == userOriginal.password)
            {
                Console.WriteLine("Login Successfully");
                return true;
            }
            else
            {
                Console.WriteLine("Login Failed");
                return false;
            }

        }
    }
}
