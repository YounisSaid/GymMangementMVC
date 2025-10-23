using GymMangementDAL.Entities;
using GymMangementPLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementPLL.Services.Interfaces
{
    public interface IMemberService 
    {
        public bool CreateMember(CreateMemberViewModel memberViewModel);
        public bool UpdateMember(int id, MemberToUpdateViewModel memberViewModel);
        public bool RemoveMember(int id);
        public IEnumerable<MemberViewModel> GetAllMembers();
        public MemberViewModel? GetMemberDetails(int id);
        public HealthRecordViewModel? GetMemberHealthRecord(int id);
        public MemberToUpdateViewModel? GetMemberToUpdate(int id);

    }
}
