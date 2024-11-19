using AutoMapper;
using Real_App.Dtos;
using Real_App.Model;

namespace Real_App.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDto>().ReverseMap();
        }
    }
}
