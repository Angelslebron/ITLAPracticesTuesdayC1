using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1.Models.Clients
{
    internal class ClienteNuevo : Clients
    {
        public bool VerificacionCompletada { get; set; }
        public List<string> DocumentosPendientes { get; set; }
        public DateTime FechaProximaRevision { get; set; }
        public string AgenteAsignado { get; set; }
        public int PorcentajeCompletado { get; set; }
        public bool AprobacionPendiente { get; set; }

        public ClienteNuevo() : base()
        {
            VerificacionCompletada = false;
            DocumentosPendientes = new List<string>();
            FechaProximaRevision = DateTime.Now.AddDays(7);
            PorcentajeCompletado = 0;
            AprobacionPendiente = true;
            InicializarDocumentosPendientes();
        }

        public ClienteNuevo(string nombreCliente, string numeroPoliza, string tipoSeguro, string agenteAsignado)
            : base(nombreCliente, numeroPoliza, tipoSeguro)
        {
            VerificacionCompletada = false;
            DocumentosPendientes = new List<string>();
            FechaProximaRevision = DateTime.Now.AddDays(7);
            AgenteAsignado = agenteAsignado;
            PorcentajeCompletado = 0;
            AprobacionPendiente = true;
            InicializarDocumentosPendientes();
        }
        private void InicializarDocumentosPendientes()
        {
            DocumentosPendientes = new List<string>
            {
                "Cédula de Identidad",
                "Comprobante de Domicilio",
                "Formulario de Solicitud",
                "Certificado Médico",
                "Referencias Personales"
            };
        }

        /// <summary>
        /// Sobrescribe el método para mostrar estado de verificación
        /// </summary>
        public override void MostrarEstado()
        {
            base.MostrarEstado();
            Console.WriteLine("\n--- ESTADO: CLIENTE NUEVO 🆕 ---");
            Console.WriteLine($"Verificación Completada: {(VerificacionCompletada ? "SÍ ✓" : "NO ✗")}");
            Console.WriteLine($"Agente Asignado: {AgenteAsignado ?? "Sin asignar"}");
            Console.WriteLine($"Porcentaje Completado: {PorcentajeCompletado}%");
            Console.WriteLine($"Próxima Revisión: {FechaProximaRevision.ToShortDateString()}");
            Console.WriteLine($"Días desde Registro: {CalcularDiasRegistrado()}");

            MostrarBarraProgreso();
            MostrarDocumentosPendientes();
        }

        /// <summary>
        /// Muestra una barra de progreso visual    
        /// </summary>
        private void MostrarBarraProgreso()
        {
            Console.WriteLine("\nProgreso de Verificación:");
            int barrasCompletas = PorcentajeCompletado / 10;
            string barra = new string('█', barrasCompletas) + new string('░', 10 - barrasCompletas);
            Console.WriteLine($"[{barra}] {PorcentajeCompletado}%");
        }

        public void MostrarDocumentosPendientes()
        {
            if (DocumentosPendientes.Count == 0)
            {
                Console.WriteLine("\n✓ Todos los documentos han sido recibidos");
                return;
            }

            Console.WriteLine($"\nDocumentos Pendientes ({DocumentosPendientes.Count}):");
            for (int i = 0; i < DocumentosPendientes.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. ✗ {DocumentosPendientes[i]}");
            }
        }

        public void RecibirDocumento(string nombreDocumento)
        {
            if (DocumentosPendientes.Contains(nombreDocumento))
            {
                DocumentosPendientes.Remove(nombreDocumento);
                Console.WriteLine($"✓ Documento recibido: {nombreDocumento}");
                ActualizarPorcentaje();
            }
            else
            {
                Console.WriteLine($"⚠️ El documento '{nombreDocumento}' no está en la lista de pendientes");
            }
        }

        private void ActualizarPorcentaje()
        {
            int totalDocumentos = 5; // Total de documentos requeridos
            int documentosRecibidos = totalDocumentos - DocumentosPendientes.Count;
            PorcentajeCompletado = (documentosRecibidos * 100) / totalDocumentos;

            if (DocumentosPendientes.Count == 0)
            {
                VerificacionCompletada = true;
                Console.WriteLine("\n🎉 ¡Verificación completada! El cliente puede ser aprobado.");
            }
        }

        public void CompletarVerificacion()
        {
            if (DocumentosPendientes.Count > 0)
            {
                Console.WriteLine("⚠️ No se puede completar la verificación. Documentos pendientes:");
                MostrarDocumentosPendientes();
                return;
            }

            VerificacionCompletada = true;
            AprobacionPendiente = false;
            PorcentajeCompletado = 100;

            Console.WriteLine("\n✓ VERIFICACIÓN COMPLETADA");
            Console.WriteLine("El cliente ha sido verificado exitosamente.");
            Console.WriteLine($"Fecha de Verificación: {DateTime.Now.ToShortDateString()}");
        }

        public void ProgramarRevision(int diasHasta)
        {
            FechaProximaRevision = DateTime.Now.AddDays(diasHasta);
            Console.WriteLine($"Próxima revisión programada para: {FechaProximaRevision.ToShortDateString()}");
        }

        public void AsignarAgente(string nombreAgente)
        {
            AgenteAsignado = nombreAgente;
            Console.WriteLine($"Agente asignado: {nombreAgente}");
        }
    }
}


