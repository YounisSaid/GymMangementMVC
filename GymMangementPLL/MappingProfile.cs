using AutoMapper;
using GymManagementBLL.ViewModels.SessionViewModels;

using GymMangementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementPLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapSession();
        }

        private void MapSession()
        {
            CreateMap<Session, SessionViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.TrainerName, opt => opt.MapFrom(src => src.Trainer.Name))
                .ForMember(dest=> dest.AvailableSlots,opt => opt.Ignore());

            CreateMap<SessionViewModel, Session>();
            CreateMap<CreateSessionViewModel, Session>();
            CreateMap<UpdateSessionViewModel, Session>().ReverseMap();


        }
    }
}
