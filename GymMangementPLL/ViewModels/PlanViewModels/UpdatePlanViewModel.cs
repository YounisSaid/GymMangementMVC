﻿using System.ComponentModel.DataAnnotations;

namespace GymManagementBLL.ViewModels.PlanViewModels
{
	public class UpdatePlanViewModel
	{
		public string PlanName { get; set; } = null!;

		[Required(ErrorMessage = "Description is required")]
		[StringLength(200, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 200 characters")]
		public string Description { get; set; } = null!;

		[Required(ErrorMessage = "Duration is required")]
		[Range(1, 365, ErrorMessage = "Duration must be between 1 and 365 days")]
		public int DurationDays { get; set; }

		[Required(ErrorMessage = "Price is required")]
		[Range(0.01, 10000, ErrorMessage = "Price must be greater than 0")]
		public decimal Price { get; set; }
	}
}
