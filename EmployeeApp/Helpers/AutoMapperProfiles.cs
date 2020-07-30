using AutoMapper;
using EmployeeApp.Dtos;
using EmployeeApp.Models;
using EmployeeApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MappingToDto();
            MappingToEntity();
        }

        private void MappingToDto()
        {
            CreateMap<Employee, EmployeeDetailDto>()
                .ForMember(dest => dest.WorkRole,
                    opt => opt.MapFrom(src => src.WorkRole.GetTitleFromWorkRole()))
                .ForMember(dest => dest.Superior,
                    opt => opt.MapFrom(src => src.Superior.Name))
                .ForMember(dest => dest.OrganizationUnit,
                    opt => opt.MapFrom(src => src.OrganizationUnit.Name))
                .ForMember(dest => dest.OrganizationUnitAbbreviation,
                    opt => opt.MapFrom(src => src.OrganizationUnit.Abbreviation))
                ;

            CreateMap<Employee, EmployeeListDto>()
                .ForMember(dest => dest.WorkRole,
                    opt => opt.MapFrom(src => src.WorkRole.GetTitleFromWorkRole()))
                .ForMember(dest => dest.OrganizationUnit,
                    opt => opt.MapFrom(src => src.OrganizationUnit.Name))
                ;
        }

        private void MappingToEntity()
        {
            CreateMap<EmployeeDetailDto, Employee>()
                .ForMember(dest => dest.WorkRole,
                    opt => opt.MapFrom(src => src.WorkRole.GetWorkRoleFromTitle()))
                .ForMember(dest => dest.Superior,
                    opt => opt.Ignore())
                .ForMember(dest => dest.OrganizationUnit,
                    opt => opt.Ignore())
                ;
        }
    }
}
