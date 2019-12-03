using System;
using System.ComponentModel.DataAnnotations;

namespace AssignminderAPI.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseID { get; set; }
        public string UserID { get; set; }
        public float Grade { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime Reminder { get; set; }

        public Assignment()
        {
        }
    }
}
