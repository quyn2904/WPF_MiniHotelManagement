using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork : IDisposable
    {
        private FuminiHotelManagementContext _context = new FuminiHotelManagementContext();
        private CustomerRepository _customerRepository;
        private GenericRepository<BookingReservation> _bookingReservationRepository;
        private GenericRepository<RoomInformation> _roomInformationRepository;

        public CustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_context);
                }
                return _customerRepository;
            }
        }

        public GenericRepository<BookingReservation> BookingReservationRepository
        {
            get
            {
                if (_bookingReservationRepository == null)
                {
                    _bookingReservationRepository = new GenericRepository<BookingReservation>(_context);
                }
                return _bookingReservationRepository;
            }
        }

        public GenericRepository<RoomInformation> RoomInformationRepository
        {
            get
            {
                if (_roomInformationRepository == null)
                {
                    _roomInformationRepository = new GenericRepository<RoomInformation>(_context);
                }
                return _roomInformationRepository;
            }
        }

        public void SaveChanges() => _context.SaveChanges();

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
