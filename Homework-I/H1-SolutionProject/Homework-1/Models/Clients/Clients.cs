using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1.Models.Clients
{
    internal class Clients
    {
        public string NombreCliente { get; set; }
        public string NumeroPoliza { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal SaldoPendiente { get; set; }
        public string TipoSeguro { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Clients()
        {
            FechaRegistro = DateTime.Now;
            SaldoPendiente = 0;
        }

        public Clients(string nombreCliente, string numeroPoliza, string tipoSeguro)
        {
            NombreCliente = nombreCliente;
            NumeroPoliza = numeroPoliza;
            TipoSeguro = tipoSeguro;
            FechaRegistro = DateTime.Now;
            SaldoPendiente = 0;
        }

        public virtual void MostrarEstado()
        {
            Console.WriteLine("---Informacion del cliente---");
            Console.WriteLine($"Nombre del cliente: {NombreCliente}");
            Console.WriteLine($"Numero de poliza: {NumeroPoliza}");
            Console.WriteLine($"Tipo de seguro: {TipoSeguro}");
            Console.WriteLine($"Fecha de ingreso{FechaRegistro.ToShortDateString()}");
            Console.WriteLine($"Saldo pendiente: ${SaldoPendiente:N2}");
            Console.WriteLine($"Telefono: {Telefono}");
            Console.WriteLine($"Email: {Email}");
        }
        

             /// <summary>
             /// Calcula los días desde el registro
             /// </summary>
        public int CalcularDiasRegistrado()
        {
            return (DateTime.Now - FechaRegistro).Days;
        }

        public virtual decimal CalcularMora()
        {
            return 0; 
        }

     
        public void RegistrarPago(decimal monto)
        {
            if (monto <= 0)
            {
                Console.WriteLine("ERROR: El monto debe ser mayor a 0");
                return;
            }

            if (monto > SaldoPendiente)
            {
                Console.WriteLine($"ADVERTENCIA: El pago de ${monto} excede la deuda de ${SaldoPendiente}");
                SaldoPendiente = 0;
            }
            else
            {
                SaldoPendiente -= monto;
                Console.WriteLine($"Pago registrado: ${monto:N2}");
                Console.WriteLine($"Saldo pendiente: ${SaldoPendiente:N2}");
            }
        }
}   }

