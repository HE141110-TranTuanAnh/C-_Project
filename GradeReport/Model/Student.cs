using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeReport.Model
{
    class Student
    {
        public string Roll { get; set; }
        public string Name { get; set; }
        public Student(string roll, string name)
        {
            Roll = roll;
            Name = name;
        }
    }
}
