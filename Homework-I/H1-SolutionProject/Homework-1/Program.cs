/*
 Este programa está pensado para un sistema de compañía
aseguradora o compañía de seguros.
 */

using System;
using Homework_1.Models.Clients;
using System.Threading.Tasks;
using Homework_1.Models.Employees;
using System.Security.Cryptography.X509Certificates;

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

        Console.WriteLine("Demostracion del sistema asegurador en clientes");
        Demostracion();


    }

    public static void Demostracion()
    {
        Console.WriteLine("╔════════════════════════════════════════════════╗");
        Console.WriteLine("║   SISTEMA DE GESTIÓN ASEGURADORA - ISSUE - 1   ║");
        Console.WriteLine("╚════════════════════════════════════════════════╝");
        Console.WriteLine();

        // ============================================
        // DEMOSTRACIÓN DE CLIENTES
        // ============================================
        Console.WriteLine("═══════════════════════════════════════════════════");
        Console.WriteLine("          DEMOSTRACIÓN DE CLIENTES                 ");
        Console.WriteLine("═══════════════════════════════════════════════════\n");

        DemostrarClientes();

        Console.WriteLine("\n\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }

    public static void DemostrarClientes()
    {
        // CLIENTE AL DÍA
        Console.WriteLine("1️⃣ CLIENTE AL DÍA");
        Console.WriteLine("─────────────────────────────────────────────────");
        var clienteAlDia = new ClienteAlDia
        {
            NombreCliente = "Ana María García",
            NumeroPoliza = "POL-2024-001",
            TipoSeguro = "Seguro de Vida",
            Telefono = "809-555-1234",
            Email = "ana.garcia@email.com",
            UltimoPago = DateTime.Now.AddDays(-10),
            MesesConsecutivosAlDia = 8,
            SaldoPendiente = 0
        };

        clienteAlDia.ActualizarDescuentoFidelidad();
        Thread.Sleep(500);
        clienteAlDia.MostrarEstado();
        Thread.Sleep(500);
        Console.WriteLine("\n--- Aplicando Descuento ---");
        decimal montoPagar = 5000;
        clienteAlDia.AplicarDescuento(montoPagar);
        Thread.Sleep(500);
        Console.WriteLine("\n\n");

        // CLIENTE MOROSO
        Console.WriteLine("2️⃣ CLIENTE MOROSO");
        Console.WriteLine("─────────────────────────────────────────────────");
        var clienteMoroso = new ClienteMoroso
        {
            NombreCliente = "Carlos López Pérez",
            NumeroPoliza = "POL-2024-002",
            TipoSeguro = "Seguro de Auto",
            Telefono = "809-555-5678",
            Email = "carlos.lopez@email.com",
            DiasMora = 45,
            MontoMora = 3000,
            MotivoMora = "Problemas financieros temporales",
            FechaUltimoAtraso = DateTime.Now.AddDays(-45)
        };
        Thread.Sleep(500);

        clienteMoroso.SaldoPendiente = clienteMoroso.CalcularTotalAPagar();
        clienteMoroso.MostrarEstado();

        Console.WriteLine("\n--- Generando Plan de Pago ---");
        clienteMoroso.GenerarPlanDePago(6);

        Console.WriteLine("\n\n");

        // CLIENTE NUEVO
        Console.WriteLine("3️⃣ CLIENTE NUEVO");
        Console.WriteLine("─────────────────────────────────────────────────");
        Thread.Sleep(500);

        var clienteNuevo = new ClienteNuevo
        {
            NombreCliente = "Laura Martínez Rodríguez",
            NumeroPoliza = "POL-2024-003",
            TipoSeguro = "Seguro de Hogar",
            Telefono = "809-555-9012",
            Email = "laura.martinez@email.com",
            AgenteAsignado = "Pedro Sánchez",
            SaldoPendiente = 0
        };

        clienteNuevo.MostrarEstado();

        Console.WriteLine("\n--- Recibiendo Documentos ---");
        clienteNuevo.RecibirDocumento("Cédula de Identidad");
        clienteNuevo.RecibirDocumento("Comprobante de Domicilio");
        clienteNuevo.RecibirDocumento("Formulario de Solicitud");

        Console.WriteLine("\n--- Estado Actualizado ---");
        clienteNuevo.MostrarEstado();

        Console.WriteLine("\n\n");

        // DEMOSTRACIÓN DE RESULTADOS
        Console.WriteLine("4️⃣ RESULTADOS");
        Console.WriteLine("─────────────────────────────────────────────────");

        List<Clients> todosLosClientes = new() { clienteAlDia, clienteNuevo, clienteNuevo };

        Console.WriteLine("\nLista de todos los clientes:\n");
        foreach (var cliente in todosLosClientes)
        {
            Console.WriteLine($"• {cliente.NombreCliente} - Póliza: {cliente.NumeroPoliza}");
            Console.WriteLine($"  Saldo: ${cliente.SaldoPendiente:N2}");
            Console.WriteLine($"  Mora: ${cliente.CalcularMora():N2}");
            Console.WriteLine();
        }
    }
}

