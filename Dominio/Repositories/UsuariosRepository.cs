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

namespace Dominio.Repositories
{
    public class UsuariosRepository : DataValidationResult
    {
        private readonly FleetManagerContext context;
        private readonly IMapper mapper;
        private readonly EndPointGenericResult GenericResult = new EndPointGenericResult();

        public UsuariosRepository(FleetManagerContext Context, IMapper Mapper)
        {
            context = Context;
            mapper = Mapper;
        }

        //
        //repository methods
        //

        public async Task<EndPointGenericResult> Get()
        {
            try
            {
                var Result = await context.TbUsuarios.ToListAsync();
                if (Result.Count == 0)
                {
                    GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.NoContent.ToString()];
                    GenericResult.DataResult = new { data = ValidationStatus.NoContent.ToString() };
                }
                else 
                {
                    GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.Ok.ToString()];
                    GenericResult.DataResult = new { data = mapper.Map<List<UsuariosDTO>>(Result) };
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

        public async Task<EndPointGenericResult> Get(int id)
        {
            try
            {
                var Result = await context.TbUsuarios.Where(x => x.UsuId == id).FirstOrDefaultAsync();   //get data
                if (Result == null)
                {
                    GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.NotFound.ToString()];
                    GenericResult.DataResult = new { data = ValidationStatus.NotFound.ToString() };
                }
                else
                {
                    GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.Ok.ToString()];
                    GenericResult.DataResult = new { data = mapper.Map<UsuariosDTO>(Result) };
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

        public async Task<EndPointGenericResult> Add(UsuariosDTO entity)
        {
            try
            {
                var Result = mapper.Map<TbUsuario>(entity);
                await context.TbUsuarios.AddAsync(Result);
                GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.Created.ToString()];
                GenericResult.DataResult = new { data = ValidationStatus.Created.ToString() };
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
                GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.InternalServerError.ToString()];
                GenericResult.DataResult = new { data = ValidationStatus.InternalServerError.ToString() };
            }
            return GenericResult;
        }

        public async Task<EndPointGenericResult> Update(UsuariosDTO entity)
        {
            try
            {
                var entityBase =await  (from tbUsuarios in context.TbUsuarios
                                        where entity.UsuId == tbUsuarios.UsuId
                                        select tbUsuarios).FirstAsync();
                entityBase.UsuCorreo = entity.UsuCorreo;
                entityBase.UsuNombreDeUsuario = entity.UsuNombreDeUsuario;
                entityBase.UsuContrasenia = entity.UsuContrasenia;
                entityBase.UsuFotografia = entity.UsuFotografia;
                entityBase.UsuNoCelular = entity.UsuNoCelular;
                entityBase.UsuEsActivo = entity.UsuEsActivo;
                entityBase.UsuUsuarioModifica = entity.UsuUsuarioModifica;
                entityBase.UsuFechaModifica = MethodsLibrary.DateTimeNow;

                await this.SaveChanges();
                GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.Updated.ToString()];
                GenericResult.DataResult = new { data = ValidationStatus.Updated.ToString() };
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
                GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.InternalServerError.ToString()];
                GenericResult.DataResult = new { data = ValidationStatus.InternalServerError.ToString() };
            }
            return GenericResult;
        }

        public async Task<EndPointGenericResult> Delete(UsuariosDTO entity)
        {
            return await Task.Run(() => 
            {
                try
                {
                    var Result = mapper.Map<TbUsuario>(entity);
                    context.TbUsuarios.Remove(Result);
                    GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.Created.ToString()];
                    GenericResult.DataResult = new { data = ValidationStatus.Created.ToString() };
                }
                catch (Exception Ex)
                {
                    Ex.Message.ToString();
                    GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.InternalServerError.ToString()];
                    GenericResult.DataResult = new { data = ValidationStatus.InternalServerError.ToString() };
                }
                return GenericResult;
            });
        }

        public async Task<EndPointGenericResult> GetLatestId()
        {
            try
            {
                int? LatestId = await context.TbUsuarios.OrderByDescending(x => x.UsuId).Select(x => x.UsuId).FirstOrDefaultAsync();
                GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.Ok.ToString()];
                GenericResult.DataResult = new { data = LatestId == null ? 1 : (int)LatestId + 1 };
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
                GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.InternalServerError.ToString()];
                GenericResult.DataResult = new { data = ValidationStatus.InternalServerError.ToString() };
            }
            return GenericResult;
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
