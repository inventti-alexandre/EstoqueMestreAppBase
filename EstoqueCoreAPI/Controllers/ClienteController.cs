using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Retorna todos os clientes
        /// </summary>
        [HttpGet]
        public async Task<IList<Cliente>> GetAllAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        /// <summary>
        /// Retorna um cliente pelo seu ID
        /// </summary>
        /// <param name="id">Chave primária no banco</param>
        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var item = await _clienteRepository.GetByIdAsync(id);
            if (item == null){
                return NotFound(id);
            }
            return Ok(item);
        }

        /// <summary>
        /// Registra um novo cliente de forma assíncrona
        /// </summary>
        /// <param name="item">Objeto cliente</param>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Cliente item)
        {
            if (item == null){
                return BadRequest();
            }
                   
            await _clienteRepository.AddAsync(item);
            return CreatedAtRoute("GetCliente", new { id = item.IdCliente }, item);
        }

        /// <summary>
        /// Atualiza os dados de um cliente
        /// </summary>
        /// <param name="id">Id do objeto cliente que será atualizado</param>
        /// <param name="item">Objeto cliente</param>
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Cliente item)
        {
            if (item == null || item.IdCliente != id){
                return BadRequest();
            }

            var cliente = _clienteRepository.GetById(id);
            if (cliente == null){
                return NotFound();
            }

            cliente.Nome = item.Nome;
            cliente.Email = item.Email;
            cliente.DataCadastro = item.DataCadastro;
            cliente.Deletado = item.Deletado;

            _clienteRepository.Update(cliente);
            return new NoContentResult();
        }

        /// <summary>
        /// Remove um determinado cliente
        /// </summary>
        /// <param name="id">Id do cliente que será excluído</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null){
                return NotFound();
            }

            _clienteRepository.Remove(id);
            return new NoContentResult();
        }
    }
}

