using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalManagementSystem.Models;

namespace MedicalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly MMSDbContext _context;

        public PrescriptionsController(MMSDbContext context)
        {
            _context = context;
        }

        // GET: api/Prescriptions
        /// <summary>
        /// Get a list of all prescriptions
        /// </summary>
        /// <param name="from">from the date added</param>
        /// <param name="to">to the date added</param>
        /// <returns>A list of prescriptions</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescription(
            [FromQuery] DateTimeOffset? from = null,
            [FromQuery] DateTimeOffset? to = null)
        {
            IQueryable<Prescription> result = _context.Prescription;
            if (from != null)
            {
                result = result.Where(f => from <= f.DateAdded);
            }
            if (to != null)
            {
                result = result.Where(f => f.DateAdded <= to);
            }

            var resultList = await result
                .ToListAsync();
            return resultList;


        }

        // GET: api/Prescriptions/5
        /// <summary>
        /// Get a specific Prescription object
        /// </summary>
        /// <param name="id">id of a specific object</param>
        /// <returns>A specific object</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Prescription>> GetPrescription(long id)
        {
            var prescription = await _context.Prescription.FindAsync(id);

            if (prescription == null)
            {
                return NotFound();
            }

            return prescription;
        }

        // PUT: api/Prescriptions/5
        /// <summary>
        /// Edit a specific object
        /// </summary>
        /// <param name="id">id of edited object</param>
        /// <param name="prescription"></param>
        /// <returns>A specific object</returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescription(long id, Prescription prescription)
        {
            if (id != prescription.Id)
            {
                return BadRequest();
            }

            _context.Entry(prescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescriptionExists(id))
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

        // POST: api/Prescriptions
        /// <summary>
        /// Create a Prescription object
        /// </summary>
        ///<remarks>
        /// 
        /// "id": 0,
        /// "diagnosis": "string",
        /// "description": "string",
        /// "dateAdded": "2020-07-02T20:54:00.563Z",
        /// "price": 0,
        /// "patientId": 0
        ///
        /// </remarks>
        /// <param name="prescription"></param>
        /// <returns>Credted object</returns>
        /// /// <response code="201">Returns the newly created item, date must be higher than today</response>
        /// <response code="400">If the item is null</response>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Prescription>> PostPrescription(Prescription prescription)
        {
            _context.Prescription.Add(prescription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrescription", new { id = prescription.Id }, prescription);
        }

        // DELETE: api/Prescriptions/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prescription>> DeletePrescription(long id)
        {
            var prescription = await _context.Prescription.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }

            _context.Prescription.Remove(prescription);
            await _context.SaveChangesAsync();

            return prescription;
        }

        private bool PrescriptionExists(long id)
        {
            return _context.Prescription.Any(e => e.Id == id);
        }
    }
}
