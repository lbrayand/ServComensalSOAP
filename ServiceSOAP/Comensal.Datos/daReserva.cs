namespace Comensal.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using Comensal.Entidad;
    using MySql.Data.MySqlClient;

    public class daReserva
    {
        private string conex = ConfigurationManager.ConnectionStrings["mySQLConnection"].ToString();

        public void actualizarEstadoReserva(int idReserva, 
                                            int idEstado)
        {
            using (MySqlConnection cn = new MySqlConnection(conex))
            {
                cn.Open();

                using (MySqlCommand cmd = new MySqlCommand("USP_UpdateEstadoReserva", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("idReserva", MySqlDbType.VarChar).Value = idReserva;
                    cmd.Parameters.Add("idEstado", MySqlDbType.VarChar).Value = idEstado;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
