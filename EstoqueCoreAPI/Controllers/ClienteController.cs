using System;
using System.Collections.Generic;
using Entidades.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueCore.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        /// <summary>
        /// Retorna todos os clientes
        /// </summary>
        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        /// <summary>
        /// Retorna um cliente pelo seu ID
        /// </summary>
        /// <param name="id">Chave primária no banco</param>
        [HttpGet("{id}", Name = "GetCliente")]
        public IActionResult GetById(long id)
        {
            var item = _clienteRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new OkObjectResult(item);
        }

        /// <summary>
        /// Registra um novo cliente
        /// </summary>
        /// <param name="item">Objeto cliente</param>
        [HttpPost]
        public IActionResult Create([FromBody] Cliente item)
        {
            if (item == null){
                return BadRequest();
            }
                   
            _clienteRepository.Add(item);

            return CreatedAtRoute("GetCliente", new { id = item.IdCliente }, item);
        }
    }
}

