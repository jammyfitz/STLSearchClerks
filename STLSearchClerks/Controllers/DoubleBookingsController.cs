using STLSearchClerks.Models;
using STLSearchClerks.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace STLSearchClerks.Controllers
{
    public class DoubleBookingsController : ApiController
    {
        private IDoubleBookingService _doubleBookingService;

        public DoubleBookingsController()
        {
            _doubleBookingService = new DoubleBookingService();
        }

        public DoubleBookingsController(IDoubleBookingService doubleBookingsService)
        {
            _doubleBookingService = doubleBookingsService;
        }

        // GET: api/DoubleBookings/GetDoubleBookingsFromLastMonth
        [ResponseType(typeof(IList<DoubleBooking>))]
        public IHttpActionResult GetDoubleBookingsFromLastMonth()
        {
            IList<DoubleBooking> doubleBookings = _doubleBookingService.GetDoubleBookingsFromLastMonth();
            if (doubleBookings == null)
            {
                return NotFound();
            }

            return Ok(doubleBookings);
        }

        // POST: api/DoubleBookings
        [ResponseType(typeof(DoubleBooking))]
        public IHttpActionResult PostDoubleBooking(DoubleBooking doubleBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _doubleBookingService.Add(doubleBooking);

            return CreatedAtRoute("DefaultApi", new { id = doubleBooking.DoubleBookingId }, doubleBooking);
        }
    }
}