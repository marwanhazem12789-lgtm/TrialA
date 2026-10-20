using AutoMapper;
using TrialA.Models;

namespace TrialA.Mappings.ApplicationMappings
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Application, DTOs.ApplicationDTOs.GetAllApplication>();
        }
    }
}
