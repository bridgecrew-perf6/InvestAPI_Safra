using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invest.Entities
{
    public class Operacao
    {
        [Key]
        public int OperacaoId { get; set; }
        [ForeignKey("AcaoFk")]
        public string AcaoId { get; set; }
        public Acao acao { get; set; }
        public double PrecoAcao { get; set; }
        public int Quantidade { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
        public DateTime Data
        {
            get
            {
                return DateTime.Now;
            }
        }
        public double Total
        {
            get
            {
                return (PrecoAcao * Quantidade) + CustoOperacao;
            }
        }
        private double CustoOperacao
        {
            get
            {
                return 5.00 + (0.0325 * PrecoAcao / 100);
            }
        }
    }        
}
