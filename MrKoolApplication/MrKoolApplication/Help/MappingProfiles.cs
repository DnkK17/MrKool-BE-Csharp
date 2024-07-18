using AutoMapper;
using MrKool.DTO;
using MrKool.Models;
using MrKoolApplication.DTO;
using MrKoolApplication.Models;

namespace MrKoolApplication.Help
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Area, AreaDTO>()
                .ForMember(dest => dest.Stations, opt => opt.MapFrom(src => src.StationList));
            CreateMap<AreaDTO, Area>();
            CreateMap<Station, StationDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Request, RequestDTO>().ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.Services));
            CreateMap<ConditionerModel, ConditionerModelDTO>();
            CreateMap<Manager,  ManagerDTO>(); 
            CreateMap<Technician, TechnicianDTO>();
            CreateMap<Transaction, TransactionDTO>();
            CreateMap<Wallet, WalletDTO>();
            CreateMap<FixHistory, FixHistoryDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDetail, OrderDetailDTO>();
            CreateMap<RequestDTO, Request>();

        }
    }
}
