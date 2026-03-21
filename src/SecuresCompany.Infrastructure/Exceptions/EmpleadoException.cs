using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuresCompany.Infrastructure.Exceptions;

public class EmpleadoNotFoundException : Exception
{
    public EmpleadoNotFoundException(int id)
        : base($"Empleado con ID {id} no fue encontrado.") { }
}

public class EmpleadoAlreadyExistsException : Exception
{
    public EmpleadoAlreadyExistsException(string idEmpleado)
        : base($"Ya existe un empleado con el ID {idEmpleado}.") { }
}