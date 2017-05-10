using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public interface IMovimentacaoRepository
    {
        void Add(Movimentacao item);
        Task AddAsync(Movimentacao item);
        Task<IList<Movimentacao>> GetAllAsync();
        Task<Movimentacao> GetByIdAsync(long id);
        Movimentacao GetById(long id);
        void Remove(long id);
        void Update(Movimentacao item);
    }
}