using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMvcEfcf.App_Start
{
    public class MapperConfig
    {
        public static void Configuration()
        {
            AutoMapper.Mapper.CreateMap<Entidades.EFCF.Product, 
                Models.ProductoVM>()
                .ForMember("Category", (c)=>{
                    c.MapFrom(d => d.ProductSubcategory.Name);
                }) ;
        }
    }
}