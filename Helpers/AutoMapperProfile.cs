using AutoMapper;
using WebApi_Net6_PostgreSQL.Entities;
using WebApi_Net6_PostgreSQL.Models.Users;

namespace WebApi_Net6_PostgreSQL.Helpers {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            // CreateRequest -> User
            CreateMap<CreateRequest, User>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, User>()
                .ForAllMembers(x => x.Condition((src, dest, prop) => {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
        }
    }
}
