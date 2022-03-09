using System;

namespace Invest.Entities.Models
{
    public class Operacao
    {
        public int OperacaoId { get; set; }

        public string AcaoId { get; set; }
        
        public Acao acao { get; set; }

        public double PrecoAcao { get; set; }

        public int Quantidade { get; set; }

        public int TipoOperacaoId { get; set; }

        public TipoOperacao TipoOperacao { get; set; }
        
        public DateTime Data { get; set; }

        public double Total { get; set; }
    }        
}
