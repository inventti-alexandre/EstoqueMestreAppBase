using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Data;
using Microsoft.EntityFrameworkCore;

namespace Entidades.Models
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly EstoqueContext _context;

        public EstoqueRepository(EstoqueContext context)
        {
            _context = context;
        }

        public async Task<IList<Estoque>> GetAllAsync()
        {
            return await _context.Estoques.ToListAsync();
        }

        public void Add(Estoque item)
        {
            _context.Estoques.Add(item);
            _context.SaveChanges();
        }

        public async Task AddAsync(Estoque item)
        {
            _context.Estoques.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Estoque> GetByIdAsync(long id)
        {
            return await _context.Estoques.FirstOrDefaultAsync(t => t.IdEstoque == id);
        }
        public Estoque GetById(long id)
        {
            return _context.Estoques.FirstOrDefault(t => t.IdEstoque == id);
        }

        public void Remove(long id)
        {
            var entity = _context.Estoques.First(t => t.IdEstoque == id);
            _context.Estoques.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Estoque item)
        {
            _context.Estoques.Update(item);
            _context.SaveChanges();
        }
    }
}