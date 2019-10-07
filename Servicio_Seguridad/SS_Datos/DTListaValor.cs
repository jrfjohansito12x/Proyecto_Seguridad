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
    public class DTListaValor
    {
        ConexionDB cn = new ConexionDB();

        public string ListaValor_Registrar(int idLista, string valor, string descripcionLista, string creadoPor, DateTime fechaCreacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListaValorRegistrar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdLista", SqlDbType.Int)).Value = idLista;
                cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Text)).Value = valor;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.Text)).Value = descripcionLista;
                cmd.Parameters.Add(new SqlParameter("@CreadoPor", SqlDbType.Text)).Value = creadoPor;
                cmd.Parameters.Add(new SqlParameter("@FechaCreacion", SqlDbType.DateTime)).Value = fechaCreacion;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cn.Desconectar();
                resultado = "[CREO]" + Funciones.ToInt(dt.Rows[0]["IdListaValor"]).ToString();
            }
            catch (Exception e)
            {
                resultado = "[ERROR]: " + e.Message;

            }
            return resultado;
        }


        public string ListaValor_Modificar(int idListaValor, int idLista, string valor, string descripcionLista, string modificadoPor, DateTime fechaModificacion)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListaValorModificar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdListaValor", SqlDbType.Int)).Value = idListaValor;
                cmd.Parameters.Add(new SqlParameter("@IdLista", SqlDbType.Int)).Value = idLista;
                cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Text)).Value = valor;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.Text)).Value = descripcionLista;
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
        public List<ListaValor> ListaValor_Leer(int idListaValor, int idLista, string valor)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_ListaValorLeer";
            cmd.Connection = cn.cn;
            cn.Conectar();
            cmd.Parameters.Add(new SqlParameter("@IdListaValor", SqlDbType.Int)).Value = idListaValor;
            cmd.Parameters.Add(new SqlParameter("@IdLista", SqlDbType.Int)).Value = idLista;
            cmd.Parameters.Add(new SqlParameter("@Valor", SqlDbType.Text)).Value = valor;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<ListaValor> ListaValorLeer = new List<ListaValor>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListaValor listaValor = new ListaValor();
                listaValor.IdListaValor = Funciones.ToInt(dt.Rows[i]["IdListaValor"]);
                listaValor.IdLista = Funciones.ToInt(dt.Rows[i]["IdLista"]);
                listaValor.NombreLista = Funciones.ToString(dt.Rows[i]["NombreLista"]);
                listaValor.Valor = Funciones.ToString(dt.Rows[i]["Valor"]);
                listaValor.Descripcion = Funciones.ToString(dt.Rows[i]["Descripcion"]);
                listaValor.CreadoPor = Funciones.ToString(dt.Rows[i]["CreadoPor"]);
                listaValor.FechaCreacion = Funciones.ToDateTime(dt.Rows[i]["FechaCreacion"]);
                listaValor.ModificadoPor = Funciones.ToString(dt.Rows[i]["ModificadoPor"]);
                listaValor.FechaModificacion = Funciones.ToDateTime(dt.Rows[i]["FechaModificacion"]);
                ListaValorLeer.Add(listaValor);
            }
            cn.Desconectar();
            return ListaValorLeer;
        }

        public string ListaValor_Eliminar(int idListaValor)
        {
            string resultado = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ListaValorEliminar";
                cmd.Connection = cn.cn;
                cn.Conectar();
                cmd.Parameters.Add(new SqlParameter("@IdListaValor", SqlDbType.Int)).Value = idListaValor;
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
