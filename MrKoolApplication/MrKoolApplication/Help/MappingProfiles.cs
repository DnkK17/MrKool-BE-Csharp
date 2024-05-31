using AutoMapper;
using MrKool.DTO;
using MrKool.Models;

namespace MrKoolApplication.Help
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Area, AreaDTO>();
        }
    }
}
