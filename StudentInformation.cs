using System;
using System.IO;

namespace StudentDatabase
{
    public class Student
    {
        public static void AddRecord(string ID, string name, string email, string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = new StreamWriter(File.Create(filePath))) //If file doesn't exists, create new file
                {
                    sw.WriteLine(ID + "," + name + "," + email);
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter w = File.AppendText(filePath)) //If file exists, append
                {
                    w.WriteLine(ID + "," + name + "," + email);
                    w.Close();
                }
            }

        }

        public static string[] FindRecord(string searchTerm, string filePath, int indexOfSearchField)
        {
            string[] recordNotFound = { "Record not found" };
            string[] lines = File.ReadAllLines(filePath);



            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                if (RecordMatches(searchTerm, fields, indexOfSearchField))
                {
                    Console.WriteLine("Record Found");
                    Console.WriteLine("ID, Name, Email");
                    return fields;
                }
            }

            return recordNotFound;
        }

        public static bool RecordMatches(string searchTerm, string[] record, int indexOfSearchField)
        {
            if (record[indexOfSearchField].Equals(searchTerm))
            {
                return true;
            }
            return false;
        }

        public static void DeleteRecord(string searchTerm, string filePath, int indexOfSearchField)
        {
            string tempFile = @"student_information.csv";
            
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');

                if (!(RecordMatches(searchTerm, fields, indexOfSearchField)))
                {
                    AddRecord(fields[0], fields[1], fields[2], tempFile);
                }
                else
                {
                    Console.WriteLine("Record Deleted");
                }
            }

            File.Delete(filePath); //delete old file
            File.Move(tempFile, filePath);
        }

        public static void EditRecord(string searchTerm, string filePath, int indexOfSearchField)
        {
            string tempFile = @"student_information.csv";
            
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');

                if (!(RecordMatches(searchTerm, fields, indexOfSearchField)))
                {
                    AddRecord(fields[0], fields[1], fields[2], tempFile);
                }
                else
                {
                    Console.WriteLine("Please enter the edited information");
                    Console.WriteLine("New ID");
                    string editID = Console.ReadLine();
                    Console.WriteLine("New Name");
                    string editName = Console.ReadLine();
                    Console.WriteLine("New Email");
                    string editEmail = Console.ReadLine();

                    AddRecord(editID, editName, editEmail, tempFile);
                    Console.WriteLine("Record Edited");
                }
            }

            File.Delete(filePath); //delete old file
            File.Move(tempFile, filePath);
        }
    }
}