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
    public partial class frmClientes : Form
    {

        cConexion cn;// variable cConexion 
        int i, boton, contador;
        SqlCommand cmd; //Variable para traer los comandos de sql
        SqlDataAdapter da;//Se necesita para las consultas
        DataTable dt;

        public frmClientes()
        {

            InitializeComponent();
            cn = new cConexion();
            i = 0; boton = 0;
            cmd = new SqlCommand("Select * from tblCliente", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt); //llena el dt o la tabla con la consulta de cmd
        }
        void habilita()
        {
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            txtDir.Enabled = true;
            txtTelefono.Enabled = true;
            txtFijo.Enabled = true;
            txtEmail.Enabled = true;

        }
        void limpia()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDir.Clear();
            txtTelefono.Clear();
            txtFijo.Clear();
            txtEmail.Clear();


        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            boton = 1;
            limpia();
            habilita();
            txtCodigo.Focus();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            llenar(dt, i);
        }

        private void btnConsulta1_Click(object sender, EventArgs e)
        {
            boton = 2;
            limpia();
            txtCodigo.Enabled = true;
            txtCodigo.Focus();
        }

        private void btnModificar1_Click(object sender, EventArgs e)
        {
            boton = 3;
            limpia();
            habilita();
            txtCodigo.Focus();
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {
            if (boton == 1)
            {
                cmd = new SqlCommand("insert into tblCliente values('" + txtCodigo.Text + "'," +
                    " '" + txtNombre.Text + "', '" + txtDir.Text + "'," +
                    " '" + txtTelefono.Text + "', '" + txtFijo.Text + "', " +
                    "'" + txtEmail.Text + "')", cn.AbrirConexion());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente Guardados");
                btnGuardar1.Enabled = false;
            }

            if (boton == 3)
            {
                cmd = new SqlCommand("update tblCliente set Codigo = '" + txtCodigo.Text + "', Nombre= '" + txtNombre.Text + "', Direccion= '" + txtDir.Text + "', Telefono= '" + txtTelefono.Text + "', TelefonoFijo= '" + txtFijo.Text + "', E-mail= '" + txtEmail.Text + "'", cn.AbrirConexion());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cliente Modificado");
                btnGuardar1.Enabled = false;
            }
        }

        private void btnRegistrar1_Click(object sender, EventArgs e)
        {
            boton = 4;
            limpia();
            habilita();
            txtCodigo.Enabled = true;
            txtCodigo.Focus();
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select * from tblCliente where Codigo = '" + txtCodigo.Text + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                switch (boton)
                {
                    case 1:
                        llenar(dt, 0);
                        MessageBox.Show("Ya tienes asignado el cliente.");
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
                        if (MessageBox.Show("Desea borrar el Cliente?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SqlCommand cm = new SqlCommand("delete from tblCliente where Codigo = '" + txtCodigo.Text + "'", cn.AbrirConexion());
                            cm.ExecuteNonQuery();
                            MessageBox.Show("Cliente Almacenado.");
                            btnGuardar1.Enabled = false;
                        }
                        break;

                }
            }


        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        void Deshabilita()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDir.Enabled = false;
            txtTelefono.Enabled = false;
            txtFijo.Enabled = false;
            txtEmail.Enabled = false;
        }
        void llenar(DataTable dt, int i)
        {
            txtCodigo.Text = dt.Rows[i][0].ToString();
            txtNombre.Text = dt.Rows[i][1].ToString();
            txtDir.Text = dt.Rows[i][2].ToString();
            txtTelefono.Text = dt.Rows[i][3].ToString();
            txtFijo.Text = dt.Rows[i][4].ToString();
            txtEmail.Text = dt.Rows[i][5].ToString();

            //Almacena la cantidad de registros de la tabla 

            contador = dt.Rows.Count;
        }
    }
}