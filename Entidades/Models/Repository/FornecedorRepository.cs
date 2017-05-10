using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Data;
using Microsoft.EntityFrameworkCore;

namespace Entidades.Models
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly EstoqueContext _context;

        public FornecedorRepository(EstoqueContext context)
        {
            _context = context;
        }

        public async Task<IList<Fornecedor>> GetAllAsync()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public void Add(Fornecedor item)
        {
            _context.Fornecedores.Add(item);
            _context.SaveChanges();
        }

        public async Task AddAsync(Fornecedor item)
        {
            _context.Fornecedores.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Fornecedor> GetByIdAsync(long id)
        {
            return await _context.Fornecedores.FirstOrDefaultAsync(t => t.IdFornecedor == id);
        }
        public Fornecedor GetById(long id)
        {
            return _context.Fornecedores.FirstOrDefault(t => t.IdFornecedor == id);
        }

        public void Remove(long id)
        {
            var entity = _context.Fornecedores.First(t => t.IdFornecedor == id);
            _context.Fornecedores.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Fornecedor item)
        {
            _context.Fornecedores.Update(item);
            _context.SaveChanges();
        }
    }
}