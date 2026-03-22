using SecuresCompany.Application.Contract;
using SecuresCompany.Application.Core;
using SecuresCompany.Application.Dtos;
using SecuresCompany.Domain.Interfaces;
using SecuresCompany.Application.Core;
using SecuresCompany.Domain.Entities;

namespace SecuresCompany.Application.Services;

public class EmpleadoService : BaseService, IEmpleadoService
{
    private readonly IEmpleadoRepository _repository;

    public EmpleadoService(IEmpleadoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EmpleadoDto>> GetAllAsync()
    {
        var empleados = await _repository.GetAllAsync();
        return empleados.Select(e => new EmpleadoDto
        {
            empleadoID = e.Id,
            idEmpleado = e.IdEmpleado,
            nombre = e.Nombre,
            departamento = e.Departamento,
            puesto = e.Puesto,
            salarioBase = e.SalarioBase,
            fechaIngreso = e.fechaIngreso
        });
    }

    public async Task<EmpleadoDto> GetByIdAsync(int id)
    {
        var empleado = await _repository.GetByIdAsync(id);
        if (empleado == null) return null;
        return new EmpleadoDto
        {
            empleadoID = empleado.Id,
            idEmpleado = empleado.IdEmpleado,
            nombre = empleado.Nombre,
            departamento = empleado.Departamento,
            puesto = empleado.Puesto,
            salarioBase = empleado.SalarioBase,
            fechaIngreso = empleado.fechaIngreso
        };
    }

    public async Task<ServiceResult> CreateAsync(CrearEmpleadoDto dto)
    {
        if (string.IsNullOrEmpty(dto.nombre))
            return Error("El nombre del empleado es requerido.");
        if (string.IsNullOrEmpty(dto.departamento))
            return Error("El departamento es requerido.");
        if (string.IsNullOrEmpty(dto.puesto))
            return Error("El puesto es requerido.");

        var empleado = new Empleado
        {
            IdEmpleado = dto.idEmpleado,
            Nombre = dto.nombre,
            Departamento = dto.departamento,
            Puesto = dto.puesto,
            SalarioBase = dto.salarioBase,
            fechaIngreso = dto.fechaIngreso
        };

        await _repository.AddAsync(empleado);
        return Success("Empleado creado exitosamente.");
    }

    public async Task<ServiceResult> AddAsync(EmpleadoDto dto)
        => await CreateAsync(new CrearEmpleadoDto
        {
            idEmpleado = dto.idEmpleado,
            nombre = dto.nombre,
            departamento = dto.departamento,
            puesto = dto.puesto,
            salarioBase = dto.salarioBase,
            fechaIngreso = dto.fechaIngreso
        });

    public async Task<ServiceResult> UpdateAsync(EmpleadoDto dto)
    {
        var empleado = await _repository.GetByIdAsync(dto.empleadoID);
        if (empleado == null)
            return Error("Empleado no encontrado.");

        empleado.Nombre = dto.nombre;
        empleado.Departamento = dto.departamento;
        empleado.Puesto = dto.puesto;
        empleado.SalarioBase = dto.salarioBase;

        await _repository.UpdateAsync(empleado);
        return Success("Empleado actualizado exitosamente.");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var empleado = await _repository.GetByIdAsync(id);
        if (empleado == null)
            return Error("Empleado no encontrado.");

        await _repository.DeleteAsync(id);
        return Success("Empleado eliminado exitosamente.");
    }
}