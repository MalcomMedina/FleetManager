using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.DataAccess.DBContexts;
using Dominio.DataAccess.Entities;
using Dominio.DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using Dominio.Helpers.Utils;
using Dominio.DataAccess.ViewModels.Login;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Dominio.Repositories
{
    public class LoginRepository : DataValidationResult
    {
        private readonly FleetManagerContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly EndPointGenericResult GenericResult = new EndPointGenericResult();

        public LoginRepository(FleetManagerContext Context, IMapper Mapper, IConfiguration Configuration)
        {
            context = Context;
            mapper = Mapper;
            configuration = Configuration;
        }

        //
        //repository methods
        //

        public async Task<EndPointGenericResult> SignIn(UserInfoViewModel model)
        {
            try
            {
                var Result = await context.TbUsuarios.AnyAsync(x => x.UsuNombreDeUsuario == model.UsuNombreDeUsuario ||
                                                               x.UsuCorreo == model.UsuCorreo &&
                                                               x.UsuContrasenia == MethodsLibrary.GetSha256(model.UsuContrasenia));
                if (!Result)
                {
                    GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.NotFound.ToString()];
                    GenericResult.DataResult = new { data = ValidationStatus.NotFound.ToString() };
                }
                else 
                {
                    GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.Ok.ToString()];
                    GenericResult.DataResult = new { data = ValidationStatus.Ok.ToString() };
                }
                return GenericResult;
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
                GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.InternalServerError.ToString()];
                GenericResult.DataResult = new { data = ValidationStatus.InternalServerError.ToString() };
                return GenericResult;
            }
        }

        public async Task<UserTokenViewModel> BuildToken(UserInfoViewModel userInfo)
        {
            return await Task.Run(() => {

                //******************************************************************************//
                // FALTA LA LÓGICA PARA RECUPERAR LA INFO COMPLETA DEL OBJETO UserInfoViewModel //
                //******************************************************************************//


                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.UsuCorreo),
                    new Claim("Username", userInfo.UsuNombreDeUsuario),
                    new Claim("Fotografia", userInfo.UsuFotografia),
                    new Claim("Telefono", userInfo.UsuNoCelular),
                    new Claim("Roles", userInfo.Roles.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Tiempo de expiración del token. En nuestro caso lo hacemos de una hora.
                var expiration = MethodsLibrary.DateTimeNow.AddYears(1);

                JwtSecurityToken token = new JwtSecurityToken(
                   issuer: null,
                   audience: null,
                   claims: claims,
                   expires: expiration,
                   signingCredentials: creds
                );

                return new UserTokenViewModel()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = expiration
                };
            });
        }

        public async Task SaveChanges()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
            }
        }

    }
}
