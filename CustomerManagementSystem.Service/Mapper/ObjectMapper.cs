using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Service.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>//Lazy Loading
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DTOMapper>();
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;//=> :get
    }
}
