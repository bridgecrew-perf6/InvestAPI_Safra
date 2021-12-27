using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Services.Contracts
{
    public interface IBaseServices<TEntity> : IDisposable where TEntity : class
    {
        Task<ActionResult<IEnumerable<TEntity>>> ListarTodos();
        
        bool Inserir(TEntity entity);
        bool Atualizar(TEntity entity);
        bool Deletar(string id);
    }
}
