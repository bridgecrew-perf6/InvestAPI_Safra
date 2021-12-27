using System.ComponentModel.DataAnnotations;

namespace Invest.Entities
{
    public enum TipoOperacao
    {
        [Display(Name = "C")]
        COMPRA = 1,
        [Display(Name = "V")]
        VENDA = 2
    }
}
