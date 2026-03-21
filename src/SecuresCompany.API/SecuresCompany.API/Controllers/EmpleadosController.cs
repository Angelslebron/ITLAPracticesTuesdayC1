using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecuresCompany.API.Data;
using SecuresCompany.API.Data.Entities;
using SecuresCompany.API.Models.Dtos;

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
                    empleadoID = e.EmpleadoId,               
                    idEmpleado = e.IdEmpleado,
                    nombre = e.Nombre,
                    departamento = e.Departamento,
                    puesto = e.Puesto,
                    salarioBase = e.SalarioBase,
                    fechaIngreso = e.FechaIngreso            
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
                empleadoId = empleado.EmpleadoId,
                idEmpleado = empleado.IdEmpleado,
                nombre = empleado.Nombre,
                departamento = empleado.Departamento,
                puesto = empleado.Puesto,
                salarioBase = empleado.SalarioBase,
                fechaIngreso = empleado.FechaIngreso
            };
            return Ok(dto);
        }

        
        [HttpPost]
        public async Task<ActionResult<EmpleadoDto>> PostEmpleado(CrearEmpleadoDto dto)
        {
            var empleado = new Empleado
            {
                IdEmpleado = dto.idEmpleado,
                Nombre = dto.nombre,
                Departamento = dto.departamento,
                Puesto = dto.puesto,
                SalarioBase = dto.salarioBase,
                FechaIngreso = dto.fechaIngreso          
            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            var responseDto = new EmpleadoDto
            {
                empleadoID = empleado.EmpleadoId,
                idEmpleado = empleado.IdEmpleado,
                nombre = empleado.Nombre,
                departamento = empleado.Departamento,
                puesto = empleado.Puesto,
                salarioBase = empleado.SalarioBase,
                fechaIngreso = empleado.FechaIngreso
            }; 

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.EmpleadoId }, responseDto);
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
            empleado.FechaIngreso = dto.fechaIngreso;

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