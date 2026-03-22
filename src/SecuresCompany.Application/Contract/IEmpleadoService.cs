using SecuresCompany.Application.Core;
using SecuresCompany.Application.Dtos;
using SecuresCompany.Application.Core;
using SecuresCompany.Domain.Interfaces;

namespace SecuresCompany.Application.Contract;

public interface IEmpleadoService : IBaseService<EmpleadoDto>
{
    Task<ServiceResult> CreateAsync(CrearEmpleadoDto dto);
}