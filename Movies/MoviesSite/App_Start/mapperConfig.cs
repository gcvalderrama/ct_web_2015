using Movies.Entities;
using MoviesSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesSite.App_Start
{
    public class MapperConfig
    {
        public static void Config()
        {
            AutoMapper.Mapper.CreateMap<ReviewVM, Review>();
            AutoMapper.Mapper.CreateMap<Review, ReviewVM>();
        }
    }
}