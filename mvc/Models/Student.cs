using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public Student(int studentid, string studentname, int age)
        {
            this.StudentID = studentid;
            this.StudentName = studentname;
            this.Age = age;
        }
    }
}