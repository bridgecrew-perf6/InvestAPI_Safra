using Invest.Repositories.Context;
using Invest.Repositories.Contracts;

namespace Invest.Repositories.Repositories
{
    public class TipoOperacaoRepository : BaseRepository, ITipoOperacaoRepository
    {
        public TipoOperacaoRepository(DataContext context) : base(context)
        {
        }
    }
}
