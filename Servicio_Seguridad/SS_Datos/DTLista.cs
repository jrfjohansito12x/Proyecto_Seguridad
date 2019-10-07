using SS_Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS_Datos
{
    public class DTLista
    {
        ConexionDB cn = new ConexionDB();

        public string Lista_Registrar(string nombreLista, string descripcionLista, string creadoPor, DateTime fechaCreacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListaRegistrar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@NombreLista", SqlDbType.Text)).Value = nombreLista;
                cmd.Parameters.Add(new SqlParameter("@DescripcionLista", SqlDbType.Text)).Value = descripcionLista;
                cmd.Parameters.Add(new SqlParameter("@CreadoPor", SqlDbType.Text)).Value = creadoPor;
                cmd.Parameters.Add(new SqlParameter("@FechaCreacion", SqlDbType.DateTime)).Value = fechaCreacion;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Desconectar();
                resultado = "[CREO]" + Funciones.ToInt(dt.Rows[0]["IdLista"]).ToString();
            }
            catch (Exception e)
            {
                resultado = "[ERROR]: " + e.Message;

            }
            return resultado;
        }


        public string Lista_Modificar(int idLista, string nombreLista, string descripcionLista, string modificadoPor, DateTime fechaModificacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListaModificar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdLista", SqlDbType.Int)).Value = idLista;
                cmd.Parameters.Add(new SqlParameter("@NombreLista", SqlDbType.Text)).Value = nombreLista;
                cmd.Parameters.Add(new SqlParameter("@DescripcionLista", SqlDbType.Text)).Value = descripcionLista;
                cmd.Parameters.Add(new SqlParameter("@ModificadoPor", SqlDbType.Text)).Value = modificadoPor;
                cmd.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime)).Value = fechaModificacion;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Desconectar();
            }
            catch (Exception e)
            {
                resultado = "[ERROR]: " + e.Message;

            }
            return resultado;
        }
        public List<Lista> Lista_Leer(int idLista, string nombreLista)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ListaLeer";
            cmd.Connection = cn.cn;
            cn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@IdLista", SqlDbType.Int)).Value = idLista;
            cmd.Parameters.Add(new SqlParameter("@NombreLista", SqlDbType.Text)).Value = nombreLista;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Lista> ListaLeer = new List<Lista>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Lista lista = new Lista();
                lista.IdLista = Funciones.ToInt(dt.Rows[i]["IdLista"]);
                lista.NombreLista = Funciones.ToString(dt.Rows[i]["NombreLista"]);
                lista.DescripcionLista = Funciones.ToString(dt.Rows[i]["DescripcionLista"]);
                lista.CreadoPor = Funciones.ToString(dt.Rows[i]["CreadoPor"]);
                lista.FechaCreacion = Funciones.ToDateTime(dt.Rows[i]["FechaCreacion"]);
                lista.ModificadoPor = Funciones.ToString(dt.Rows[i]["ModificadoPor"]);
                lista.FechaModificacion = Funciones.ToDateTime(dt.Rows[i]["FechaModificacion"]);
                ListaLeer.Add(lista);
            }
            cn.Desconectar();
            return ListaLeer;
        }

        public string Lista_Eliminar(int idLista)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListaEliminar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdLista", SqlDbType.Int)).Value = idLista;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Desconectar();
            }
            catch (Exception e)
            {
                resultado = "[ERROR]: " + e.Message;

            }
            return resultado;
        }
    }
}
