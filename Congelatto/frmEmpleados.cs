using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Congelatto.ClaseCongelatto;

namespace Congelatto
{
    public partial class frmEmpleados : Form
    {

        cConexion cn;// variable cConexion 
        int i, boton, contador;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand cmd;

        public frmEmpleados()
        {
            InitializeComponent();
            cn = new cConexion();
            i = 0; boton = 0;
            cmd = new SqlCommand("Select * from tblEmpleado", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }
        void habilita()
        {
            txtCedula.Enabled = true;
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            dtmFechaIngreso.Enabled = true;
            dtmFechasalida.Enabled = true;
            txtEmail.Enabled = true;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            boton = 1;
            limpia();
            txtCedula.Enabled = true;
            txtCedula.Focus();

        }
        void limpia()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {

        }
    }
}
