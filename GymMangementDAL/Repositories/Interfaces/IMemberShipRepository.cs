using GymMangementDAL.Entities;

namespace GymMangementDAL.Repositories.Interfaces
{
	public interface IMembershipRepository : IGenericRepository<MemberShip>
	{
		IEnumerable<MemberShip> GetAllMembershipsWithMemberAndPlan(Func<MemberShip, bool> predicate);
	}
}
