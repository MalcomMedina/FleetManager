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
    public class RolesRepository : DataValidationResult
    {
        private readonly FleetManagerContext context;
        private readonly IMapper mapper;
        private readonly EndPointGenericResult GenericResult = new EndPointGenericResult();

        public RolesRepository(FleetManagerContext Context, IMapper Mapper)
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
                var Result = await context.TbRoles.ToListAsync();
                if (Result.Count == 0)
                {
                    GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.NoContent.ToString()];
                    GenericResult.DataResult = new { data = ValidationStatus.NoContent.ToString() };
                }
                else
                {
                    GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.Ok.ToString()];
                    GenericResult.DataResult = new { data = mapper.Map<List<RolesDTO>>(Result) };
                }
                return GenericResult;
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
                GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.BadRequest.ToString()];
                GenericResult.DataResult = new { data = ValidationStatus.BadRequest.ToString() };
                return GenericResult;
            }
        }

        public async Task<EndPointGenericResult> Get(int id)
        {
            try
            {
                var Result = await context.TbRoles.Where(x => x.RolId == id).FirstOrDefaultAsync();   //get data
                if (Result == null)
                {
                    GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.NotFound.ToString()];
                    GenericResult.DataResult = new { data = ValidationStatus.NotFound.ToString() };
                }
                else
                {
                    GenericResult.ValidationMessage = ValidationStatusMessages[ValidationStatus.Ok.ToString()];
                    GenericResult.DataResult = new { data = mapper.Map<RolesDTO>(Result) };
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

        public async Task<EndPointGenericResult> Add(RolesDTO entity)
        {
            try
            {
                var Result = mapper.Map<TbRole>(entity);
                await context.TbRoles.AddAsync(Result);
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

        public async Task<EndPointGenericResult> Update(RolesDTO entity)
        {
            try
            {
                var entityBase = await (from tbRoles in context.TbRoles
                                        where entity.RolId == tbRoles.RolId
                                        select tbRoles).FirstAsync();
                entityBase.RolDescripcion = entity.RolDescripcion;
                entityBase.RolEsActivo = entity.RolEsActivo;
                entityBase.RolUsuarioModifica = entity.RolUsuarioModifica;
                entityBase.RolFechaModifica = MethodsLibrary.DateTimeNow;

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

        public async Task<EndPointGenericResult> Delete(RolesDTO entity)
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
                int? LatestId = await context.TbRoles.OrderByDescending(x => x.RolId).Select(x => x.RolId).FirstOrDefaultAsync();
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
