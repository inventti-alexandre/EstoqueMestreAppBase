using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public interface IProdutoRepository
    {
        void Add(Produto item);
        Task AddAsync(Produto item);
        Task<IList<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(long id);
        Produto GetById(long id);
        void Remove(long id);
        void Update(Produto item);
    }
}