using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GUI_V_2
{
    public partial class Form1 : Form
    {

        public string idUsuario = "";
        public string NombreUsuario = "";
        public string ApellidoUsuario = "";

        public String PermisoCreacion = "";
        public String PermisoEjecucion = "";
        public String PermisoEliminacion = "";
        public String PermisoModificacion = "";
        public String PermisoVisibilidad = "";



        public Form1()
        {
            InitializeComponent();
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
                MenuVertical.Width = 250;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;           
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            InicioResumen frm = new InicioResumen();
            frm.PermisoCreacion = PermisoCreacion;
            frm.PermisoEjecucion = PermisoEjecucion;
            frm.PermisoEliminacion = PermisoEliminacion;
            frm.PermisoModificacion = PermisoModificacion;
            frm.PermisoVisibilidad = PermisoVisibilidad;
            AbrirFormEnPanel(frm);
        }

        private void btnlogoInicio_Click(object sender, EventArgs e)
        {
            InicioResumen frm = new InicioResumen();
            frm.PermisoCreacion = PermisoCreacion;
            frm.PermisoEjecucion = PermisoEjecucion;
            frm.PermisoEliminacion = PermisoEliminacion;
            frm.PermisoModificacion = PermisoModificacion;
            frm.PermisoVisibilidad = PermisoVisibilidad;
        AbrirFormEnPanel(frm);
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
        lblUsuario.Text = idUsuario;
        lblNombreUser.Text = NombreUsuario;
        lblApellidoUser.Text = ApellidoUsuario;
        btnlogoInicio_Click(null,e);

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            InicioResumen frm = new InicioResumen();
            frm.PermisoCreacion = PermisoCreacion;
            frm.PermisoEjecucion = PermisoEjecucion;
            frm.PermisoEliminacion = PermisoEliminacion;
            frm.PermisoModificacion = PermisoModificacion;
            frm.PermisoVisibilidad = PermisoVisibilidad;
            AbrirFormEnPanel(frm);
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
