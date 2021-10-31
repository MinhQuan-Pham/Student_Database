using System;
using System.IO;

namespace StudentDatabase
{
    public class Student
    {
        public static void addRecord(string ID, string name, string email,string filePath)
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

        public static string[] findRecord(string searchTerm, string filePath, int indexOfSearchField)
        {
            string[] recordNotFound = { "Record not found" };
            string[] lines = File.ReadAllLines(filePath);

            

            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                if(recordMatches(searchTerm, fields, indexOfSearchField))
                {
                    Console.WriteLine("Record Found");
                    Console.WriteLine("ID, Name, Email, Course 1, Mark 1, Course 2, Mark 2");
                    return fields;
                }
            }

            return recordNotFound;
        }

        public static bool recordMatches(string searchTerm, string[] record, int indexOfSearchField)
        {
            if(record[indexOfSearchField].Equals(searchTerm))
            {
                return true;
            }
            return false;
        }

        public static void deleteRecord(string searchTerm, string filePath, int indexOfSearchField)
        {
            string tempFile = @"student_information.csv";
            bool deleted = false;

            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');

                if (!(recordMatches(searchTerm, fields, indexOfSearchField)) || deleted)
                {
                    addRecord(fields[0], fields[1], fields[2],tempFile);
                }
                else
                {
                    deleted = true;
                    Console.WriteLine("Record Deleted");
                }
            }

            File.Delete(filePath);
            File.Move(tempFile, filePath);
        }

        public static void editRecord(string searchTerm, string filePath, int indexOfSearchField, string field1, string field2, string field3)
        {
            string tempFile = @"student_information.csv";
            bool edited = false;

            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');

                if (!(recordMatches(searchTerm, fields, indexOfSearchField)))
                {
                    addRecord(fields[0], fields[1], fields[2], tempFile);
                }
                else
                {
                    if(!edited)
                    {
                        addRecord(field1, field2, field3, tempFile);
                        edited = true;
                        Console.WriteLine("Record Deleted");
                    }
                    
                }
            }

            File.Delete(filePath); //delete old file
            File.Move(tempFile, filePath);
            Console.WriteLine("Record Edited");
        }
    }
}
