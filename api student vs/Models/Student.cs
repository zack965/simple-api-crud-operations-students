using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_student_vs.Models
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }
        public string Student_Name { get; set; }
        public int Student_Age { get; set; }
        
    }
}
