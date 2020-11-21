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
    public static class VehiculosDAO
    {
        #region "Atributos"
        public delegate void encargadoActualizar(Vehiculo vehiculo);
        private static Thread hilo;
        public static event encargadoActualizar EventoActualizar;
        private static int contador;
        private static SqlConnection sqlConnection;
        #endregion

        #region "Cosntructores"
        /// <summary>
        /// Constructor de Clase que establce los parametros para realizar una conexion a la BD
        /// </summary>
        static VehiculosDAO()
        {
            string conexion = "Server=.;Database=TP4;Trusted_Connection=True;";
            sqlConnection = new SqlConnection(conexion);
            VehiculosDAO.hilo = new Thread(LeerRegistros);
            contador = 1;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Activa o desactivo la lectura de registros de la BD en un hilo secundario
        /// </summary>
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
                if (value && !object.ReferenceEquals(hilo, null) && !VehiculosDAO.hilo.IsAlive)
                {
                    if (hilo.ThreadState == ThreadState.Aborted)
                    {
                        VehiculosDAO.hilo = new Thread(LeerRegistros);
                    }
                    VehiculosDAO.hilo.Start();
                }
                else if (!object.ReferenceEquals(hilo, null) && !value)
                {
                    VehiculosDAO.hilo.Abort();
                }
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Metodo que invoca a LeerVehiculoPorId cada 20 segundos,hasta que se agoten los registros de la base
        /// </summary>
        private static void LeerRegistros()
        {
            try
            {
                int qRegistros = VehiculosDAO.MaxRegistroDeVehiculos();
                while (contador <= qRegistros)
                {
                    VehiculosDAO.EventoActualizar.Invoke(VehiculosDAO.LeerVehiculoPorId(contador));
                    contador++;
                    Thread.Sleep(20000);
                }
            }
            catch(BaseDeDatosException ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Consulta registros de la Base de vehiculos por ID y genera una instancia de este segun su tipo
        /// </summary>
        /// <param name="id">Es el ID de la base a consultar</param>
        /// <returns>Un nuevo Vehiculo</returns>
        /// <exception cref="BaseDeDatosException"></exception>
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
        /// <summary>
        /// Metodo privado usado para obtener el ID maximo de registros en la BD
        /// </summary>
        /// <returns>El numero maximo de registros</returns>
        /// <exception cref="BaseDeDatosException"></exception>
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
        /// <summary>
        /// Guarda los registros de los vehiculos al retirarse del Estacionamiento
        /// </summary>
        /// <param name="vehiculo">Es el vehiculo a almacenar en la BD</param>
        public static void GuardarRegistros(Vehiculo vehiculo)
        {
            try
            {
                string query = "INSERT INTO RegistroEstacionamiento (patente,tipoDeVehiculo,fechaDeIngreso,fechaDeEgreso,montoFacturado) VALUES (@patente,@tipoDeVehiculo,@fechaDeIngreso,@fechaDeEgreso,@montoFacturado)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //sqlCommand.Parameters.AddWithValue("id", persona.Id);
                sqlCommand.Parameters.AddWithValue("patente", vehiculo.Patente);
                sqlCommand.Parameters.AddWithValue("tipoDeVehiculo", (int)vehiculo.TipoVehiculo);
                sqlCommand.Parameters.AddWithValue("fechaDeIngreso", vehiculo.HoraIngreso);
                sqlCommand.Parameters.AddWithValue("fechaDeEgreso", vehiculo.HoraEgreso);
                sqlCommand.Parameters.AddWithValue("montoFacturado", vehiculo.CargoDeEstacionamiento());
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new BaseDeDatosException("Error al escribir en la BD", ex);
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
        #endregion
    }
}
