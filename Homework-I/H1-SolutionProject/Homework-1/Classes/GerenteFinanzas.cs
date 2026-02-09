using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1.Classes
{
    internal class GerenteFinanzas : EmpleadoFinanzas
    {
        public decimal PresupuestoAnual;
        public int NumeroSubordinados;
        public decimal BonoGerencial;

        public bool AprobarPresupuesto(decimal monto)
        {
            // Se aprueba si el monto es menor o igual al presupuesto anual
            return monto <= PresupuestoAnual;
        }

        public decimal CalcularSalarioTotal(decimal x)
        { return x; }

    }
}
