using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecuresCompany.Application.Dtos;
using SecuresCompany.Persistence.Context;

namespace SecuresCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly SecureCompanyContext _context;

        public EmpleadosController(SecureCompanyContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> GetEmpleados()
        {
            var empleados = await _context.Empleados
                .Select(e => new EmpleadoDto
                {
                    empleadoID = e.Id,               
                    idEmpleado = e.IdEmpleado,
                    nombre = e.Nombre,
                    departamento = e.Departamento,
                    puesto = e.Puesto,
                    salarioBase = e.SalarioBase,
                    fechaIngreso = e.fechaIngreso            
                })
                .ToListAsync();

            return Ok(empleados);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDto>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return NotFound();

            var dto = new EmpleadoDto
            {
                empleadoID = empleado.Id,
                idEmpleado = empleado.IdEmpleado,
                nombre = empleado.Nombre,
                departamento = empleado.Departamento,
                puesto = empleado.Puesto,
                salarioBase = empleado.SalarioBase,
                fechaIngreso = empleado.fechaIngreso
            };
            return Ok(dto);
        }

        
        [HttpPost]
        public async Task<ActionResult<EmpleadoDto>> PostEmpleado(CrearEmpleadoDto dto)
        {
            var empleado = new Domain.Entities.Empleado
            {
                IdEmpleado = dto.idEmpleado,
                Nombre = dto.nombre,
                Departamento = dto.departamento,
                Puesto = dto.puesto,
                SalarioBase = dto.salarioBase,
                fechaIngreso = dto.fechaIngreso          
            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            var responseDto = new EmpleadoDto
            {
                empleadoID = empleado.Id,
                idEmpleado = empleado.IdEmpleado,
                nombre = empleado.Nombre,
                departamento = empleado.Departamento,
                puesto = empleado.Puesto,
                salarioBase = empleado.SalarioBase,
                fechaIngreso = empleado.fechaIngreso
            }; 

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Id }, responseDto);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, CrearEmpleadoDto dto)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return NotFound();

            empleado.IdEmpleado = dto.idEmpleado;
            empleado.Nombre = dto.nombre;
            empleado.Departamento = dto.departamento;
            empleado.Puesto = dto.puesto;
            empleado.SalarioBase = dto.salarioBase;
            empleado.fechaIngreso = dto.fechaIngreso;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return NotFound();

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}