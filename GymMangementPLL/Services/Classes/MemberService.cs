using GymMangementDAL.Entities;
using GymMangementDAL.Repositories.Interfaces;
using GymMangementPLL.Services.Interfaces;
using GymMangementPLL.ViewModels.MemberViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementPLL.Services.Classes
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateMember(CreateMemberViewModel memberViewModel)
        {
            try
            {
                if (IsEmailExist(memberViewModel.Email) || IsPhoneExist(memberViewModel.Phone))
                {
                    return false;
                }
                var member = new Member
                {
                    Name = memberViewModel.Name,
                    Email = memberViewModel.Email,
                    DateOfBirth = memberViewModel.DateOfBirth,
                    Phone = memberViewModel.Phone,
                    Address = new Address
                    {
                        Street = memberViewModel.Street,
                        City = memberViewModel.City,
                        BuildingNumber = memberViewModel.BuildingNumber
                    },
                    Gender = memberViewModel.Gender,
                    HealthRecord = new HealthRecord
                    {
                        Height = memberViewModel.HealthRecordViewModel.Height,
                        Weight = memberViewModel.HealthRecordViewModel.Weight,
                        BloodType = memberViewModel.HealthRecordViewModel.BloodType,
                        Note = memberViewModel.HealthRecordViewModel.Note
                    }
                };
                _unitOfWork.GetRepository<Member>().Add(member);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
            
       

        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var members = _unitOfWork.GetRepository<Member>().GetAll() ?? [];
            if (!members.Any() || members is null)
            {
               return [];
            }
            var memberViewModels = members.Select(m => new MemberViewModel
            {
                Id = m.Id,
                Name = m.Name,
                Email = m.Email,
                DateOfBirth = m.DateOfBirth.ToShortDateString(),
                Phone = m.Phone,
                Photo = m.Photo,
                Gender = m.Gender.ToString()
            });
            return memberViewModels;
        }

        public MemberViewModel? GetMemberDetails(int id)
        {
            var member = _unitOfWork.GetRepository<Member>().GetByID(id);
            if (member is null)
            {
                return null;
            }
            var memberViewModel = new MemberViewModel
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                DateOfBirth = member.DateOfBirth.ToShortDateString(),
                Phone = member.Phone,
                Photo = member.Photo,
                Gender = member.Gender.ToString(),
                Address = FormatAddress(member.Address)

            };

            var activeMembership = _unitOfWork.GetRepository<MemberShip>().GetAll(ms => ms.MemberId == id && ms.Status == "Active").FirstOrDefault();
            if (activeMembership is not null)
            {
                var plan = _unitOfWork.GetRepository<Plan>().GetByID(activeMembership.PlanId);
                memberViewModel.PlanName = plan.Name;
                memberViewModel.MembershipStartDate = activeMembership.CreatedAt.ToShortDateString();
                memberViewModel.MembershipEndDate = activeMembership.EndDate.ToShortDateString();
            }
            return memberViewModel;

        }
        public bool UpdateMember(int id, MemberToUpdateViewModel memberViewModel)
        {
            var member = _unitOfWork.GetRepository<Member>().GetByID(id);
            if (member is null)
            {
                return false;
            }
            if (IsEmailExist(memberViewModel.Email) || IsPhoneExist(memberViewModel.Phone))
            {
                return false;
            }

            member.Name = memberViewModel.Name;
            member.Email = memberViewModel.Email;
            member.Phone = memberViewModel.Phone;
            member.Address.Street = memberViewModel.Street;
            member.Address.City = memberViewModel.City;
            member.Address.BuildingNumber = memberViewModel.BuildingNumber;
            member.UpdatedAt = DateTime.Now;

            _unitOfWork.GetRepository<Member>().Update(member);
            _unitOfWork.SaveChanges();
            return true;
        }

        public HealthRecordViewModel? GetMemberHealthRecord(int id)
        {
            var healthRecord = _unitOfWork.GetRepository<HealthRecord>().GetByID(id);
            if (healthRecord is null)
            {
                return null;
            }
            var healthRecordViewModel = new HealthRecordViewModel
            {

                Height = healthRecord.Height,
                Weight = healthRecord.Weight,
                BloodType = healthRecord.BloodType,
                Note = healthRecord.Note
            };
            return healthRecordViewModel;
        }
        public MemberToUpdateViewModel GetMemberToUpdate(int id)
        {
            var member = _unitOfWork.GetRepository<Member>().GetByID(id);
            if (member is null)
            {
                return null;
            }

            var memberViewModel = new MemberToUpdateViewModel
            {
                Name = member.Name,
                Email = member.Email,
                Photo = member.Photo,
                Phone = member.Phone,
                BuildingNumber = member.Address.BuildingNumber,
                Street = member.Address.Street,
                City = member.Address.City
            };

            return memberViewModel;
        }

        public bool RemoveMember(int id)
        {
            var member = _unitOfWork.GetRepository<Member>().GetByID(id);
            if (member is null)
            {
                return false;
            }

            var activebooking = _unitOfWork.GetRepository<Booking>().GetAll(b => b.MemberId == id && b.Session.StartDate > DateTime.Now);
            if (activebooking.Any())
            {
                return false;
            }

            var activeMembership = _unitOfWork.GetRepository<MemberShip>().GetAll(ms => ms.MemberId == id ).ToList();
            try
            {
                if (activeMembership.Any())
                {
                    foreach (var membership in activeMembership)
                    {
                        _unitOfWork.GetRepository<MemberShip>().Delete(membership);
                    }
                }
                _unitOfWork.GetRepository<Member>().Delete(member);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
                
        }
        #region Helper Methods

        public string FormatAddress(Address address)
        {
            if (address is null)
            {
                return "N/A";
            }
            return $"{address.Street}, {address.BuildingNumber}, {address.City}";
        }
        public bool IsEmailExist(string email)
        {
            var member = _unitOfWork.GetRepository<Member>().GetAll(m => m.Email.ToLower() == email.ToLower()).FirstOrDefault();
            return member is not null;
        }

        public bool IsPhoneExist(string phone)
        {
            var member = _unitOfWork.GetRepository<Member>().GetAll(m => m.Phone == phone).FirstOrDefault();
            return member is not null;
        }
        #endregion

    }
}
