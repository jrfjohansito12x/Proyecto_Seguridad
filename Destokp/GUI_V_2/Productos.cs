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
    public partial class Productos : Form
    {
        ServicioSeguridad.ServicioSeguridadClient ws = new ServicioSeguridad.ServicioSeguridadClient();

        public Productos()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            txtClaveAcceso.PasswordChar = '*';
        }

        private void Button1_Click(object sender, EventArgs e)
        {
         String PermisoCreacion = "";
         String PermisoEjecucion = "";
         String PermisoEliminacion = "";
         String PermisoModificacion = "";
         String PermisoVisibilidad = "";

            if (txtUsuario.Text != "" && txtClaveAcceso.Text != "")
            {
                ServicioSeguridad.Usuario DatosUsuario = ws.Usuario_Iniciar_Sesion(txtUsuario.Text, txtClaveAcceso.Text);

                // Inicio

                if (DatosUsuario.IdUsuario != null)
                {
                    if (DatosUsuario.EstadoUsuario == Constantes.ESTADO_CUENTA_USUARIO_ACTIVO)
                    {

                        
                        ServicioSeguridad.Grupo[] DatosGrupo = ws.GrupoRolUsuario_Leer(0, "", DatosUsuario.IdUsuario);

                        foreach (ServicioSeguridad.Grupo Grupo in DatosGrupo)
                        {
                            if (Grupo.TipoPermiso == Constantes.ROL_TIPO_PERMISO_CREACION)
                                PermisoCreacion = Grupo.TipoPermiso;
                            if (Grupo.TipoPermiso == Constantes.ROL_TIPO_PERMISO_EJECUCION)
                                PermisoEjecucion = Grupo.TipoPermiso;
                            if (Grupo.TipoPermiso == Constantes.ROL_TIPO_PERMISO_ELIMINACION)
                               PermisoEliminacion = Grupo.TipoPermiso;
                            if (Grupo.TipoPermiso == Constantes.ROL_TIPO_PERMISO_MODIFICACION)
                               PermisoModificacion = Grupo.TipoPermiso;
                            if (Grupo.TipoPermiso == Constantes.ROL_TIPO_PERMISO_VISIBILIDAD)
                               PermisoVisibilidad = Grupo.TipoPermiso;
                        }


                        MessageBox.Show("Bienvenido :v", "Logueo Exitoso");
                        Form1 frmPrincipal = new Form1();                      
                        frmPrincipal.idUsuario = DatosUsuario.IdUsuario;
                        frmPrincipal.NombreUsuario = DatosUsuario.NombreUsuario;
                        frmPrincipal.ApellidoUsuario = DatosUsuario.ApellidoUsuario;
                        frmPrincipal.PermisoCreacion = PermisoCreacion;
                        frmPrincipal.PermisoEjecucion = PermisoEjecucion;
                        frmPrincipal.PermisoEliminacion = PermisoEliminacion;
                        frmPrincipal.PermisoModificacion = PermisoModificacion;
                        frmPrincipal.PermisoVisibilidad = PermisoVisibilidad;

                        frmPrincipal.Show();
                        this.Close();
                    }
                    else
                    {

                        MessageBox.Show("Usuario No Se Encuentra Activo Intente Mas Tarde ....", "Aviso");
                    }
                }
                else
                {
                    MessageBox.Show("Error Usuario No Encontrado", "ERROR");
                }

            }
            else
            {

                MessageBox.Show("Faltan Ingresar Credenciales", "Credenciales");

            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
