using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Datos
{
    public class ConexionDB
    {
        string errorConexion = "";
       //public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString);
        public SqlConnection cn = new SqlConnection(@"Data Source=localhost;Initial Catalog=DBSeguridad.V.3;User ID=Daniel;Password=Daniel");

        public string Conexion()
        {
            return cn.ConnectionString;
        }
        public void Conectar()
        {
            try
            {
                cn.Open();
            }
            catch (Exception e)
            {
                errorConexion = e.Message.ToString();
            }
        }
        public void Desconectar()
        {
            try
            {
                cn.Close();
            }
            catch (Exception e)
            {
                errorConexion = e.Message.ToString();
            }
        }
    }
}
