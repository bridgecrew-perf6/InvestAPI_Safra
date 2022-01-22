using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Services.Contracts
{
    public interface IYahooService
    {
        Task<string> Cotacao(string acaoId);
    }
}
