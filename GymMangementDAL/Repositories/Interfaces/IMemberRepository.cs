using GymMangementDAL.Entities;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        IEnumerable<Session> GetAllSessions();        

    }
}
