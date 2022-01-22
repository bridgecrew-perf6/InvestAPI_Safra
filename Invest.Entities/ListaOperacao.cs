using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.Entities
{
    public class ListaOperacao
    {
        public string AcaoId { get; set; }
        public string RazaoSocial { get; set; }
        public string TipoOperacao { get; set; }
        public DateTime DataOperacao { get; set; }
        public int Quantidade { get; set; }
        public double ValorAcao { get; set; }
        public double ValorTotal { get; set; }

    }
}
