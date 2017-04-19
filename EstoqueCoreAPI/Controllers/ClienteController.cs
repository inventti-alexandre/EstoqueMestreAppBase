using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return new ObjectResult(item);
        }
    }
}

