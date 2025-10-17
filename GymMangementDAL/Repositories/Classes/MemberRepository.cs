using GymMangementDAL.Contexts;
using GymMangementDAL.Entities;
using GymMangementDAL.Repositories.Interfaces;

namespace GymMangementDAL.Repositories.Classes
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(GymDbContext context) : base(context)
        {
        }

        public IEnumerable<Session> GetAllSessions()
        {
            throw new NotImplementedException();
        }
    }
}
