using GymMangementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    public interface ISessionRepository 
    {
        IEnumerable<Session> GetAllSessionsWithTrainerAndCategory();

        Session GetSessionWithTrainerAndCategory(int sessionID);

        int GetCountOfBookedSlots(int sessionId);
    }
}
