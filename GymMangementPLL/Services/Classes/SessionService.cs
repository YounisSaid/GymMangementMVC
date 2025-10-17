using AutoMapper;
using GymManagementBLL.ViewModels.SessionViewModels;
using GymMangementDAL.Entities;
using GymMangementDAL.Repositories.Interfaces;
using GymMangementPLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GymMangementPLL.Services.Classes
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SessionService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool CreateSession(CreateSessionViewModel ViewModel)
        {
            if (!IsValidSessionTime(ViewModel.StartDate, ViewModel.EndDate))
            {
                return false;
            }
            if (!IsTrainerExist(ViewModel.TrainerId))
            {
                return false;
            }
            if (!IsCategoryExist(ViewModel.CategoryId))
            {
                return false;
            }

            var session = _mapper.Map<Session>(ViewModel);

            _unitOfWork.GetRepository<Session>().Add(session);

            return _unitOfWork.SaveChanges() > 0;
        }

        public IEnumerable<SessionViewModel> GetAllSessions()
        {
            var sessions = _unitOfWork.SessionRepository.GetAllSessionsWithTrainerAndCategory()
                                                        .OrderByDescending(s => s.StartDate); 

            if (sessions is null || !sessions.Any())
            {
                return [];
            }

            var mappedSessions = _mapper.Map<IEnumerable<SessionViewModel>>(sessions);

            foreach(var session in mappedSessions)
            {
                session.AvailableSlots = session.Capacity - _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id);
            }

            return mappedSessions;

        }

        public SessionViewModel? GetSessionByID(int id)
        {
            var session = _unitOfWork.SessionRepository.GetSessionWithTrainerAndCategory(id);
                                                        

            if (session is null )
            {
                return null;
            }

            var mappedSession = _mapper.Map<SessionViewModel>(session);

            mappedSession.AvailableSlots = mappedSession.Capacity - _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id);
            

            return mappedSession;
        }

        public bool UpdateSession(int id,UpdateSessionViewModel ViewModel)
        {
            var session = _unitOfWork.GetRepository<Session>().GetByID(id);
           
            if (!IsSessionAvailableForUpdate(session))
            {
                return false;
            }
            if (!IsTrainerExist(ViewModel.TrainerId))
            {
                return false;
            }
            
             _mapper.Map<Session>(ViewModel);
            session.UpdatedAt = DateTime.Now;

            _unitOfWork.GetRepository<Session>().Update(session);
            return _unitOfWork.SaveChanges() > 0;

        }

        public UpdateSessionViewModel? GetSessionToUpdate(int id)
        {
            var session = _unitOfWork.GetRepository<Session>().GetByID(id);

            if (session is null)
            {
                return null;
            }
            var mappedSession = _mapper.Map<UpdateSessionViewModel>(session);
            return mappedSession;
        }

        public bool RemoveSession(int id)
        {
            var session = _unitOfWork.GetRepository<Session>().GetByID(id);
            if (!IsSessionAvailableForDelete(session))
            {
                return false;
            }
            _unitOfWork.GetRepository<Session>().Delete(session);
            return _unitOfWork.SaveChanges() > 0;
        }
        #region Helper Methods
        private bool IsValidSessionTime(DateTime startTime, DateTime endTime)
        {
            return startTime < endTime &&
                   startTime >= DateTime.Now &&
                   endTime > DateTime.Now;
        }


        private bool IsTrainerExist(int trainerId)
        {
            var trainer = _unitOfWork.GetRepository<Trainer>().GetByID(trainerId);
            return trainer != null;
        }

        private bool IsCategoryExist(int categoryId)
        {
            var category = _unitOfWork.GetRepository<Category>().GetByID(categoryId);
            return category != null;
        }

       private bool IsSessionAvailableForUpdate(Session session )
        {
            if (session is null)
            {
                return false;
            }

            if (!IsValidSessionTime(session.StartDate, session.EndDate))
            {
                return false;
            }

            // session has booked slots

            var bookedSlots = _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id) > 0;

            if(bookedSlots)
            {
                return false;
            }
            return true;
        }

        private bool IsSessionAvailableForDelete(Session session)
        {
            if (session is null)
            {
                return false;
            }
            // session is running
            if(session.StartDate <= DateTime.Now && session.EndDate >= DateTime.Now)
            {
                return false;
            }
            // session already ended
            if (session.EndDate < DateTime.Now)
            {
                return false;
            }
            // session has booked slots
            var bookedSlots = _unitOfWork.SessionRepository.GetCountOfBookedSlots(session.Id) > 0;
            if (bookedSlots)
            {
                return false;
            }
            return true;
        }

        


        #endregion
    }
}
