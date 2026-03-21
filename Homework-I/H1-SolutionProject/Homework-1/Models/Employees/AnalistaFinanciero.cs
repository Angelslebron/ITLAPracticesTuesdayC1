using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1.Models.Employees
{

internal class AnalistaFinanciero:EmpleadoFinanzas
{
    public int ProyectosAsignados;
    public required string NivelExperiencia;

    public void AnalizarDatos()
    {
        
    }

        public string GenerarReporte(string ReporteGenerado)
        {
            ReporteGenerado = "Reporte generado por el Analista Financiero: " + ReporteGenerado;

            return ReporteGenerado;
        }   }
}
