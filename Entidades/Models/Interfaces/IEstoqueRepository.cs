using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public interface IEstoqueRepository
    {
        void Add(Estoque item);
        Task AddAsync(Estoque item);
        Task<IList<Estoque>> GetAllAsync();
        Task<Estoque> GetByIdAsync(long id);
        Estoque GetById(long id);
        void Remove(long id);
        void Update(Estoque item);
    }
}