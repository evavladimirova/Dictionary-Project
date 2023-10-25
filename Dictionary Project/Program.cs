//a. Create a dictionary to store student grades. Implement functions to add a new student, remove a student, and calculate the average grade.
//b. Given two dictionaries representing courses and their respective credit hours, create a new dictionary that calculates the total credit hours for each student.
//c. Write a program to find and display the duplicate elements in a dictionary.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Xml.Serialization;

//Project by Eva Vladimirova 12/A1
class Gradebook
{
    static Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();

    static void Main()
    {

        Boolean ProgramRunning = true;
        while (ProgramRunning)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Class Menu:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search for Student and grades");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. Display all students");
            Console.WriteLine("5. Calculate the avarage grade");
            Console.WriteLine("6. Find and Display Duplicates");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");


            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                {
                    addStudent();
                }

                if (choice == 2)
                {
                    SearchStudent();
                }
                if (choice == 3)
                {
                    DeleteStudent();
                }
                if (choice == 4)
                {
                    Display();
                }
                if (choice == 5)
                {
                    AvarageGrade();
                }
                if (choice == 6)
                {
                    Duplicates();
                }
                if (choice == 7)
                {
                    ProgramRunning = false;
                }
                if (choice > 7)
                {
                    Console.WriteLine("Enter a valid choice number");

                }

            }

        }
    }

    public static void addStudent()
    {
        Console.Write("Enter the name of the student: ");
        string name = Console.ReadLine();

        List<int> grades = new List<int>();

        bool addGrades = true;
        while (addGrades)
        {
            Console.Write("Enter a grade (or 'done' to finish entering grades): ");
            string grade = Console.ReadLine();

            if (grade.ToLower() == "done")
            {
                List<int> course = new List<int>();
                int credits = 0;
                Console.WriteLine("Choose a course for the student(or 'done to finish adding courses): ");
                Console.WriteLine("1. Math");
                Console.WriteLine("2. Engish");
                Console.WriteLine("3. Chemistry");
                Console.WriteLine("4. Biology");
                Console.WriteLine("5. Computer Science");
                Console.WriteLine("6. History");
                Console.WriteLine("7. Geography");
                Console.WriteLine("8. Art");
                Console.WriteLine("9. Bulgarian");
                Console.WriteLine("10. Physics");

                bool addCourse = true;
                while (addCourse)
                {
                   
                    string n = Console.ReadLine();
                    if (n.ToLower() == "done")
                    {
                        Console.WriteLine($"The total number of credits for this student is: {credits}");
                        addCourse = false;
                        addGrades = false;
                    }
                    else if(n != " ")
                    {
                        Console.WriteLine("Choose a course for the student(or 'done to finish adding courses): ");
                        
                        if (n == "1")
                        {
                            credits += 5;
                        }

                        if (n == "2")
                        {
                            credits += 5;
                        }
                        if (n == "3")
                        {
                            credits += 5;
                        }
                        if (n == "4")
                        {
                            credits += 5;
                        }
                        if (n == "5")
                        {
                            credits += 5;
                        }
                        if (n == "6")
                        {
                            credits += 5;
                        }
                        if (n == "7")
                        {
                            credits += 5;
                        }
                        if (n == "8")
                        {
                            credits += 5;
                        }
                        if (n == "9")
                        {
                            credits += 5;
                        }
                        if (n == "10")
                        {
                            credits += 5;
                        }


                    }



                }
               
            }
            else if (int.TryParse(grade, out int i))
            {
                grades.Add(i);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric grade.");
            }
        }

        if (!students.ContainsKey(name))
        {
            students[name] = grades;
            Console.WriteLine("Added successfully.");
        }
        else
        {
            Console.WriteLine("Student already exists. Use the update option to modify the student.");
        }
    }
    public static void SearchStudent()
    {
        Console.Write("Enter the name to search: ");
        string name = Console.ReadLine();

        if (students.ContainsKey(name))
        {
            Console.WriteLine($"Name: {name} Grades: {string.Join(", ", students[name])}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

    }

    public static void DeleteStudent()
    {
        Console.Write("Enter the name to delete: ");
        string name = Console.ReadLine();

        if (students.ContainsKey(name))
        {
            students.Remove(name);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public static void Display()
    {
        Console.WriteLine();

        Console.WriteLine("The glorious classbook");
        Console.WriteLine();
        foreach (var kvp in students)
        {

            Console.WriteLine($"Name: {kvp.Key}  Grades: {string.Join(", ", kvp.Value)}  Credits: {kvp.Value}");
        }
    }
    public static void AvarageGrade()
    {
        double sum = 0;
        int count = 0;

        foreach (var kvp in students)
        {
            sum += kvp.Value.Average();
            count++;
        }

        double average = sum / count;
        Console.WriteLine($"The average grade is {average:F2}");
    }

    public static void Duplicates()
    {
        Dictionary<int, List<string>> duplicateGrades = new Dictionary<int, List<string>>();

        foreach (var student in students)
        {
            string studentName = student.Key;
            List<int> grades = student.Value;

            foreach (var grade in grades)
            {
                if (!duplicateGrades.ContainsKey(grade))
                {
                    duplicateGrades[grade] = new List<string>();
                }

                duplicateGrades[grade].Add(studentName);
            }
        }

        Console.WriteLine("Duplicate Grades:");
        foreach (var gradePair in duplicateGrades)
        {
            if (gradePair.Value.Count > 1)
            {
                Console.WriteLine($"Grade {gradePair.Key}: Students {string.Join(", ", gradePair.Value)}");
            }
        }
    }
}


