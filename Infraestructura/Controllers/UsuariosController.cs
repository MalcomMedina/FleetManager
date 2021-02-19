﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dominio.DataAccess.DTOs;
using Dominio.UnitOfWork;
using Dominio.DataAccess.DBContexts;
using AutoMapper;
using Dominio.DataAccess.Entities;
using Dominio.Helpers.Attributes;
using Dominio.Helpers.Utils;

namespace Infraestructura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly FleetManagerContext context;
        private readonly IMapper mapper;
        private readonly UnitOfWork unitOfWork;
        private readonly ILogger<UsuariosController> logger;

        public UsuariosController(ILogger<UsuariosController> Logger, FleetManagerContext Context, IMapper Mapper)
        {
            context = Context;
            mapper = Mapper;
            unitOfWork ??= new UnitOfWork(context, mapper);
            logger = Logger;
        }


        [HttpGet]
        [ServiceFilter(typeof(AuthorizeActionFilter))]
        public async Task<ActionResult<EndPointGenericResult>> Get()
        {
            return await unitOfWork.UsuariosRepository.Get();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EndPointGenericResult>> Get(int id)
        {
            return await unitOfWork.UsuariosRepository.Get(id);
        }

        [HttpPost()]
        public async Task<ActionResult<EndPointGenericResult>> Post([FromBody] UsuariosDTO Entity)
        {
            return await unitOfWork.UsuariosRepository.Add(Entity);
        }
    }
}
