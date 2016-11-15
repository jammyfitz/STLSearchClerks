using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using STLSearchClerks.Models;
using STLSearchClerks.Repositories;
using STLSearchClerks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STLSearchClerksShould.Services
{
    [TestFixture]
    public class DoubleBookingServiceShould
    {
        private IDoubleBookingRepository _doubleBookingsRepository;
        private DoubleBookingService _doubleBookingsService;

        [SetUp]
        public void Setup()
        {
            _doubleBookingsRepository = Substitute.For<IDoubleBookingRepository>();
            _doubleBookingsService = new DoubleBookingService(_doubleBookingsRepository);
        }

        [Test]
        public void SaveDoubleBookingToRepositoryWhenAdded()
        {
            var doubleBooking = GetTestDoubleBooking();

            _doubleBookingsRepository.Add(doubleBooking).Returns(doubleBooking);

            _doubleBookingsService.Add(doubleBooking);

            _doubleBookingsRepository.Received().Save();
        }

        [Test]
        public void ReturnDoubleBookingWhenAdded()
        {
            DoubleBooking doubleBooking = GetTestDoubleBooking();

            _doubleBookingsRepository.Add(doubleBooking).Returns(doubleBooking);

            var result = _doubleBookingsService.Add(doubleBooking);

            result.Should().NotBeNull();
            result.AuthorityId.Should().Be(2);
            result.BookingDate.Should().Be(DateTime.MinValue);
            result.SearchClerkId.Should().Be(3);
        }

        [Test]
        public void ReturnDoubleBookingsFromLastMonth()
        {
            IList<DoubleBooking> doubleBookings = GetTestDoubleBookings();

            _doubleBookingsRepository.GetDoubleBookingsFromLastMonth().Returns(doubleBookings);

            var result = _doubleBookingsService.GetDoubleBookingsFromLastMonth();

            result.Should().NotBeNull();
            result.Count().Should().Be(2);
            result.First().AuthorityId.Should().Be(3);
            result.Last().SearchClerkId.Should().Be(4);
        }

        private static DoubleBooking GetTestDoubleBooking()
        {
            return new DoubleBooking()
            {
                AuthorityId = 2,
                BookingDate = DateTime.MinValue,
                SearchClerkId = 3
            };
        }

        private static IList<DoubleBooking> GetTestDoubleBookings()
        {
            return new List<DoubleBooking>()
            {
                new DoubleBooking()
                {
                    AuthorityId = 3,
                    BookingDate = new DateTime(2016, 11, 15),
                    SearchClerkId = 3
                },
                new DoubleBooking()
                {
                    AuthorityId = 4,
                    BookingDate = new DateTime(2016, 11, 16),
                    SearchClerkId = 4
                },
            };
        }
    }
}
