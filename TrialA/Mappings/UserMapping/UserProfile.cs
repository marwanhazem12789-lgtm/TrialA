using AutoMapper;
using TrialA.DTOs.AuthDTOs;
using TrialA.Models;

namespace TrialA.Mappings.UserMapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDTOs, User>();
        }
    }
}
