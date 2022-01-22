using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invest.Entities
{
    [Table("operacao")]
    public class Operacao
    {
        [Key]
        [Column("operacao_id")]
        public int OperacaoId { get; set; }

        [ForeignKey("operacao_fk")]
        [Column("acao_id")]
        public string AcaoId { get; set; }
        
        public Acao acao { get; set; }

        [Column("preco_acao")] 
        public double PrecoAcao { get; set; }

        [Column("qtd_acao")]
        public int Quantidade { get; set; }

        [ForeignKey("operacao_fk_1")]
        [Column("tipo_operacao_id")]
        public TipoOperacao TipoOperacao { get; set; }
        
        [Column("data_operacao")]
        public DateTime Data { get; set; }

        [Column("total_operacao")]
        public double Total { get; set; }
    }        
}
