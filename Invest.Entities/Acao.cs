
using System.ComponentModel.DataAnnotations;

namespace Invest.Entities
{
    public class Acao
    {
        [Key]
        public string AcaoId { get; set; }
        [Required]
        [MaxLength(100)]
        public string RazaoSocial { get; set; }
    }
}
