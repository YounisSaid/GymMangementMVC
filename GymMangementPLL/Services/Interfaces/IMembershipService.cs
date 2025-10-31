﻿using GymManagementBLL.ViewModels;

namespace GymMangementPLL.Services.Interfaces
{
	public interface IMembershipService
	{
		IEnumerable<MemberShipViewModel> GetAllMemberShips();
		bool CreateMembership(CreateMemberShipViewModel CreatedMemberShip);
		bool DeleteMemberShip(int MemberId);
		IEnumerable<PlanSelectListViewModel> GetPlansForDropDown();
		IEnumerable<MemberSelectListViewModel> GetMembersForDropDown();

	}
}
