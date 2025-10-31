using GymMangementDAL.Entities;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEnity> GetRepository<TEnity>() where TEnity : BaseEntity;
        ISessionRepository SessionRepository { get; set; }
        int SaveChanges();
    }
}
