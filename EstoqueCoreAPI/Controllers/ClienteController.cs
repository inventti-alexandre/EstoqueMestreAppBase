using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EstoqueCore.Controllers
{

    [ServiceFilter(typeof(LogFilter))]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IClienteRepository clienteRepository, ILogger<ClienteController> logger)
        {
            _clienteRepository = clienteRepository;
            _logger = logger;
        }

        /// <summary>
        /// Retorna todos os clientes
        /// </summary>
        [HttpGet]
        [Route("Cliente/GetAllAsync")]
        public async Task<IList<Cliente>> GetAllAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        [HttpGet]
        public JsonResult GetAll() {
            var lista = _clienteRepository.GetAll();
            if(lista != null) {
                return this.Json(new {
                    Result = lista,
                    Error = false
                });
            }

            return this.Json(new {
                Result = "Nenhum CLIENTE encontrado.",
                Error = true
            });
        }

        /// <summary>
        /// Retorna um cliente pelo seu ID
        /// </summary>
        /// <param name="id">Chave primária no banco</param>
        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            Cliente item;
            using (_logger.BeginScope("ScopeLog GetByIdAsync"))
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "Getting item {ID}", id);
                item = await _clienteRepository.GetByIdAsync(id);
                if (item == null){
                    _logger.LogWarning(LoggingEvents.GET_ITEM_NOTFOUND, "GetById({ID}) NOT FOUND", id);
                    return NotFound(id);
                }
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


        /// <summary>
        /// Deleta um determinado cliente
        /// </summary>
        /// <param name="id">Id do cliente que será deletado</param>
        [HttpPost("{id}", Name = "DeletarCliente")]
        public JsonResult DeletarCliente(long id) {
            _logger.LogInformation(LoggingEvents.GET_ITEM, "Getting item {ID}", id);
            Cliente model = _clienteRepository.GetById(Convert.ToInt16(id));
            if(model != null) {
                string msg = "Cliente deletado.";
                try{
                    _clienteRepository.Remove(id);                    
                }
                catch (DbUpdateException ex){
                    _logger.LogWarning(LoggingEvents.DELETE_ITEM, ex, "DeletarCliente({ID})", id);
                    msg = "Falha ao deletar o cliente";
                }

                return this.Json(new {
                    Error = false,
                    Result = msg
                });
            }

            _logger.LogWarning(LoggingEvents.GET_ITEM_NOTFOUND, "GetById({ID}) NOT FOUND", id);
            return this.Json(new {
                Result = "Nenhum cliente encontrado.",
                Error = true
            }); // JsonRequestBehavior.AllowGet não existe mais no aspnetcore 1.1
        }
    }
}

