using System.Collections.Generic;

namespace Entidades.Models
{
    public interface IClienteRepository
    {
        void Add(Cliente item);
        IEnumerable<Cliente> GetAll();
        Cliente Find(long key);
        void Remove(long key);
        void Update(Cliente item);
    }
}