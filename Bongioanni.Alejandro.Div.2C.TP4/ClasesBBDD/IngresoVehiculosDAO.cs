using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClasesVehiculos;
using ClasesExcepciones;


namespace ClasesBBDD
{
    public static class IngresoVehiculosDAO
    {
        public delegate void encargadoActualizar(Vehiculo vehiculo); // delegado al metodo, que devuelve lo del metodo
        private static Thread hilo;
        public static event encargadoActualizar EventoActualizar;
        private static int contador;

        /// <summary>
        /// Parametro de tipo SqlConnection que establece la conexion a la BD
        /// </summary>
        private static SqlConnection sqlConnection;
        /// <summary>
        /// Constructor que genera la instancia de conexion a la BD
        /// </summary>
        static IngresoVehiculosDAO()
        {
            string conexion = "Server=.;Database=TP4;Trusted_Connection=True;";
            sqlConnection = new SqlConnection(conexion);
            IngresoVehiculosDAO.hilo = new Thread(LeerRegistros);
            contador = 1;
        }

        public static void LeerRegistros()
        {
            int qRegistros = IngresoVehiculosDAO.MaxRegistroDeVehiculos();
            while(contador<= qRegistros)
            {
                IngresoVehiculosDAO.EventoActualizar.Invoke(IngresoVehiculosDAO.LeerVehiculoPorId(contador));
                contador++;
                Thread.Sleep(20000);
            }
        }

        public static bool Activar
        {
            get
            {
                bool returnAux = false;
                if (!object.ReferenceEquals(hilo, null))
                {
                    returnAux= hilo.IsAlive;
                }
                return returnAux;
            }
            set
            {
                if (value && !object.ReferenceEquals(hilo, null) && !IngresoVehiculosDAO.hilo.IsAlive)
                {
                    if (hilo.ThreadState == ThreadState.Aborted)
                    {
                        IngresoVehiculosDAO.hilo = new Thread(LeerRegistros);
                    }
                    IngresoVehiculosDAO.hilo.Start();

                }
                else if (!object.ReferenceEquals(hilo, null) && !value)
                {
                    IngresoVehiculosDAO.hilo.Abort();
                }
            }

        }

        public static Vehiculo LeerVehiculoPorId(int id)
        {
            try
            {
                string sentencia = "SELECT patente, tipoDeVehiculo FROM ListadoDeVehiculos WHERE id=@idListado";
                Vehiculo nuevoVehiculo=null;
                SqlCommand sqlCommand = new SqlCommand(sentencia, sqlConnection);
                sqlCommand.Parameters.AddWithValue("idListado", id);
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if(!object.ReferenceEquals(sqlDataReader.Read(), null))
                {
                    switch (sqlDataReader.GetInt32(1))
                    {
                        case (int)Vehiculo.ETipo.Auto:
                            {
                                nuevoVehiculo = new Automovil(sqlDataReader.GetString(0), DateTime.Now);
                                break;
                            }
                        case (int)Vehiculo.ETipo.Camioneta:
                            {
                                nuevoVehiculo = new Camioneta(sqlDataReader.GetString(0), DateTime.Now);
                                break;
                            }
                        case (int)Vehiculo.ETipo.Moto:
                            {
                                nuevoVehiculo = new Moto(sqlDataReader.GetString(0), DateTime.Now);
                                break;
                            }
                    }
                }
                return nuevoVehiculo;
            }
            catch (Exception ex)
            {
                throw new BaseDeDatosException("Error a consultar registros de la BD", ex);
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }


        private static int MaxRegistroDeVehiculos()
        {
            try
            {
                string sentencia = "SELECT MAX(id) AS Maximo from ListadoDeVehiculos";
                int idMaximo=0;
                SqlCommand sqlCommand = new SqlCommand(sentencia, sqlConnection);
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                idMaximo=(int)sqlDataReader[0];
                return idMaximo;
            }
            catch (Exception ex)
            {
                throw new BaseDeDatosException("Error a consultar registros de la BD", ex);
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

        }
    }
}
