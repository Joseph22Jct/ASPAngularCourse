using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        CreateMap<AppUser, MemberDto>();
        CreateMap<Photo, PhotoDto>()
    }
}