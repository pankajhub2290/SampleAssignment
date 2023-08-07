using AutoMapper;
using SampleAssignment.Shared.Models;
using SampleAssignment.WebApp.Models;

namespace SampleAssignment.WebApp.Mapper
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerViewModel, CustomerRequestModel>();
            CreateMap<CustomerResponseModel, CustomerViewModel>()
                .ForMember(x => x.AddressLine1, opt => opt.MapFrom(x => x.Address.AddressLine1))
                .ForMember(x => x.AddressLine2, opt => opt.MapFrom(x => x.Address.AddressLine2))
                .ForMember(x => x.State, opt => opt.MapFrom(x => x.Address.State))
                .ForMember(x => x.City, opt => opt.MapFrom(x => x.Address.City))
                .ForMember(x => x.PostalCode, opt => opt.MapFrom(x => x.Address.PostalCode))
                .ForMember(x => x.Country, opt => opt.MapFrom(x => x.Address.Country));

            CreateMap<CustomerResponseModel, CustomerListViewModel>()
                .ForMember(x => x.Address, opt => opt.MapFrom(src => MapAddressString(src.Address)));
        }
        
        private static string MapAddressString(AddressResponseModel address)
        {
            return string.Join(", ", new string[] {
                                            address.AddressLine1?? string.Empty,
                                            address.AddressLine2 ?? string.Empty,
                                            address.City ?? string.Empty,
                                            address.State ?? string.Empty,
                                            address.PostalCode ?? string.Empty,
                                            address.Country ?? string.Empty,
                                            }.Where(c => !string.IsNullOrEmpty(c)));
        }
    }
}
