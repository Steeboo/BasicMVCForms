using Forms.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.DataAccess
{
    public class StudentRepository
    {
        private static IList<Student> students = new List<Student>();

        public static IReadOnlyCollection<Student> Students
        {
            get { return new ReadOnlyCollection<Student>(students); }
        }

        internal static void AddStudent(Student student)
        {
            var id = Students.Any() ? Students.Max(x => x.Id) + 1 : 1;
            student.Id = id;
            students.Add(student);
        }

        internal static void ReplaceStudent(Student student)
        {
            var oldStudent = students.First(x => x.Id == student.Id);
            var index = students.IndexOf(oldStudent);
            students[index] = student;
        }
    }
}
