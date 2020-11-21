using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesExcepciones;
using ClasesBBDD;
using ClasesArchivos;
using ClasesEstacionamiento;
using ClasesVehiculos;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            Estacionamiento estacionamiento;
            estacionamiento = Estacionamiento.NuevoEstacionamiento;
            estacionamiento.CapacidadEstacionamiento = 4;
            estacionamiento.NombreEstacionamiento = "Estacionamiento 24 HS";

            Vehiculo automovil = new Automovil("AD623QX", new DateTime(2020, 11, 10, 13, 08, 25));
            Automovil.ValorHora = "100";
            Vehiculo camioneta = new Camioneta("OSA751", new DateTime(2020, 11, 10, 14, 10, 00));
            Vehiculo moto = new Moto("EPX277", new DateTime(2020, 11, 12, 08, 10, 00));

            try
            {
                Console.WriteLine($"Ingreso: {estacionamiento + automovil}");
                Console.WriteLine($"Ingreso: {estacionamiento + camioneta}");
                Console.WriteLine($"Ingreso: {estacionamiento + moto}");
                Console.WriteLine($"Ingreso: {estacionamiento + automovil}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("<--------------------------------------------------------------------------------------------------------->");
            automovil.HoraEgreso = DateTime.Now;
            camioneta.HoraEgreso = DateTime.Now;
            //moto.HoraEgreso = DateTime.Now;
            try
            {
                Console.WriteLine($"Salida de vehiculo {estacionamiento - automovil}");
                Console.WriteLine($"Salida vehiculo  {estacionamiento - camioneta}");
                Console.WriteLine($"Salida vehiculo  {estacionamiento - moto}");
            }
            catch (Exception ex)
            {
                Exception inner = ex.InnerException;
                Console.WriteLine(ex.Message);
                while (inner != null)
                {
                    Console.WriteLine(inner.Message);
                    inner = inner.InnerException;
                }
            }
                       
            Console.WriteLine("\n\n<Escritura y Lectura de vehiculo serializado>");
            Tickets tickets = new Tickets();

            tickets.GuardarTicket("VehiculoSerializado.xml", automovil);
            Vehiculo vehiculoSerializado;
            string ruta = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Facturas\\XML\\VehiculoSerializado.xml";
            
            tickets.LeerTicket(ruta, out vehiculoSerializado);
            Console.WriteLine($"{vehiculoSerializado.ToString() }");
            Console.WriteLine("<--------------------------------------------------------------------------------------------------------->");

            Console.WriteLine("<Leo Vehiculo desde la BD con evento e imprimo, se actualiza cada 20 seg>");

            VehiculosDAO.EventoActualizar += Program.HabilitarIngresoVehiculo;
            VehiculosDAO.Activar = true;

            Console.ReadKey();
        }
        /// <summary>
        /// Metodo para manejar el evento
        /// </summary>
        /// <param name="vehiculo"></param>
        public static void HabilitarIngresoVehiculo(Vehiculo vehiculo)
        {
            Tickets tickets = new Tickets();
            Console.WriteLine(vehiculo.ToString());
            Console.WriteLine($"La patente tien {vehiculo.Patente.UnMetodoDeExtensionQueMeFalta()} caracteres");
            tickets.GuardarTicket($"Ticket de Consola-{vehiculo.Patente}.txt",vehiculo.ToString());
            Console.WriteLine("==============================================");
        }
    }
    public static class MetodoExtension
    {
        public static int UnMetodoDeExtensionQueMeFalta(this string patente)
        {
            return patente.Length;
        }

    }
}
