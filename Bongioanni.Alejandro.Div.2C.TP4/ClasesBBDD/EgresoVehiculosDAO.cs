using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesVehiculos;
using ClasesExcepciones;

namespace ClasesBBDD
{
    public static class EgresoVehiculosDAO
    {

        /// <summary>
        /// Parametro de tipo SqlConnection que establece la conexion a la BD
        /// </summary>
        private static SqlConnection sqlConnection;
        /// <summary>
        /// Constructor que genera la instancia de conexion a la BD
        /// </summary>
        static EgresoVehiculosDAO()
        {
            string conexion = "Server=.;Database=TP4;Trusted_Connection=True;";
            sqlConnection = new SqlConnection(conexion);
        }


        public static void GuardarRegistros(Vehiculo vehiculo)
        {
            try
            {
                string query = "INSERT INTO RegistroEstacionamiento (patente,tipoDeVehiculo,fechaDeIngreso,fechaDeEgreso,montoFacturado) VALUES (@patente,@tipoDeVehiculo,@fechaDeIngreso,@fechaDeEgreso,@montoFacturado)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                //sqlCommand.Parameters.AddWithValue("id", persona.Id);
                sqlCommand.Parameters.AddWithValue("patente", vehiculo.Patente);
                sqlCommand.Parameters.AddWithValue("tipoDeVehiculo", (int)vehiculo.TipoVehiculo);
                sqlCommand.Parameters.AddWithValue("fechaDeIngreso",vehiculo.HoraIngreso);
                sqlCommand.Parameters.AddWithValue("fechaDeEgreso", vehiculo.HoraEgreso);
                sqlCommand.Parameters.AddWithValue("montoFacturado",vehiculo.CargoDeEstacionamiento());
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                sqlCommand.ExecuteNonQuery();
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
