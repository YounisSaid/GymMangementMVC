using GymMangementPLL.ViewModels.TrainerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementPLL.Services.Interfaces
{
    public interface ITrainerService
    {
        public bool CreateTrainer(CreateTrainerViewModel trainerViewModel);
        public bool UpdateTrainer(int id, TrainerToUpdateViewModel trainerViewModel);
        public bool RemoveTrainer(int id);
        public IEnumerable<TrainerViewModel> GetAllTrainers();
        public TrainerViewModel? GetTrainerDetails(int id);
        public TrainerToUpdateViewModel? GetTrainerToUpdate(int id);
    }
}
