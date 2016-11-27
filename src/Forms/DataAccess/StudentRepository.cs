using Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.DataAccess
{
    public class StudentRepository
    {
        public static IList<Student> Students { get; set; } = new List<Student>();

        internal static int GenerateId()
        {
            if (Students.Any())
            {
                return Students.Max(x => x.Id) + 1;
            }
            return 1;
        }
    }
}
