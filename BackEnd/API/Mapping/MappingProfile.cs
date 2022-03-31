using AutoMapper;
using data = DAL.DO.Objects;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Empleado, DataModels.Empleado>().ReverseMap();
            CreateMap<data.RolEmpleado, DataModels.RolEmpleado>().ReverseMap();
        }
    }
}
