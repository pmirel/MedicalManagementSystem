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
    public class BookingsController : ControllerBase
    {
        private readonly MMSDbContext _context;

        public BookingsController(MMSDbContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        /// <summary>
        /// Get a list of all bookings
        /// </summary>
        /// <param name="from">date from</param>
        /// <param name="to">date to</param>
        /// <returns>a list of booking</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking(
            [FromQuery] DateTimeOffset? from = null,
            [FromQuery] DateTimeOffset? to = null)
        {
            IQueryable<Booking> result = _context.Booking;
            if (from != null)
            {
                result = result.Where(f => from <= f.DateOfBooking);
            }
            if (to != null)
            {
                result = result.Where(f => f.DateOfBooking <= to);
            }

            var resultList = await result
                .ToListAsync();
            return resultList;
        }

        // GET: api/Bookings/5
        /// <summary>
        /// Get a specific booking
        /// </summary>
        /// <param name="id">id of booking</param>
        /// <returns>a booking object</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(long id)
        {
            var booking = await _context.Booking.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

        // PUT: api/Bookings/5
        /// <summary>
        /// Edit a specific booking
        /// </summary>
        /// <param name="id">id of booking</param>
        /// <param name="booking"></param>
        /// <returns></returns>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(long id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/Bookings
        /// <summary>
        /// Create a booking
        /// </summary>
        /// <param name="booking"></param>
        /// <returns>created object</returns>
        /// <response code="201">Returns the newly created item, date of booking must be grather than today</response>
        /// <response code="400">If the item is null</response>
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
        }

        // DELETE: api/Bookings/5
        /// <summary>
        /// Delete a specific booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns>nothing</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Booking>> DeleteBooking(long id)
        {
            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();

            return booking;
        }

        private bool BookingExists(long id)
        {
            return _context.Booking.Any(e => e.Id == id);
        }
    }
}
