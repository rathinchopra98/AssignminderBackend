using System;
using System.ComponentModel.DataAnnotations;

namespace AssignminderAPI.Models
{
    public class Assignment
    {
        [Key]
        public string Name { get; set; }
        public string CourseID { get; set; }


        public float Grade { get; set; }
        public DateTimeOffset dueDate { get; set; }
        public DateTimeOffset Reminder { get; set; }

        public Assignment()
        {
        }
    }
}
