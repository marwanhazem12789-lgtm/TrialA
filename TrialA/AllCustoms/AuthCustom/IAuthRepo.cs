using TrialA.DTOs.AuthDTOs;
using TrialA.GenaricRepos;
using TrialA.Models;

namespace TrialA.AllCustoms.AuthCustom
{
    public interface IAuthRepo : IGenaricRepo<User>
    {
        Task<string> Login(LoginDTOs dto);
        Task<bool> Register(RegisterDTOs dto);
    }
}
