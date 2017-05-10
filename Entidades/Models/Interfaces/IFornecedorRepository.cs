using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public interface IFornecedorRepository
    {
        void Add(Fornecedor item);
        Task AddAsync(Fornecedor item);
        Task<IList<Fornecedor>> GetAllAsync();
        Task<Fornecedor> GetByIdAsync(long id);
        Fornecedor GetById(long id);
        void Remove(long id);
        void Update(Fornecedor item);
    }
}