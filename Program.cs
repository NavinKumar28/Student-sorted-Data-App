using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Student_Data_sort
{
   
    class Program
    {
        static void Main()
        {
            List<Student> students = ReadStudentData("C:\\Users\\Navin\\source\\repos\\students");

            
            students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.Ordinal));

            
            DisplayStudentData(students);

            Console.Write("Enter student name to search: ");
            string searchName = Console.ReadLine();
            SearchAndDisplayStudent(students, searchName);
        }

        static List<Student> ReadStudentData(string filePath)
        {
            List<Student> students = new List<Student>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] data = reader.ReadLine().Split(',').Select(s => s.Trim()).ToArray();
                        if (data.Length == 2)
                        {
                            students.Add(new Student { Name = data[0], Class = data[1] });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data: {ex.Message}");
            }

            return students;
        }

        static void DisplayStudentData(List<Student> students)
        {
            Console.WriteLine("Student Data (Sorted by Name):\n");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}, {student.Class}");
            }
            Console.WriteLine();
        }

        static void SearchAndDisplayStudent(List<Student> students, string searchName)
        {
            Student foundStudent = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (foundStudent != null)
            {
                Console.WriteLine($"\nStudent found: {foundStudent.Name}, {foundStudent.Class}");
            }
            else
            {
                Console.WriteLine("\nStudent not found.");
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }
}