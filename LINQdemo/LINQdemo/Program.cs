using System;
using System.Collections;
using System.Linq;

namespace LINQdemo
{
    // Student class with Name, Age, and Grade properties
    class Student : IComparable<Student>
    {
        // getter/setter for Name, Age, and Grade
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }

        // Student constructor
        public Student(string name, int age, int grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }

        // method used to sort the list
        public int CompareTo(Student other)
        {
            return string.Compare(Name, other.Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // make some test scores
            var scores = new[] { 50, 66, 90, 81, 77, 45, 0, 100, 99, 72, 87, 85, 81, 80, 77, 74, 95, 97 };

            // print scores
            foreach (var individualScore in scores)
            {
                Console.WriteLine("One of the scores was {0}", individualScore);
            }

            //pause to see the output before closing
            Console.ReadLine();

            // use a LINQ statement to filter the list.
            var theBestStudents = 
                from individualScore in scores
                where individualScore > 90
                select individualScore;

            // print only the best scores
            foreach (var individualScore in theBestStudents)
            {
                Console.WriteLine("One of the BEST scores was {0}", individualScore);
            }

            // pause to see the output before closing
            Console.ReadLine();

            // use LINQ to sort the results
            var sortedScores = 
                from individualScore in scores
                orderby individualScore
                select individualScore;

            //print the sorted list
            foreach (var individualScore in sortedScores)
            {
                Console.WriteLine("One of the scores was {0}", individualScore);
            }

            // pause to see the output before closing
            Console.ReadLine();

            // use LINQ to filter and sort the results for B students (80% to 89%)
            var bStudents =
                from individualScore in scores
                where individualScore >= 80 && individualScore <= 89
                orderby individualScore ascending
                select individualScore;

            // print the B students' scores
            foreach (var individualScore in bStudents)
            {
                Console.WriteLine("One of the B students scores was {0}", individualScore);
            }

            // pause to see the output before closing
            Console.ReadLine();

            // Create an ArrayList of Student objects
            ArrayList students = new ArrayList();
            students.Add(new Student("Alice", 20, 91));
            students.Add(new Student("Bob", 18, 85));
            students.Add(new Student("Charlie", 19, 87));
            students.Add(new Student("Dave", 22, 78));
            students.Add(new Student("Eve", 21, 94));

            // Use LINQ to filter and sort the list of students
            var filteredStudents =
                from Student student in students
                where student.Grade >= 80 && student.Grade <= 89 && student.Age >= 18
                orderby student.Name ascending
                select student;

            // Print the filtered and sorted list of students
            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
            }

            // Pause to see the output before closing
            Console.ReadLine();
        }
    }
}
