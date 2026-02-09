using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1.Classes
{
    internal class ClassEmployeesSecure
    {
        public required string Nombre { get; set; }
        public  required string IdEmpleado;
        public DateTime FechaIngreso;
        public decimal SalarioBase;
        public required string Departamento;

        public virtual void MostrarInfo()
        {
            Console.WriteLine($"Nombre del empleado: {Nombre}");
            Console.WriteLine($"ID del empleado: {IdEmpleado}");
            Console.WriteLine($"Fecha de ingreso del empleado: {FechaIngreso}");
            Console.WriteLine($"Salario base del empleado: {SalarioBase}");
            Console.WriteLine($"Departamento al que esta asignado: {Departamento}");

        }

        public int CalcularAntiguedad(int AntiguedadEmpleado)
        {
            AntiguedadEmpleado = DateTime.Now.Year - FechaIngreso.Year;
            return AntiguedadEmpleado;
        }

        public decimal CalcularSalarioTotal(decimal SalarioTotal)
        {
            SalarioTotal = SalarioBase;

            return SalarioTotal;
        }
    }
}
