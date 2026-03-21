using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuresCompany.Infrastructure.Exceptions;

public class ClienteNotFoundException : Exception
{
    public ClienteNotFoundException(int id)
        : base($"Cliente con ID {id} no fue encontrado.") { }
}

public class ClienteAlreadyExistsException : Exception
{
    public ClienteAlreadyExistsException(string poliza)
        : base($"Ya existe un cliente con la póliza {poliza}.") { }
}