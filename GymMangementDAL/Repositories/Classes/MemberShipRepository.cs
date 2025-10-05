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
    public class MemberShipRepository : IMemberShipRepository
    {
        private readonly GymDbContext _context;
        public MemberShipRepository(GymDbContext context)
        {
            _context = context;
        }
        public int Add(MemberShip memberShip)
        {
            _context.Add(memberShip);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var MemberShip = _context.MemberShips.Find(id);
            if (MemberShip != null)
            {
                _context.MemberShips.Remove(MemberShip);
                return _context.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<MemberShip> GetAll() => _context.MemberShips.ToList();

        public MemberShip? GetByID(int id) => _context.MemberShips.Find(id);

        public int Update(MemberShip memberShip)
        {
            _context.Update(memberShip);
            return _context.SaveChanges();
        }
       
    }
}
