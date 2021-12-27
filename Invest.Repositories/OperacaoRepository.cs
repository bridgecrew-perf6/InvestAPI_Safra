using Invest.Entities;
using Invest.Repositories.Context;
using Invest.Repositories.Contracts;

namespace Invest.Repositories
{
    public class OperacaoRepository : BaseRepository<Operacao>, IOperacaoRepository
    {
        public OperacaoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public static OperacaoRepository GetOperacaoRepository(DataContext context) { return new OperacaoRepository(context); }        
    }
}
