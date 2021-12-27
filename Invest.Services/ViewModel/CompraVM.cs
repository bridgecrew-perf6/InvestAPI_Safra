using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Services.ViewModel
{
    public class CompraVM
    {
        public int OperacaoId { get; set; }
        public string AcaoId { get; set; }
        public double Preco { get; set; }
        public int Qtd { get; set; }
    }
}
