using AutoMapper;
using DBConApp1.Entity;
using DBConApp1.Models;

namespace DBConApp1.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateRequest, Student>();

            // UpdateRequest -> User
            CreateMap<UpdateRequest, Student>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore both null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        // ignore null role
                        if (x.DestinationMember.Name == "Zimbaba" && src.FirstName == null) return false;

                        return true;
                    }
                ));
        }
    }
}