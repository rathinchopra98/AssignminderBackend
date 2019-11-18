using System;
using System.ComponentModel.DataAnnotations;

namespace AssignminderAPI.Models
{
    public class Course
    {
        [Key]
        public string ID { get; set; }


        public string Name { get; set; }
        public float Grade { get; set; }
        public Course()
        {
        }
    }
}
