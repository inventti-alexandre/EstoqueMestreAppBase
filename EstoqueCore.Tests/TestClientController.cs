using System;
using System.Collections.Generic;
using System.Linq;
using Entidades.Models;
using EstoqueCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EstoqueCore.Tests
{
    public class TestSimpleClientController
    {
        private List<Cliente> GetTestSessions()
        {
            var sessions = new List<Cliente>
            {
                new Cliente
                {
                    IdCliente = 1,
                    Nome = "Alex Carson",
                    Email = "alex@gmail.com",
                    DataCadastro = DateTime.Parse("2005-09-01")
                },
                new Cliente
                {
                    IdCliente = 2,
                    Nome = "David Ruskel",
                    Email = "fruy77@gmail.com"
                }
            };
            return sessions;
        }

        [Fact]
        public void GetAllClientes()
        {
            // Arrange
            var mockRepo = new Mock<IClienteRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(GetTestSessions());
            var controller = new ClienteController(mockRepo.Object);

            // Act
            var result = controller.GetAll();
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetClienteById()
        {
            // Arrange
            var expectedID = 1;
            var mockRepo = new Mock<IClienteRepository>();
            mockRepo.Setup(repo => repo.Find(expectedID))
                .Returns(GetTestSessions().FirstOrDefault(s => s.IdCliente == expectedID));
            var controller = new ClienteController(mockRepo.Object);

            // Act
            var result = controller.GetById(expectedID);
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact(Skip = "Pendente de implementação")] 
        public void CreateClient()
        {
            
        }
    }
}