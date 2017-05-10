using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Data;
using Microsoft.EntityFrameworkCore;

namespace Entidades.Models
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly EstoqueContext _context;

        public ProdutoRepository(EstoqueContext context)
        {
            _context = context;
        }

        public async Task<IList<Produto>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public void Add(Produto item)
        {
            _context.Produtos.Add(item);
            _context.SaveChanges();
        }

        public async Task AddAsync(Produto item)
        {
            _context.Produtos.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> GetByIdAsync(long id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(t => t.IdProduto == id);
        }
        public Produto GetById(long id)
        {
            return _context.Produtos.FirstOrDefault(t => t.IdProduto == id);
        }

        public void Remove(long id)
        {
            var entity = _context.Produtos.First(t => t.IdProduto == id);
            _context.Produtos.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Produto item)
        {
            _context.Produtos.Update(item);
            _context.SaveChanges();
        }
    }
}