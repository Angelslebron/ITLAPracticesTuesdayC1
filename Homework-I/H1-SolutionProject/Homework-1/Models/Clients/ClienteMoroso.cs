using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1.Models.Clients
{
    internal class ClienteMoroso : Clients
    {
        public int DiasMora { get; set; }
        public decimal MontoMora { get; set; }
        public decimal RecargoPorMora { get; set; }  // Monto adicional por retraso
        public DateTime FechaUltimoAtraso { get; set; }
        public bool EnProcesoCobro { get; set; }
        public string MotivoMora { get; set; }

        public ClienteMoroso() : base()
        {
            DiasMora = 0;
            MontoMora = 0;
            RecargoPorMora = 0;
            EnProcesoCobro = false;
            FechaUltimoAtraso = DateTime.Now;
        }

        public ClienteMoroso(string nombreCliente, string numeroPoliza, string tipoSeguro, int diasMora, decimal montoMora)
            : base(nombreCliente, numeroPoliza, tipoSeguro)
        {
            DiasMora = diasMora;
            MontoMora = montoMora;
            SaldoPendiente = montoMora;
            RecargoPorMora = CalcularRecargo();
            FechaUltimoAtraso = DateTime.Now;
            EnProcesoCobro = diasMora > 60;
        }

        public override void MostrarEstado()
        {
            base.MostrarEstado();
            Console.WriteLine("\n--- ESTADO: MOROSO ⚠️ ---");
            Console.WriteLine($"Días en Mora: {DiasMora}");
            Console.WriteLine($"Monto en Mora: ${MontoMora:N2}");
            Console.WriteLine($"Recargo por Mora: ${RecargoPorMora:N2}");
            Console.WriteLine($"Total a Pagar: ${CalcularTotalAPagar():N2}");
            Console.WriteLine($"Fecha Último Atraso: {FechaUltimoAtraso.ToShortDateString()}");
            Console.WriteLine($"En Proceso de Cobro: {(EnProcesoCobro ? "SÍ" : "NO")}");

            if (!string.IsNullOrEmpty(MotivoMora))
            {
                Console.WriteLine($"Motivo: {MotivoMora}");
            }

            MostrarNivelGravedad();
        }

        private decimal CalcularRecargo()
        {
            // 2% por cada 30 días de mora
            int meses = DiasMora / 30;
            decimal porcentaje = meses * 2;

            return MontoMora * (porcentaje / 100);
        }

        public decimal CalcularTotalAPagar()
        {
            return MontoMora + RecargoPorMora;
        }

        public override decimal CalcularMora()
        {
            return RecargoPorMora;
        }

        private void MostrarNivelGravedad()
        {
            Console.WriteLine("\nNivel de Gravedad:");

            if (DiasMora <= 15)
            {
                Console.WriteLine("🟢 LEVE - Pago atrasado reciente");
            }
            else if (DiasMora <= 30)
            {
                Console.WriteLine("🟡 MODERADO - Requiere atención");
            }
            else if (DiasMora <= 60)
            {
                Console.WriteLine("🟠 GRAVE - Riesgo de suspensión");
            }
            else
            {
                Console.WriteLine("🔴 CRÍTICO - En proceso de cobro legal");
            }
        }

        public void GenerarPlanDePago(int numeroCuotas)
        {
            if (numeroCuotas <= 0)
            {
                Console.WriteLine("ERROR: El número de cuotas debe ser mayor a 0");
                return;
            }

            decimal totalAPagar = CalcularTotalAPagar();
            decimal cuotaMensual = totalAPagar / numeroCuotas;

            Console.WriteLine("\n=== PLAN DE PAGO PROPUESTO ===");
            Console.WriteLine($"Total Adeudado: ${totalAPagar:N2}");
            Console.WriteLine($"Número de Cuotas: {numeroCuotas}");
            Console.WriteLine($"Cuota Mensual: ${cuotaMensual:N2}");
            Console.WriteLine("\nDetalle de Cuotas:");

            for (int i = 1; i <= numeroCuotas; i++)
            {
                DateTime fechaPago = DateTime.Now.AddMonths(i);
                Console.WriteLine($"Cuota {i}: ${cuotaMensual:N2} - Vence: {fechaPago.ToShortDateString()}");
            }
        }

        public void IniciarProcesoCobro()
        {
            EnProcesoCobro = true;
            Console.WriteLine("\n⚠️ PROCESO DE COBRO INICIADO");
            Console.WriteLine("Se han tomado acciones legales para recuperar la deuda.");
            Console.WriteLine($"Monto total: ${CalcularTotalAPagar():N2}");
        }
    }
}