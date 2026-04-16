using AssetManagement.Application.Interfaces.DTOs;
using AssetManagement.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Mappings
{
    public class AssignmentMappingProfile : Profile
    {
        public AssignmentMappingProfile()
        {
            CreateMap<AssetAssignment, AssetAssignmentDto>();
            CreateMap<CreateAssetAssignmentDto, AssetAssignment>();
            CreateMap<AssetAssignment, AssetAssignmentDto>();
        }
    }
}
