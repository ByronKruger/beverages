using AutoMapper;
using Coffeeg.Dtos.User;
using Coffeeg.Entities;

namespace Coffeeg.Helpers.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUser, User>();

            CreateMap<LogInUser, User>();
        }
    }
}
