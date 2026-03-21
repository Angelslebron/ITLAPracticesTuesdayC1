using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SecuresCompany.Domain.Entities;

namespace SecuresCompany.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task AddAsync(Client cliente);
        Task UpdateAsync(Client cliente);
        Task DeleteAsync(int id);
    }
}
