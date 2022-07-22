using AutoMapper;
using EduFlow_Odev2.Data;
using EduFlow_Odev2.Dto;

namespace EduFlow_Odev2.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap(); 
            CreateMap<Employee, EmployeeDto>().ReverseMap(); 
            CreateMap<Folder, FolderDto>().ReverseMap();
        }

    }
}

