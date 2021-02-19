using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DataAccess.Entities;
using Dominio.DataAccess.DTOs;

namespace Dominio.Helpers.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TbUsuario, UsuariosDTO>().ReverseMap();

            CreateMap<TbRole, RolesDTO>().ReverseMap();
        }
    }
}
