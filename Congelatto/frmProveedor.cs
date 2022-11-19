using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using Congelatto.ClaseCongelatto;

namespace Congelatto
{
    public partial class frmProveedor : Form
    {

        cConexion cn;// variable cConexion 
        int i, boton, contador;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand cmd;

        public frmProveedor()
        {
            InitializeComponent();
            cn = new cConexion();
            i = 0; boton = 0;
            cmd = new SqlCommand("Select * from tblProveedor", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }
        void habilita()
        {
            txtIdProveedor.Enabled = true;
            txtNombreP.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
           
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            boton = 3;
            limpia();
            habilita();
            txtIdProveedor.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void frmProveedor_Load(object sender, EventArgs e)
        {
            llenar(dt, i);
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            boton = 2;
            limpia();
            txtIdProveedor.Enabled = true;
            txtIdProveedor.Focus();
        }
        void limpia()
        {
            txtIdProveedor.Clear();
            txtNombreP.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            boton = 1;
            limpia();
            habilita();
            txtIdProveedor.Focus();
        }

        private void txtIdProveedor_Leave(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select * from tblProveedor where Id_Proveedor = '" + txtIdProveedor.Text + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                switch (boton)
                {
                    case 1:
                        llenar(dt, 0);
                        MessageBox.Show("Sonso ya esta el El proveedor se registro");
                        break;
                    case 2:
                        llenar(dt, 0);
                        Deshabilita();
                        break;
                    case 3:
                        llenar(dt, 0);
                        break;
                    case 4:
                        llenar(dt, 0);
                        if (MessageBox.Show("Desea borrar el Proveedor?", "Ojo pues", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SqlCommand cm = new SqlCommand("delete from tblProveedor where id_Proveedor = '" + txtIdProveedor.Text + "'", cn.AbrirConexion());
                            cm.ExecuteNonQuery();
                            MessageBox.Show("id de proveedor Guardada");
                            btnGuardar.Enabled = false;
                        }
                        break;

                }


            }
        }

    

        private void button4_Click(object sender, EventArgs e)
        {
            boton = 4;
            limpia();
            habilita();
            txtIdProveedor.Enabled = true;
            txtIdProveedor.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        void Deshabilita()
        {
            txtIdProveedor.Enabled = false;
           txtNombreP.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;
           
        }
        void llenar(DataTable dt, int i)
        {
            txtIdProveedor.Text = dt.Rows[i][0].ToString();
            txtNombreP.Text = dt.Rows[i][1].ToString();
            txtDireccion.Text = dt.Rows[i][2].ToString();
            txtTelefono.Text = dt.Rows[i][3].ToString();
            txtEmail.Text = dt.Rows[i][4].ToString();
            

            //Almacena la cantidad de registros de la tabla 

            contador = dt.Rows.Count;
        }
    }
}
