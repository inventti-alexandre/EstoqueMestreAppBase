using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Models;
using EstoqueCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EstoqueCore.Tests
{
    public class TestSimpleClientController
    {
        private IList<Cliente> GetTestSessions()
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
        public async Task GetAllClientes()
        {
            //Arrange
            //var mockRepo = new Mock<IClienteRepository>();
            //mockRepo.Setup(repo => repo.GetAllAsync())
            //        .Returns(Task.FromResult(GetTestSessions()));
            //var controller = new ClienteController(mockRepo.Object);

            //// Act
            //var result = await controller.GetAllAsync();
            //Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetClienteById()
        {
            // Arrange
            //var expectedID = 1;
            //var mockRepo = new Mock<IClienteRepository>();
            //mockRepo.Setup(repo => repo.GetByIdAsync(expectedID))
            //        .Returns(Task.FromResult(GetTestSessions().FirstOrDefault(s => s.IdCliente == expectedID)));
            //var controller = new ClienteController(mockRepo.Object);

            //// Act
            //var result = await controller.GetByIdAsync(expectedID);
            //var okResult = result as OkObjectResult;

            //Assert.NotNull(okResult);
            //Assert.Equal(200, okResult.StatusCode);
        }

        [Fact] 
        public async Task CreateClient()
        {
            // Arrange
            var expected = new Cliente()
            {
                IdCliente = 3,
                Nome = "Test Name",
                Email = "test@hotmail.com"
            };
            var newCliente = new Cliente()
            {
                Nome = "Test Name",
                Email = "test@hotmail.com"
            };

            //var mockRepo = new Mock<IClienteRepository>();
            //mockRepo.Setup(repo => repo.AddAsync(expected))
            //        .Returns(Task.FromResult(newCliente));

            //var controller = new ClienteController(mockRepo.Object);

            //// Act
            //var result = await controller.CreateAsync(newCliente);

            ////Assert
            //var okResult = result as CreatedAtRouteResult;
            //Assert.NotNull(okResult);
            //Assert.Equal(201, okResult.StatusCode);
        }

        [Fact(Skip = "Pendente de implementação")]
        public void UpdateClient()
        {

        }

        [Fact(Skip = "Pendente de implementação")]
        public async Task DeleteClient()
        {

        }
    }
}