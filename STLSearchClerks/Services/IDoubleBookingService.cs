using STLSearchClerks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STLSearchClerks.Services
{
    public interface IDoubleBookingService
    {
        IList<DoubleBooking> GetDoubleBookingsFromLastMonth();
        DoubleBooking Add(DoubleBooking doubleBooking);
    }
}
