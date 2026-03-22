using SecuresCompany.Application.Contract;
using SecuresCompany.Application.Core;
using SecuresCompany.Application.Dtos;
using SecuresCompany.Domain.Interfaces;
using SecuresCompany.Application.Core;
using SecuresCompany.Domain.Entities;

namespace SecuresCompany.Application.Services;

public class ClienteService : BaseService, IClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        var clientes = await _repository.GetAllAsync();
        return clientes.Select(c => new ClienteDto
        {
            clienteID = c.Id,
            nombreCliente = c.Nombre,
            numeroPoliza = c.NumeroPoliza,
            tipoSeguro = c.TipoSeguro,
            tipoCliente = c.TipoCliente,
            saldoPendiente = c.SaldoPendiente,
            email = c.Email,
            telefono = c.Telefono
        });
    }

    public async Task<ClienteDto> GetByIdAsync(int id)
    {
        var cliente = await _repository.GetByIdAsync(id);
        if (cliente == null) return null;
        return new ClienteDto
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
    }

    public async Task<ServiceResult> CreateAsync(CrearClienteDto dto)
    {
        if (string.IsNullOrEmpty(dto.nombreCliente))
            return Error("El nombre del cliente es requerido.");
        if (string.IsNullOrEmpty(dto.numeroPoliza))
            return Error("El número de póliza es requerido.");
        if (string.IsNullOrEmpty(dto.tipoSeguro))
            return Error("El tipo de seguro es requerido.");

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

        await _repository.AddAsync(cliente);
        return Success("Cliente creado exitosamente.");
    }

    public async Task<ServiceResult> AddAsync(ClienteDto dto)
        => await CreateAsync(new CrearClienteDto
        {
            nombreCliente = dto.nombreCliente,
            numeroPoliza = dto.numeroPoliza,
            tipoSeguro = dto.tipoSeguro,
            tipoCliente = dto.tipoCliente,
            email = dto.email,
            telefono = dto.telefono
        });

    public async Task<ServiceResult> UpdateAsync(ClienteDto dto)
    {
        var cliente = await _repository.GetByIdAsync(dto.clienteID);
        if (cliente == null)
            return Error("Cliente no encontrado.");

        cliente.Nombre = dto.nombreCliente;
        cliente.NumeroPoliza = dto.numeroPoliza;
        cliente.TipoSeguro = dto.tipoSeguro;
        cliente.TipoCliente = dto.tipoCliente;
        cliente.Email = dto.email;
        cliente.Telefono = dto.telefono;

        await _repository.UpdateAsync(cliente);
        return Success("Cliente actualizado exitosamente.");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var cliente = await _repository.GetByIdAsync(id);
        if (cliente == null)
            return Error("Cliente no encontrado.");

        await _repository.DeleteAsync(id);
        return Success("Cliente eliminado exitosamente.");
    }
}