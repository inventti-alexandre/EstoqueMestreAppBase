using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Entidades.Models;

namespace Entidades.Data
{
    public class DbInitializer
    {

        public static void Initialize(EstoqueContext context)
        {
            context.Database.EnsureCreated();
            if (context.Clientes.Any())
            {
                return;
            }

            var clientes = new Cliente[]
            {
                new Cliente{Nome="Alex Carson",Email="alex@gmail.com",DataCadastro=DateTime.Parse("2005-09-01")},
            };

            foreach (Cliente s in clientes)
            {
                context.Clientes.Add(s);
            }
            context.SaveChanges();
        }
    }
}
