using System;
using System.Collections.Generic;
using System.Linq;
using AssignminderAPI.Models;

namespace AssignminderAPI.Controllers
{
    public class AssignmentPrioritization
    {
        List<Assignment> assignments;

        public AssignmentPrioritization(List<Assignment> assignments)
        {
            this.assignments = assignments;  
        }

        public List<Assignment> GetPriorityAssignmentList()
        {
            List<Assignment> finalAssignments = new List<Assignment>();

            List<string> courseIds = new List<string>();
            foreach (var item in assignments) {
                courseIds.Add(item.CourseID);
            }

            courseIds = courseIds.Distinct().ToList();

            for(int i = 0; i < courseIds.Count(); i++)
            {
                var assignmentsTemp = assignments.Where(x => x.CourseID == courseIds[i]).ToList();
                assignmentsTemp = assignmentsTemp.OrderByDescending(o => o.weightage).ToList();

                for(int j = 0; j < assignmentsTemp.Count(); j++)
                {
                    assignmentsTemp[j].priorityKey = j;
                    finalAssignments.Add(assignmentsTemp[j]);
                }

            }

            return finalAssignments;
        }
    }
}
