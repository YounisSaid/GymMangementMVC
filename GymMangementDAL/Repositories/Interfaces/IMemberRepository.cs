using GymMangementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Member GetByID(int id);
        IEnumerable<Member> GetAll();
        int Add(Member member);
        int Update(Member member);
        int Delete(int id);

    }
}
