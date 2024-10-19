using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingReservationService
    {
        private static BookingReservationService instance;
        private BookingReservationService() { }
        public static BookingReservationService GetInstance()
        {
            if (instance == null)
            {
                instance = new BookingReservationService();
            }
            return instance;
        }

        private UnitOfWork unitOfWork = new UnitOfWork();

        public List<BookingReservation> GetBookingReservations(int userId) => this.unitOfWork.BookingReservationRepository.Get(item => item.CustomerId.Equals(userId)).ToList();

        public List<BookingReservation> GetAllBookingReservations() => this.unitOfWork.BookingReservationRepository.Get().ToList();
    }
}
