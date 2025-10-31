using GymMangementDAL.Entities;
using GymMangementPLL.ViewModels;

namespace GymMangementPLL.Services.Interfaces
{
    public interface IAccountService
    {
        ApplicationUser? ValidiateUser(LoginViewModel input); 
    }
}
