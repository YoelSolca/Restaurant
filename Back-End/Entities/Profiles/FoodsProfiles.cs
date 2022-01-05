using AutoMapper;
using Entities.Dto;
using Entities.Models;

namespace Entities.Profiles
{
    public class FoodsProfiles: Profile
    {
        public FoodsProfiles()
        {
            CreateMap<FoodsDto, Foods>();
        }
    }
}
