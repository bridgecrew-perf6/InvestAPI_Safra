using Invest.Entities;
using Invest.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace InvestAPI.Controllers
{
    [Route("api/ListaOperacao")]
    [ApiController]
    public class ListaOperacaoController : Controller
    {
        protected IOperacaoServices _relatorioServices;

        public ListaOperacaoController(IOperacaoServices operacaoServices)
        {
            _relatorioServices = operacaoServices;
        }

        //[HttpGet]
        //public IList<ListaOperacao> ListarOperacoes()
        //{
        //    try
        //    {
        //        var lista = _relatorioServices.ListarOperacoes();
        //        return lista;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}
    }
}
