using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1.Models.Employees
{
    internal class GerenteTI : EmpleadoTI
    {
        public int ProyectosTI;
        public int EquipoDesarrollo;
        public decimal BonoTecnico;

        public void AsignarProyecto()
        { }

        public decimal CalcularSalarioTotal()
        {
            // Suma el salario base y el bono técnico para el gerente TI
            return SalarioBase + BonoTecnico;
        }
    }
}
