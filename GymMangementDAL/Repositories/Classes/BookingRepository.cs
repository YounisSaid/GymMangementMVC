
using GymMangementDAL.Contexts;
using GymMangementDAL.Entities;
using GymMangementDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymMangementDAL.Repositories.Classes
{
	public class BookingRepository : GenericRepository<Booking>, IBookingRepository
	{
		private readonly GymDbContext _dbContext;

		public BookingRepository(GymDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Booking> GetBySessionId(int sessionId)
		{
			return _dbContext.Bookings.Include(X => X.Member)
									  .Where(X => X.SessionId == sessionId).ToList();
		}

	}
}
