using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Data;
using Microsoft.EntityFrameworkCore;

namespace Entidades.Models
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly EstoqueContext _context;

        public ClienteRepository(EstoqueContext context)
        {
            _context = context;
        }

        public async Task<IList<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public void Add(Cliente item)
        {
            _context.Clientes.Add(item);
            _context.SaveChanges();
        }

        public async Task AddAsync(Cliente item)
        {
            _context.Clientes.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> GetByIdAsync(long id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(t => t.IdCliente == id);
        }
        public Cliente GetById(long id)
        {
            return _context.Clientes.FirstOrDefault(t => t.IdCliente == id);
        }

        public void Remove(long id)
        {
            var entity = _context.Clientes.First(t => t.IdCliente == id);
            _context.Clientes.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Cliente item)
        {
            _context.Clientes.Update(item);
            _context.SaveChanges();
        }
    }
}