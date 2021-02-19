using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DataAccess.Entities;
using Dominio.DataAccess.DTOs;
using Dominio.DataAccess.DTOs.Roles;

namespace Dominio.Helpers.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TbUsuario, UsuariosDTO>()
                //.ForMember(x => x.TbHistoricoDeSesiones, options => options.Ignore())
                //.ForMember(x => x.TbPantallaPlaUsuarioCreaNavigations, options => options.Ignore())
                //.ForMember(x => x.TbPantallaPlaUsuarioModificaNavigations, options => options.Ignore())
                //.ForMember(x => x.TbPantallasRolePlarolUsuarioCreaNavigations, options => options.Ignore())
                //.ForMember(x => x.TbPantallasRolePlarolUsuarioModificaNavigations, options => options.Ignore())
                //.ForMember(x => x.TbRoleRolUsuarioCreaNavigations, options => options.Ignore())
                //.ForMember(x => x.TbRoleRolUsuarioModificaNavigations, options => options.Ignore())
                //.ForMember(x => x.TbTokensUsuarios, options => options.Ignore())
                //.ForMember(x => x.TbUsuariosRoleUsurolUsuarioCreaNavigations, options => options.Ignore())
                //.ForMember(x => x.TbUsuariosRoleUsurolUsuarioModificaNavigations, options => options.Ignore())
                //.ForMember(x => x.TbUsuariosRoleUsus, options => options.Ignore())
                .ReverseMap();

            CreateMap<TbRole, RolesDTO>().ReverseMap();
        }
    }
}
