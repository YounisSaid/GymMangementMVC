using GymMangementDAL.Contexts;
using GymMangementDAL.Entities;
using GymMangementDAL.Repositories.Interfaces;
namespace GymMangementDAL.Repositories.Classes
{
    public class MemberRepository : IMemberRepository
    {
        private readonly GymDbContext _context;
        public MemberRepository(GymDbContext context)
        {
            _context = context;
        }
        public int Add(Member member)
        {
            _context.Add(member);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var Member = _context.Members.Find(id);
            if (Member != null)
            {
                _context.Members.Remove(Member);
                return _context.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<Member> GetAll() => _context.Members.ToList();

        public Member? GetByID(int id) => _context.Members.Find(id);

        public int Update(Member member)
        {          
           _context.Update(member);
           return _context.SaveChanges();         
        }
    }
}
