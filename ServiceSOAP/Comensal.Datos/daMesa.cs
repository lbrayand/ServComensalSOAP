namespace Comensal.Datos
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using Comensal.Entidad;
    using MySql.Data.MySqlClient;

    public class daMesa
    {
        private string conex = ConfigurationManager.ConnectionStrings["mySQLConnection"].ToString();

        public List<beMesa> listarMesas()
        {
            List<beMesa> mesas = new List<beMesa>();

            using (MySqlConnection cn = new MySqlConnection(conex))
            {
                cn.Open();

                using (MySqlCommand cmd = new MySqlCommand("USP_ListarMesas", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        beMesa obeMesa = new beMesa();
                        obeMesa.ubicacion = dr.GetString(0).ToString();
                        obeMesa.numMesa = dr.GetInt32(1);
                        obeMesa.numCapacidad = dr.GetInt32(2);
                        mesas.Add(obeMesa);
                    }
                }
            }

            return mesas;
        }

        public void registrar(beMesa obeMesa)
        {
            using (MySqlConnection cn = new MySqlConnection(conex))
            {
                cn.Open();

                using (MySqlCommand cmd = new MySqlCommand("USP_RegistrarMesa", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("numMesa", MySqlDbType.Int32).Value = obeMesa.numMesa;
                    cmd.Parameters.Add("numCapacidad", MySqlDbType.Int32).Value = obeMesa.numCapacidad;
                    cmd.Parameters.Add("ubicacion", MySqlDbType.VarChar).Value = obeMesa.ubicacion;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
