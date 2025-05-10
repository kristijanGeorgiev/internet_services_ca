using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CarRental.Application.DTOs;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Application.Services;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientsController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

      
        [HttpGet]
        public async Task<ActionResult<List<ClientDto>>> GetAll()
        {
            var clients = await _clientService.GetAllAsync();
            var clientsDto = _mapper.Map<List<ClientDto>>(clients);
            return Ok(clientsDto);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetById(int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
                return NotFound(new { message = "Client not found" });

            var clientDto = _mapper.Map<ClientDto>(client);
            return Ok(clientDto);
        }

      
        [HttpPost]
        public async Task<ActionResult<ClientDto>> Create(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _clientService.CreateAsync(client);

            var createdDto = _mapper.Map<ClientDto>(client);
            return CreatedAtAction(nameof(GetById), new { id = client.Id }, createdDto);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClientDto ClientDto)
        {

            var client = _mapper.Map<Client>(ClientDto);
            client.Id = id;

            var success = await _clientService.UpdateAsync(id, client);
            if (!success)
                return NotFound(new { message = "Client not found for update." });
            return NoContent();
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _clientService.DeleteAsync(id);
            if (deleted == null)
                return NotFound(new { message = "Client not found for deletion." });

            return NoContent();
        }
    }
}
