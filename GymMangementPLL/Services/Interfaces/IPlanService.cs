using GymManagementBLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
