using STLSearchClerks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STLSearchClerks.Repositories
{
    public interface IDoubleBookingRepository
    {
        DoubleBooking Add(DoubleBooking doubleBooking);
        IList<DoubleBooking> GetDoubleBookingsFromLastMonth();
        void Save();
    }
}
