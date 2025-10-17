using GymManagementBLL.ViewModels.SessionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementPLL.Services.Interfaces
{
    public interface ISessionService
    {
        IEnumerable<SessionViewModel> GetAllSessions();

        SessionViewModel? GetSessionByID(int id);
        UpdateSessionViewModel? GetSessionToUpdate(int id); 
        bool CreateSession(CreateSessionViewModel ViewModel);
        bool UpdateSession(int id,UpdateSessionViewModel ViewModel);
        bool RemoveSession(int id);
    }
}
