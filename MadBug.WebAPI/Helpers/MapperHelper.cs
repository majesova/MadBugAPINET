using AutoMapper;
using MadBug.WebAPI.Models.api;
using MagBug.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadBug.WebAPI.Helpers
{
    public class MapperHelper
    {
        internal static IMapper mapper;

        static MapperHelper()
        {
            var config = new MapperConfiguration(x => {
                x.CreateMap<Bug, BugApi>().ReverseMap();
                x.CreateMap<User, UserApi>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }

        public static T Map<T>(object source)
        {
            return mapper.Map<T>(source);
        }
    }
}