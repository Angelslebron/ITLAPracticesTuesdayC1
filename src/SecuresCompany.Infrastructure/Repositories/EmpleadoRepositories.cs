using SecuresCompany.Domain.Entities;
using SecuresCompany.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using SecuresCompany.Persistence.Context;

namespace SecuresCompany.Infrastructure.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly SecureCompanyContext _context;

        public EmpleadoRepository(SecureCompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
            => await _context.Empleados.ToListAsync();

        public async Task<Empleado> GetByIdAsync(int id)
            => await _context.Empleados.FindAsync(id);

        public async Task AddAsync(Empleado empleado)
        {
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }
    }
}