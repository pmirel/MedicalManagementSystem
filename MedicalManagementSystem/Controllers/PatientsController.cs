using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalManagementSystem.Models;
using MedicalManagementSystem.ViewModel;

namespace MedicalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly MMSDbContext _context;

        public PatientsController(MMSDbContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        /// <summary>
        /// Get a list of patients
        /// </summary>
        /// <param name="order">order by lastname ascending or descending</param>
        /// <returns>List of patients</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients(
            [FromQuery] string? order = null)
        {
            IQueryable<Patient> result = _context.Patients;
            if (order != null)
            {
                if (order == "asc")
                {
                    result = result.OrderBy(f => f.LastName);
                }
                if (order == "desc")
                {
                    result = result.OrderByDescending(f => f.LastName);
                }
            }
            

            var resultList = await result
                .ToListAsync();
            return resultList;
        }

        // GET: api/Patients/5
        /// <summary>
        /// get a specific patients
        /// </summary>
        /// <param name="id">id of pacient</param>
        /// <returns>A specific patient with a list of prescriptions</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDetail>> GetPatient(long id)
        {
            var patient = await _context
                .Patients
                .Include(f => f.Prescriptions)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return PatientDetail.FromPatient(patient);
        }

        // PUT: api/Patients/5
        /// <summary>
        /// Edit a specific patient
        /// </summary>
        /// <param name="id">id of patient</param>
        /// <param name="patient">Name of patient</param>
        /// <returns>edited patient</returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(long id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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

        // POST: api/Patients
        /// <summary>
        /// Create a patient object
        /// </summary>
        /// <remarks>
        /// 
        ///      "id": 0,
        ///     "firstName": "string",
        ///     "lastName": "string",
        ///     "cnp": "string",
        ///     "adress": "string",
        ///     "email": "string",
        ///     "doctorId": 0
        ///
        /// </remarks>
        /// <param name="patient">name of patient</param>
        /// <returns>Created object</returns>
        /// <response code="201">Returns the newly created item, FirstName and LastName must have between 2 and 10 letters and cannot be empty CNP must have 13 numbers</response>
        /// <response code="400">If the item is null</response>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        /// <summary>
        /// Delete a specific object
        /// </summary>
        /// <param name="id">id of deleted object</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(long id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        private bool PatientExists(long id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
