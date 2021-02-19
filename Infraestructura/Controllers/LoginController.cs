using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dominio.DataAccess.ViewModels.Login;
using Dominio.UnitOfWork;
using Dominio.DataAccess.DBContexts;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Infraestructura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly FleetManagerContext context;
        private readonly IMapper mapper;
        private readonly UnitOfWork unitOfWork;
        private readonly ILogger<UsuariosController> logger;
        private readonly IConfiguration configuration;

        public LoginController(ILogger<UsuariosController> Logger, FleetManagerContext Context, IMapper Mapper,IConfiguration Configuration)
        {
            context = Context;
            mapper = Mapper;
            configuration = Configuration;
            unitOfWork ??= new UnitOfWork(context, mapper, configuration);
            logger = Logger;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<UserTokenViewModel>> CreateUser([FromBody] UserInfoViewModel model)
        {
            try 
            {
                var Result = await unitOfWork.LoginRepository.SignIn(model);

                if ((string)Result.DataResult == "InternalServerError")
                {
                    return BadRequest("¡Ha ocurrido un error al tratar de iniciar sesión!");
                }
                else if((string)Result.DataResult == "NotFound")
                {
                    return BadRequest("¡Ha ocurrido un error al tratar de iniciar sesión!");
                }
                else
                {
                    return await unitOfWork.LoginRepository.BuildToken(model);
                }
            }
            catch(Exception Ex)
            {
                Ex.Message.ToString();
                return BadRequest("¡Ha ocurrido un error al tratar de iniciar sesión!");
            }

        }

    }
}
