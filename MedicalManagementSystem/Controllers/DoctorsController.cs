using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalManagementSystem.Models;
using MedicalManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using MedicalManagementSystem.ViewModel.Collections;

namespace MedicalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly MMSDbContext _context;

        public DoctorsController(MMSDbContext context)
        {
            _context = context;
        }

        // GET: api/Doctors
        /// <summary>
        /// Get a list of all the doctors
        /// </summary>
        /// <param name="speciality">Specify this parameter for a list of doctors from a specific medical speciality</param>
        /// <param name="page">current page</param>
        /// <param name="itemsPerPage">number of items per page</param>
        /// <returns>A list of doctor objects</returns>
        [HttpGet]
        public async Task<ActionResult> GetDoctors(
            [FromQuery] Models.Speciality? speciality = null,
            [FromQuery] int page = 0,
            [FromQuery] int itemsPerPage = 5)
        {
            IQueryable<Doctor> result = _context.Doctors;
            if (speciality != null)
            {
                result = result.Where(f => f.Speciality == speciality);
            }
            var resultList = await result
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            var paginatedList = new PaginatedList<Doctor>(page, await result.CountAsync(), itemsPerPage);
            paginatedList.Items.AddRange(resultList);
            return Ok(paginatedList);
        }

        // GET: api/Doctors/5
        /// <summary>
        /// Get a detailed views of a specific doctor
        /// </summary>
        /// <param name="id">id of doctor object</param>
        /// <returns>A specific doctor object with a list of pacients</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDetail>> GetDoctor(long id)
        {
            var doctor = await _context
                .Doctors
                .Include(f => f.Patients)
                .FirstOrDefaultAsync(f => f.Id == id);


            if (doctor == null)
            {
                return NotFound();
            }

            return DoctorDetail.FromDoctor(doctor);
        }

        // PUT: api/Doctors/5
        /// <summary>
        /// Edit a specific doctor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="doctor">The name of a specific doctor</param>
        /// <returns>Edited Doctor</returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(long id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        // POST: api/Doctors
        /// <summary>
        /// Create a doctor object
        /// </summary>
        /// <remarks>
        /// {
        ///"id": 0,
        ///"firstName": "string",
        ///"lastName": "string",
        ///"speciality": "Other"
        ///}
        /// </remarks>
        /// <param name="doctor"></param>
        /// <returns>Created object</returns>
        /// <response code="201">Returns the newly created item, FirstName and LastName must have between 2 and 10 letters and cannot be empty</response>
        /// <response code="400">If the item is null</response>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        // DELETE: api/Doctors/5
        /// <summary>
        /// Delete a specific Doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Empty</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(long id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }

        private bool DoctorExists(long id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
