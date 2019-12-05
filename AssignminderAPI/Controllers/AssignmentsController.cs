using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssignminderAPI.Models;

namespace AssignminderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly AssignmentContext _context;

        public AssignmentsController(AssignmentContext context)
        {
            _context = context;
        }

        // GET: api/Assignments
        [HttpGet]
        public ActionResult<IEnumerable<Assignment>> GetAssignments()
        {
            AssignmentPrioritization assignmentPrioritization = new AssignmentPrioritization(_context.Assignments.ToList());
            var result = assignmentPrioritization.GetPriorityAssignmentList();
            return result;
        }

        // GET: api/Assignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignment(string id)
        {
            var assignment = await _context.Assignments.Where(x => x.UserID == id).ToListAsync();

            if (assignment == null)
            {
                return NotFound();
            }

            return assignment;
        }

        // PUT: api/Assignments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment(string id, Assignment assignment)
        {
            if (id != assignment.Name)
            {
                return BadRequest();
            }

            _context.Entry(assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Assignments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Assignment>>> PostAssignment(IEnumerable<Assignment> assignments)
        {
            foreach (var item in assignments) {
                _context.Assignments.Add(item);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (AssignmentExists(item.Name))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return CreatedAtAction("GetAssignment", assignments);
        }

        // DELETE: api/Assignments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Assignment>> DeleteAssignment(string id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return assignment;
        }

        private bool AssignmentExists(string id)
        {
            return _context.Assignments.Any(e => e.Name == id);
        }
    }
}
