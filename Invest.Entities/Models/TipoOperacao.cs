
namespace Invest.Entities.Models
{
    public class TipoOperacao
    {
        public int tipoId { get; set; }
        public string sigla { get; set; }
        public string descricao { get; set; }
        public Operacao operacao { get; set; }
    }
}
