using STLSearchClerks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STLSearchClerks.Repositories
{
    public class DoubleBookingRepository : IDoubleBookingRepository
    {
        private STLDatabaseEntities _stlContext;

        public DoubleBookingRepository()
        {
            _stlContext = new STLDatabaseEntities();
        }

        public DoubleBookingRepository(STLDatabaseEntities stlContext)
        {
            _stlContext = stlContext;
        }

        public IList<DoubleBooking> GetDoubleBookingsFromLastMonth()
        {
            var lastMonth = DateTime.Now.AddMonths(-1);

            return GetDoubleBookingsFrom(lastMonth);
        }

        public DoubleBooking Add(DoubleBooking doubleBooking)
        {
            return _stlContext.DoubleBookings.Add(doubleBooking);
        }

        public void Save()
        {
            _stlContext.SaveChanges();
        }

        private IList<DoubleBooking> GetDoubleBookingsFrom(DateTime dateTime)
        {
            return _stlContext.DoubleBookings.Where(x => x.BookingDate >= dateTime).ToList();
        }
    }
}