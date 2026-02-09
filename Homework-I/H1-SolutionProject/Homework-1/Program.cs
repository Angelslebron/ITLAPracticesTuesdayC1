/*
 Este programa está pensado para un sistema de compañía
aseguradora o compañía de seguros.
 */

using System;
using Homework_1.Classes;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("---- SISTEMA DE SEGUROS ---- \n");
        Thread.Sleep(1000);

        //Todo esta organizado por niveles, aqui empezamos por el nivel 3: Gerente de finanzas.
        GerenteFinanzas Gerente = new()
        {
            Nombre = "Alberson Hernandez",
            IdEmpleado = "GF01",
            SalarioBase = 65000,
            BonoGerencial = 16000,
            AreaEspecializacion = "Inversiones",
            PresupuestoAnual = 620000,
            NumeroSubordinados = 3,
            FechaIngreso = new DateTime(2018, 2, 01),
            Departamento = "Finanzas"
        };

        // Nivel 3: Analista Financiero
        AnalistaFinanciero Analista = new()
        {
            Nombre = "Carlos Perez",
            IdEmpleado = "FA01",
            SalarioBase = 46000,
            AreaEspecializacion = "Auditor",
            ProyectosAsignados = 4,
            NivelExperiencia = "Senior",
            FechaIngreso = new DateTime(2016, 2, 16),
            Departamento = "Finanzas"
        };

        //Nivel 3: Desarrollador
        DesarrolladorSoftware dev = new()
        { 
            Nombre = "Luis Alvarez",
            IdEmpleado = "DEV01",
            SalarioBase = 50000,
            NivelTecnico = "Senior",
            TareasPendientes = 3,
            LineasCodigoMes = 2200,
            FechaIngreso = new DateTime(2018, 5, 15),
            Departamento = "TI"
        };

        //Mostrar informacion del Gerente de Finanzas
        Gerente.MostrarInfo();
        {
            Console.WriteLine("\n---\n");
        }
        Thread.Sleep(1000);
        //Mostrar informacion del Analista Financiero
        Analista.MostrarInfo();
        {
            Console.WriteLine("\n---\n");
        }
        Thread.Sleep(1000);
        //Mostrar informacion del Desarrollador de Software
        dev.MostrarInfo();
        {
            Console.WriteLine("\n---\n");
        }


    }
}