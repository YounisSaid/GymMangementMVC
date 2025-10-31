using GymManagementBLL.ViewModels;

namespace GymMangementPLL.Services.Interfaces
{
    public interface IPlanService
    {
         bool UpdatePlan(int planID, UpdatePlanViewModel viewModel);
         UpdatePlanViewModel? GetPlanToUpdate(int planID);
         IEnumerable<PlanViewModel> GetAllPlans();
         PlanViewModel? GetPlanById(int planID);
         bool Activate(int planID);

    }
}
