using System;

namespace StudentDatabase
{
    class Program
    {
        static void Main(string[] args)
        {

            // Login Starts
            bool loginSuccess = false;
            Console.WriteLine("'login' or 'sign up'");
            string userAnswer = Console.ReadLine();
            if (userAnswer == "sign up")
            {
                User.SignUp();
                if (User.Login() == true)
                {
                    loginSuccess = true;
                }
                else
                {
                    loginSuccess = false;
                }
            }
            else if (userAnswer == "login")
            {
                if (User.Login() == true)
                {
                    loginSuccess = true;
                }
                else
                {
                    loginSuccess = false;
                }
            }
            else
            {
                Console.WriteLine("Program Ended. Thank you");
            }
            // Login Ends

            if (loginSuccess == true)
            {
                // Student Information 
                string filePath = @"/Users/mike/Projects/StudentDatabase/student_informartion.csv";

                Console.WriteLine("Choose the action you want to perform: 'a', 'f', 'e', 'd' to add, find, edit, and delete Student Information respectively");
                Console.WriteLine("Otherwise, press anykey to quit the program");

                char userSelection = Convert.ToChar(Console.ReadLine());

                while (userSelection == 'a' || userSelection == 'f' || userSelection == 'e' || userSelection == 'd')
                {
                    if (userSelection == 'a')
                    {
                        Console.WriteLine("--- Adding Student Record ---"); // Add record
                        char addMore = 'y';
                        while (addMore == 'y')
                        {
                            Console.WriteLine("Please enter student information: ");
                            Console.WriteLine("ID, Name, Email");
                            string ID = Console.ReadLine();
                            string name = Console.ReadLine();
                            string email = Console.ReadLine();
                            Student.AddRecord(ID, name, email, filePath);
                            Console.WriteLine("Enter 'y' to add another student record, press any other key to finish adding ");
                            addMore = Convert.ToChar(Console.ReadLine());
                        }

                        Console.WriteLine("Choose the action you want to perform: 'a', 'f', 'e', 'd' to add, find, edit, and delete Student Information respectively");
                        Console.WriteLine("Otherwise, press anykey to quit the program");
                        userSelection = Convert.ToChar(Console.ReadLine());
                    }
                    else if (userSelection == 'f') // Find Record
                    {
                        Console.WriteLine("--- Finding Student Record ---");

                        char findMore = 'y';
                        while (findMore == 'y')
                        {
                            Console.WriteLine("Please enter the student ID you want to find");
                            string ID = Console.ReadLine();
                            Console.WriteLine(string.Join(",", Student.FindRecord(ID, filePath, 0)));
                            Console.WriteLine("Enter 'y' to find another student record, press any other key to finish finding ");
                            findMore = Convert.ToChar(Console.ReadLine());
                        }

                        Console.WriteLine("Choose the action you want to perform: 'a', 'f', 'e', 'd' to add, find, edit, and delete Student Information respectively");
                        Console.WriteLine("Otherwise, press anykey to quit the program");
                        userSelection = Convert.ToChar(Console.ReadLine());

                    }
                    else if (userSelection == 'e')
                    {
                        Console.WriteLine("--- Editing Student Record ---"); // Edit Record
                        char editMore = 'y';
                        while (editMore == 'y')
                        {
                            Console.WriteLine("Please enter the student ID you want to edit");
                            string ID = Console.ReadLine();
                            //display finding result
                            Console.WriteLine(string.Join(",", Student.FindRecord(ID, filePath, 0)));

                            Student.EditRecord(ID, filePath, 0);
                            Console.WriteLine("Enter 'y' to edit another student record, press any other key to finish editing ");
                            editMore = Convert.ToChar(Console.ReadLine());
                        }

                        Console.WriteLine("Choose the action you want to perform: 'a', 'f', 'e', 'd' to add, find, edit, and delete Student Information respectively");
                        Console.WriteLine("Otherwise, press anykey to quit the program");
                        userSelection = Convert.ToChar(Console.ReadLine());
                    }
                    else if ((userSelection == 'd')) // Delete Record
                    {
                        Console.WriteLine("--- Deleting Student Record ---"); // Edit Record
                        char deleteMore = 'y';
                        while (deleteMore == 'y')
                        {
                            Console.WriteLine("Please enter the student ID you want to delete");
                            string ID = Console.ReadLine();
                            //display finding result
                            Console.WriteLine(string.Join(",", Student.FindRecord(ID, filePath, 0)));

                            Student.DeleteRecord(ID, filePath, 0);
                            Console.WriteLine("Enter 'y' to delete another student record, press any other key to finish deleting ");
                            deleteMore = Convert.ToChar(Console.ReadLine());
                        }

                        Console.WriteLine("Choose the action you want to perform: 'a', 'f', 'e', 'd' to add, find, edit, and delete Student Information respectively");
                        Console.WriteLine("Otherwise, press anykey to quit the program");
                        userSelection = Convert.ToChar(Console.ReadLine());
                    }
                    else
                    {
                        userSelection = 'q';
                    }
                }
                Console.WriteLine("Thank you");
                // Student Information Done
            }
        }
    }
}
