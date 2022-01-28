using Invest.Repositories.Context;
using Invest.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Services.Business
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        protected DataContext _context;
        private bool disposedValue;
        public BaseServices(DataContext context)
        {
            _context = context;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public virtual bool Atualizar(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual bool Deletar(string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public virtual bool Inserir(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ActionResult<TEntity>> ListarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<ActionResult<IEnumerable<TEntity>>> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
