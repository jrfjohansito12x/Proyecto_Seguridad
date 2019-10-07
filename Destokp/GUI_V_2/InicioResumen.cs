using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_V_2
{
    public partial class InicioResumen : Form
    {
        public String PermisoCreacion = "";
        public String PermisoEjecucion = "";
        public String PermisoEliminacion = "";
        public String PermisoModificacion = "";
        public String PermisoVisibilidad = "";
        ServicioSeguridad.ServicioSeguridadClient ws = new ServicioSeguridad.ServicioSeguridadClient();
        public InicioResumen()
        {           
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void InicioResumen_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
            txtClaveAcceso.PasswordChar = '*';
        }


        public void ListarUsuarios()
        {
            try
            {
                this.dgvListadoDeUsuario.DataSource = ws.Usuario_LeerTodo("", "");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al pintar los datos en la tabla dgvListadoDeUsuario ");
            }

        }

        private void Lblhora_Click(object sender, EventArgs e)
        {

        }

        private void Label15_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (PermisoCreacion == Constantes.ROL_TIPO_PERMISO_CREACION)
            {
                if (txtUsuario.Text != "" && txtNombre.Text != "" && txtApellido.Text != "" && txtClaveAcceso.Text != "" && txtEmail.Text != "")
                {

                    string rep = ws.Usuario_Registrar(txtUsuario.Text, txtNombre.Text, txtApellido.Text, txtClaveAcceso.Text, txtEmail.Text, "ESUSAC", (Environment.MachineName).ToString());
                    if (rep.Substring(0, 6) == "[CREO]")
                    {
                        MessageBox.Show("El Usuario Se Grabo Con Exito", "Grabado");
                        txtUsuario.Text = "";
                        txtNombre.Text = "";
                        txtApellido.Text = "";
                        txtClaveAcceso.Text = "";
                        txtEmail.Text = "";
                        ListarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("Error Al Grabar Intente Nuevamente Mas Tarde ....", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Parametros Rellenar Todos Los Campos", "Parametos Incompletos");

                }
            }
            else {
                MessageBox.Show("No CuenTa Con Pemiso Para Registrar Usuarios","Aviso");
            }

        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }


}
