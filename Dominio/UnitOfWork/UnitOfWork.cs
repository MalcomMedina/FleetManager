using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dominio.Repositories;
using Dominio.DataAccess.DBContexts;
using AutoMapper;

namespace Dominio.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        //db context
        private FleetManagerContext Context { get; }
        private IMapper Mapper { get; }

        //dependency injection
        public UnitOfWork(FleetManagerContext Context, IMapper Mapper)
        {
            this.Context = Context;
            this.Mapper = Mapper;
        }

        //declare repositories
        private LoginRepository _LoginRepository;
        private RolesRepository _RolesRepository;
        private UsuariosRepository _UsuariosRepository;


        //
        //repositories getters
        //
        public LoginRepository LoginRepository => _LoginRepository ??= new LoginRepository(Context, Mapper);
        public RolesRepository RolesRepository => _RolesRepository ??= new RolesRepository(Context, Mapper);
        public UsuariosRepository UsuariosRepository => _UsuariosRepository ??= new UsuariosRepository(Context, Mapper);


        //method global to save actions in multiple repositories
        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }

    }
}
