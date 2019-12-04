namespace Comensal.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using Comensal.Entidad;
    using MySql.Data.MySqlClient;

    public class daLocal
    {
        private string conex = ConfigurationManager.ConnectionStrings["mySQLConnection"].ToString();

        public List<beLocal> listarLocales()
        {
            List<beLocal> locales = new List<beLocal>();

            using (MySqlConnection cn = new MySqlConnection(conex))
            {
                cn.Open();

                using (MySqlCommand cmd = new MySqlCommand("USP_ListarLocales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        beLocal obeLocal = new beLocal();
                        obeLocal.idLocal = Convert.ToInt32(dr.GetInt32(0));
                        obeLocal.nombreLocal = dr.GetString(1).ToString();
                        obeLocal.direccion = dr.GetString(3).ToString();
                        obeLocal.numAforo = Convert.ToInt32(dr.GetInt32(3));
                        obeLocal.numPisos = Convert.ToInt32(dr.GetInt32(4));
                        locales.Add(obeLocal);
                    }
                }
            }

            return locales;
        }

        public void registrar(beLocal obeLocal)
        {
            using (MySqlConnection cn = new MySqlConnection(conex))
            {
                cn.Open();

                using (MySqlCommand cmd = new MySqlCommand("USP_RegistrarLocales", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("nombreLocal", MySqlDbType.VarChar).Value = obeLocal.nombreLocal;
                    cmd.Parameters.Add("direccion", MySqlDbType.VarChar).Value = obeLocal.direccion;
                    cmd.Parameters.Add("numAforo", MySqlDbType.Int32).Value = obeLocal.numAforo;
                    cmd.Parameters.Add("numPisos", MySqlDbType.Int32).Value = obeLocal.numPisos;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
