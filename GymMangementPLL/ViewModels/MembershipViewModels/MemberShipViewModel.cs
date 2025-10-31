﻿namespace GymManagementBLL.ViewModels
{
	public class MemberShipViewModel
	{
		public int MemberId { get; set; }
		public int PlanId { get; set; }
		public string MemberName { get; set; } = null!;
		public string PlanName { get; set; } = null!;
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
