using System;
using System.Collections.Generic;
using System.Linq;
using Entidades.Data;

namespace Entidades.Models
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly EstoqueContext _context;

        public ClienteRepository(EstoqueContext context)
        {
            _context = context;

            if( _context.Clientes.Count() == 0)
                Add(new Cliente { Nome = "Item1" });
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public void Add(Cliente item)
        {
            _context.Clientes.Add(item);
            _context.SaveChanges();
        }

        public Cliente Find(long key)
        {
            return _context.Clientes.FirstOrDefault(t => t.IdCliente == key);
        }

        public void Remove(long key)
        {
            var entity = _context.Clientes.First(t => t.IdCliente == key);
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