
using System.Collections.Generic;

namespace Invest.Entities.Models
{
    public class Acao
    {
        public string AcaoId { get; set; }
        public string RazaoSocial { get; set; }
        public IEnumerable<Operacao> operacao { get; set; }
    }
}
