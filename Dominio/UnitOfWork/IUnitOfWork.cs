using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Repositories;
using System.Threading.Tasks;

namespace Dominio.UnitOfWork
{
    public interface IUnitOfWork
    {
        LoginRepository LoginRepository { get; }
        RolesRepository RolesRepository { get; }
        UsuariosRepository UsuariosRepository { get; }
        Task Save();
    }
}
