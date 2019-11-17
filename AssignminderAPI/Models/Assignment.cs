using System;
namespace AssignminderAPI.Models
{
    public class Assignment
    {
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
