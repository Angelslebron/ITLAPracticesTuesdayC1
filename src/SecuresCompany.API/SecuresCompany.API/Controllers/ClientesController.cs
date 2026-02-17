using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecuresCompany.API.Data;
using SecuresCompany.API.Data.Entities;
using SecuresCompany.API.Models.Dtos;

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
                    clienteID = c.ClienteId,
                    nombreCliente = c.NombreCliente,
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

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetCliente(int id)
        {
            var cliente = await _context.Clients.FindAsync(id);
            if (cliente == null) return NotFound();

            var dto = new ClienteDto
            {
                clienteID = cliente.ClienteId,
                nombreCliente = cliente.NombreCliente,
                numeroPoliza = cliente.NumeroPoliza,
                tipoSeguro = cliente.TipoSeguro,
                tipoCliente = cliente.TipoCliente,
                saldoPendiente = cliente.SaldoPendiente,
                email = cliente.Email,
                telefono = cliente.Telefono
            };
            return Ok(dto);
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<ClienteDto>> PostCliente(CrearClienteDto dto)
        {
  
            var cliente = new Client
            {
                NombreCliente = dto.nombreCliente,
                NumeroPoliza = dto.numeroPoliza,
                TipoSeguro = dto.tipoSeguro,
                TipoCliente = dto.tipoCliente,
                Email = dto.email,
                Telefono = dto.telefono,
                fechaRegistro = DateTime.Now,
                SaldoPendiente = 0
            };

            _context.Clients.Add(cliente);
            await _context.SaveChangesAsync();

            var responseDto = new ClienteDto
            {
                clienteID = cliente.ClienteId,
                nombreCliente = cliente.NombreCliente,
                numeroPoliza = cliente.NumeroPoliza,
                tipoSeguro = cliente.TipoSeguro,
                tipoCliente = cliente.TipoCliente,
                saldoPendiente = cliente.SaldoPendiente,
                email = cliente.Email,
                telefono = cliente.Telefono
            };
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.ClienteId }, responseDto);
        }

  
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, CrearClienteDto dto)
        {
            var cliente = await _context.Clients.FindAsync(id);
            if (cliente == null) return NotFound();

            cliente.NombreCliente = dto.nombreCliente;
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