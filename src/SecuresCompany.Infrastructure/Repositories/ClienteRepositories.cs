using Microsoft.EntityFrameworkCore;
using SecuresCompany.Domain.Entities;
using SecuresCompany.Domain.Interfaces;
using SecuresCompany.Persistence.Context;

namespace SecuresCompany.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SecureCompanyContext _context;

        public ClienteRepository(SecureCompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
            => await _context.Clients.ToListAsync();

        public async Task<Client> GetByIdAsync(int id)
            => await _context.Clients.FindAsync(id);

        public async Task AddAsync(Client cliente)
        {
            await _context.Clients.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client cliente)
        {
            _context.Clients.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clients.FindAsync(id);
            if (cliente != null)
            {
                _context.Clients.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}