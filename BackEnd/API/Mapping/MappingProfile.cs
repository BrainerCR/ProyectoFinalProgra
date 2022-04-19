using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = DAL.DO.Objects;


namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<data.Distribuidor, DataModels.Distribuidor>().ReverseMap();
            CreateMap<data.Producto, DataModels.Producto>().ReverseMap();
            CreateMap<data.VinculoProducto, DataModels.VinculoProducto>().ReverseMap();
            CreateMap<data.Cliente, DataModels.Cliente>().ReverseMap();
            CreateMap<data.Empleado, DataModels.Empleado>().ReverseMap();
            CreateMap<data.RegistroFactura, DataModels.RegistroFactura>().ReverseMap();
            CreateMap<data.RolEmpleado, DataModels.RolEmpleado>().ReverseMap();
        }
    }
}
