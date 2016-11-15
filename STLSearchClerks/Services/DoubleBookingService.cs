using STLSearchClerks.Models;
using STLSearchClerks.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STLSearchClerks.Services
{
    public class DoubleBookingService : IDoubleBookingService
    {
        private IDoubleBookingRepository _doubleBookingRepository;

        public DoubleBookingService()
        {
            _doubleBookingRepository = new DoubleBookingRepository();
        }

        public DoubleBookingService(IDoubleBookingRepository doubleBookingRepository)
        {
            _doubleBookingRepository = doubleBookingRepository;
        }

        public DoubleBooking Add(DoubleBooking doubleBooking)
        {
            var addedBooking = _doubleBookingRepository.Add(doubleBooking);
            _doubleBookingRepository.Save();

            return addedBooking;
        }

        public IList<DoubleBooking> GetDoubleBookingsFromLastMonth()
        {
            return _doubleBookingRepository.GetDoubleBookingsFromLastMonth();
        }
    }
}