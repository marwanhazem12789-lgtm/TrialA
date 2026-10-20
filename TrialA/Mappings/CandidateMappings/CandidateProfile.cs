using AutoMapper;
using TrialA.DTOs.CandidateDTOs;
using TrialA.Models;

namespace TrialA.Mappings.CandidateMappings
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<UpdateCandidate, CandidateProfile>();
        }
    }

}
