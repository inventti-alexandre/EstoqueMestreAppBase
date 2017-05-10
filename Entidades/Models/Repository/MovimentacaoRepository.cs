using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Data;
using Microsoft.EntityFrameworkCore;

namespace Entidades.Models
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly EstoqueContext _context;

        public MovimentacaoRepository(EstoqueContext context)
        {
            _context = context;
        }

        public async Task<IList<Movimentacao>> GetAllAsync()
        {
            return await _context.Movimentacoes.ToListAsync();
        }

        public void Add(Movimentacao item)
        {
            _context.Movimentacoes.Add(item);
            _context.SaveChanges();
        }

        public async Task AddAsync(Movimentacao item)
        {
            _context.Movimentacoes.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Movimentacao> GetByIdAsync(long id)
        {
            return await _context.Movimentacoes.FirstOrDefaultAsync(t => t.IdMovimentacao == id);
        }
        public Movimentacao GetById(long id)
        {
            return _context.Movimentacoes.FirstOrDefault(t => t.IdMovimentacao == id);
        }

        public void Remove(long id)
        {
            var entity = _context.Movimentacoes.First(t => t.IdMovimentacao == id);
            _context.Movimentacoes.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Movimentacao item)
        {
            _context.Movimentacoes.Update(item);
            _context.SaveChanges();
        }
    }
}