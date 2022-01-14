
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invest.Entities
{
    [Table("acao")]
    public class Acao
    {
        [Key]
        [Column("acao_id")]
        public string AcaoId { get; set; }
        [Required]
        [MaxLength(100)]
        [Column("razao_social")]
        public string RazaoSocial { get; set; }
    }
}
