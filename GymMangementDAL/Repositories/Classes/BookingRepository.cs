using GymMangementDAL.Contexts;
using GymMangementDAL.Entities;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Classes
{
    public class BookingRepository : IBookingRepository
    {
        private readonly GymDbContext _context;
        public BookingRepository(GymDbContext context)
        {
            _context = context;
        }
        public int Add(Booking booking)
        {
            _context.Add(booking);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var Booking = _context.Bookings.Find(id);
            if (Booking != null)
            {
                _context.Bookings.Remove(Booking);
                return _context.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<Booking> GetAll() => _context.Bookings.ToList();

        public Booking? GetByID(int id) => _context.Bookings.Find(id);

        public int Update(Booking booking)
        {
            _context.Update(booking);
            return _context.SaveChanges();
        }
    }
}
