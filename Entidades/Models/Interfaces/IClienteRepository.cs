using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public interface IClienteRepository
    {
        void Add(Cliente item);
        Task AddAsync(Cliente item);
        IList<Cliente> GetAll();
        Task<IList<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(long id);
        Cliente GetById(long id);
        void Remove(long id);
        void Update(Cliente item);
    }
}