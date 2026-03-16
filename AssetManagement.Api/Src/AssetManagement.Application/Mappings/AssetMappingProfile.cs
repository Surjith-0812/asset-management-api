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
    public class AssetMappingProfile : Profile
    {
        public AssetMappingProfile()
        {
            CreateMap<CreateAssetDto, Asset>();

            CreateMap<Asset, AssetDto>();

        }
    }
}
