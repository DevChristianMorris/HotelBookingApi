using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelBookingApi.Models;
using HotelBookingApi.Data;

namespace HotelBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {

        private readonly ApiContext _context;

        public HotelBookingController(ApiContext context)
        {
            _context = context;
        }

        //POST: api/HotelBooking/CreateEdit

        [HttpPost]
        public JsonResult CreateEdit(HotelBooking booking)
        {
            if (booking.Id == 0)
            {
                _context.Bookings.Add(booking);
            }
            else
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);

                if (bookingInDb == null)
                if (bookingInDb == null)
                    return new JsonResult(NotFound("Booking not found"));


                  bookingInDb = booking;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(booking));
        }

        //Get       api/HotelBooking/GetAll

        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Bookings.Find(id);
            if (result == null)
                return new JsonResult(NotFound("Booking not found"));
            return new JsonResult(Ok(result));
        }

        // Delete   api/HotelBooking/Delete

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Bookings.Find(id);
            if (result == null)
                return new JsonResult(NotFound("Booking not found"));
            _context.Bookings.Remove(result);
            _context.SaveChanges();
            return new JsonResult(Ok("Booking deleted"));
        }

    }
}
