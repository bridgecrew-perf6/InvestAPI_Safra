using Invest.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Services.Contracts
{
    public interface IAcaoServices : IBaseServices<Acao>
    {
        Task<ActionResult<Acao>> ListarPorId(string Id);
        Task<ActionResult<IEnumerable<Acao>>> ListarPorRazaoSocial(string razao);
    }
}
