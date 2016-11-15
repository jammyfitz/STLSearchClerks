using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using STLSearchClerks.Controllers;
using STLSearchClerks.Models;
using STLSearchClerks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace STLSearchClerksShould.Controllers
{
    [TestFixture]
    public class DoubleBookingsControllerShould
    {
        private DoubleBookingsController _doubleBookingsController;
        private IDoubleBookingService _doubleBookingsService;

        [SetUp]
        public void Setup()
        {
            _doubleBookingsService = Substitute.For<IDoubleBookingService>();
            _doubleBookingsController = new DoubleBookingsController(_doubleBookingsService);
        }

        [Test]
        public void SupportPostDoubleBooking()
        {
            var doubleBooking = new DoubleBooking()
            {
                AuthorityId = 2,
                BookingDate = DateTime.MinValue,
                SearchClerkId = 3
            };

            _doubleBookingsService.Add(doubleBooking).Returns(doubleBooking);

            var response = _doubleBookingsController.PostDoubleBooking(doubleBooking);
            var contentResult = response as CreatedAtRouteNegotiatedContentResult<DoubleBooking>;

            contentResult.Content.Should().NotBeNull();
            contentResult.Content.AuthorityId.Should().Be(2);
            contentResult.Content.BookingDate.Should().Be(DateTime.MinValue);
            contentResult.Content.SearchClerkId.Should().Be(3);
        }

        [Test]
        public void SupportGetDoubleBookingsFromLastMonth()
        {
            var expectedDoubleBookings = GetTestDoubleBookings();
            _doubleBookingsService.GetDoubleBookingsFromLastMonth().Returns(expectedDoubleBookings);

            var response = _doubleBookingsController.GetDoubleBookingsFromLastMonth();
            var contentResult = response as OkNegotiatedContentResult<IList<DoubleBooking>>;

            contentResult.Content.Should().NotBeNull();

        }

        private IList<DoubleBooking> GetTestDoubleBookings()
        {
            return new List<DoubleBooking>()
            {
                new DoubleBooking()
                {
                    AuthorityId = 1,
                    BookingDate = new DateTime(2016, 11, 14),
                    SearchClerkId = 1,
                    DoubleBookingId = 1
                },
                new DoubleBooking()
                {
                    AuthorityId = 2,
                    BookingDate = new DateTime(2016, 11, 15),
                    SearchClerkId = 2,
                    DoubleBookingId = 2
                }
            };
        }
    }
}
