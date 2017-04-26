using System;
using System.Linq;
using Entidades.Models;

namespace Entidades.Data
{
    public class DbInitializer
    {

        public static void Initialize(EstoqueContext context)
        {
            //Retorna true se o banco foi criado, false se já existe
            context.Database.EnsureCreated();

            //Executa o Seed do banco nas tabelas de Carga
            #region DADOS CLIENTES
                if (context.Clientes.Any())
                    return;
                
                var clientes = new Cliente[]
                {
                    new Cliente{Nome="Alex Carson",Email="alex@gmail.com",DataCadastro=DateTime.Parse("2005-09-01")},
                    new Cliente{Nome="David Ruskel",Email="fruy77@gmail.com"},
                };

                foreach (Cliente s in clientes)
                {
                    context.Clientes.Add(s);
                }
                context.SaveChanges();
            #endregion

            #region DADOS FORNECEDORES
                //if (context.Fornecedor.Any())
                //    return;
                
                //var fornecedores = new Fornecedor[]
                //{
                //    new Fornecedor{RazaoSocial="Techshift",
                //                    Cnpj=null,
                //                    Telefone="",
                //                    Ativo=true,
                //                    DataCadastro=DateTime.Parse("2017-01-01")},
                //};

                //foreach (Fornecedor s in fornecedores)
                //{
                //    context.Fornecedor.Add(s);
                //}
                //context.SaveChanges();
            #endregion
        }
    }
}
