using GymMangementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface IMemberShipRepository
    {
        MemberShip GetByID(int id);
        IEnumerable<MemberShip> GetAll();
        int Add(MemberShip memberShip);
        int Update(MemberShip memberShip);
        int Delete(int id);
    }
}
