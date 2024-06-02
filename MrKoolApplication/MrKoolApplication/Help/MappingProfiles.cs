using AutoMapper;
using MrKool.DTO;
using MrKool.Models;
using MrKoolApplication.DTO;

namespace MrKoolApplication.Help
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Area, AreaDTO>();
            CreateMap<Station, StationDTO>();
        

        }
    }
}
