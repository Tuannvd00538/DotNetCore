using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiinGroup.Models
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RollNumber { get; set; }
        public Student()
        {
        }
    }
}
