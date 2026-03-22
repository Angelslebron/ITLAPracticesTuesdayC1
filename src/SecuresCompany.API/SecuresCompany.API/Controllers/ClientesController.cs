using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecuresCompany.Domain.Entities;
using SecuresCompany.Application.Dtos;
using SecuresCompany.Persistence.Context;

namespace SecureCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly SecureCompanyContext _context;

        public ClientesController(SecureCompanyContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
        {
            var clientes = await _context.Clients
                .Select(c => new ClienteDto
                {
                    clienteID = c.Id,
                    nombreCliente = c.Nombre,
                    numeroPoliza = c.NumeroPoliza,
                    tipoSeguro = c.TipoSeguro,
                    tipoCliente = c.TipoCliente,
                    saldoPendiente = c.SaldoPendiente,
                    email = c.Email,
                    telefono = c.Telefono
                })
                .ToListAsync();

            return Ok(clientes);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetCliente(int id)
        {
            var cliente = await _context.Clients.FindAsync(id);
            if (cliente == null) return NotFound();

            var dto = new ClienteDto
            {
                clienteID = cliente.Id,
                nombreCliente = cliente.Nombre,
                numeroPoliza = cliente.NumeroPoliza,
                tipoSeguro = cliente.TipoSeguro,
                tipoCliente = cliente.TipoCliente,
                saldoPendiente = cliente.SaldoPendiente,
                email = cliente.Email,
                telefono = cliente.Telefono
            };
            return Ok(dto);
        }

        
        [HttpPost]
        public async Task<ActionResult<ClienteDto>> PostCliente(CrearClienteDto dto)
        {
  
            var cliente = new Client
            {
                Nombre = dto.nombreCliente,
                NumeroPoliza = dto.numeroPoliza,
                TipoSeguro = dto.tipoSeguro,
                TipoCliente = dto.tipoCliente,
                Email = dto.email,
                Telefono = dto.telefono,
                FechaIngreso = DateTime.Now,
                SaldoPendiente = 0
            };

            _context.Clients.Add(cliente);
            await _context.SaveChangesAsync();

            var responseDto = new ClienteDto
            {
                clienteID = cliente.Id,
                nombreCliente = cliente.Nombre,
                numeroPoliza = cliente.NumeroPoliza,
                tipoSeguro = cliente.TipoSeguro,
                tipoCliente = cliente.TipoCliente,
                saldoPendiente = cliente.SaldoPendiente,
                email = cliente.Email,
                telefono = cliente.Telefono
            };
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, responseDto);
        }

  
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, CrearClienteDto dto)
        {
            var cliente = await _context.Clients.FindAsync(id);
            if (cliente == null) return NotFound();

            cliente.Nombre = dto.nombreCliente;
            cliente.NumeroPoliza = dto.numeroPoliza;
            cliente.TipoSeguro = dto.tipoSeguro;
            cliente.TipoCliente = dto.tipoCliente;
            cliente.Email = dto.email;
            cliente.Telefono = dto.telefono;

            await _context.SaveChangesAsync();
            return NoContent();
        }

  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clients.FindAsync(id);
            if (cliente == null) return NotFound();

            _context.Clients.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}