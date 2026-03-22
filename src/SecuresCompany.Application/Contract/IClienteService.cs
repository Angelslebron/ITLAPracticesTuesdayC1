using SecuresCompany.Application.Core;
using SecuresCompany.Application.Dtos;
using SecuresCompany.Application.Core;


namespace SecuresCompany.Application.Contract;

public interface IClienteService : IBaseService<ClienteDto>
{
    Task<ServiceResult> CreateAsync(CrearClienteDto dto);
}