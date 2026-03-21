using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1.Models.Clients
{

internal class ClienteAlDia : Clients
{
    public DateTime UltimoPago { get; set; }
    public decimal DescuentoFidelidad { get; set; }
    public int MesesConsecutivosAlDia { get; set; }


    //Constructors
    public ClienteAlDia() : base()
    {
        UltimoPago = DateTime.Now;
        DescuentoFidelidad = 0;
        MesesConsecutivosAlDia = 0;
    }

    public ClienteAlDia(string nombreCliente, string numeroPoliza, string tipoSeguro)
        : base(nombreCliente, numeroPoliza, tipoSeguro)
    {
        UltimoPago = DateTime.Now;
        DescuentoFidelidad = 5;
        MesesConsecutivosAlDia = 1;
    }

    public override void MostrarEstado()
    {
        base.MostrarEstado();
        Console.WriteLine("\n---Estado: Cliente al Dia ---");
        Console.WriteLine($"Ultimo pago: {UltimoPago.ToShortDateString()}");
        Console.WriteLine($"Descuento por fidelidad: {DescuentoFidelidad}%");
        Console.WriteLine($"Meses consecutivos al dia: {MesesConsecutivosAlDia}");
        Console.WriteLine($"Dias desde ultimo pago: {CalcularDiasDesdeUltimoPago()}");
    }
    public int CalcularDiasDesdeUltimoPago()
    {
        return (DateTime.Now - UltimoPago).Days;
    }

    /// <summary>
    /// Aplica el descuento por fidelidad
    /// </summary>
    public decimal AplicarDescuento(decimal montoPagar)
    {
        decimal descuento = montoPagar * (DescuentoFidelidad / 100);
        decimal montoFinal = montoPagar - descuento;

        Console.WriteLine($"Monto original: ${montoPagar:N2}");
        Console.WriteLine($"Descuento ({DescuentoFidelidad}%): -${descuento:N2}");
        Console.WriteLine($"Monto final: ${montoFinal:N2}");

        return montoFinal;
    }

        public void ActualizarDescuentoFidelidad()
        {
            if (MesesConsecutivosAlDia >= 12)
            {
                DescuentoFidelidad = 15;
            }
            else if (MesesConsecutivosAlDia >= 6)
            {
                DescuentoFidelidad = 10;
            }
            else if (MesesConsecutivosAlDia >= 3)
            {
                DescuentoFidelidad = 7;
            }
            else
            {
                DescuentoFidelidad = 5;
            }
        }   }
}
