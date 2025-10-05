using GymMangementDAL.Contexts;
using GymMangementDAL.Entities;
using GymMangementDAL.Repositories.Interfaces;


namespace GymMangementDAL.Repositories.Classes
{
    public class SessionRepository : ISessionRepository
    {
        private readonly GymDbContext _context;
        public SessionRepository(GymDbContext context)
        {
            _context = context;
        }
        public int Add(Session session)
        {
            _context.Add(session);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var Session = _context.Sessions.Find(id);
            if (Session != null)
            {
                _context.Sessions.Remove(Session);
                return _context.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<Session> GetAll() => _context.Sessions.ToList();

        public Session? GetByID(int id) => _context.Sessions.Find(id);

        public int Update(Session session)
        {
            _context.Update(session);
            return _context.SaveChanges();
        }
    }
}
