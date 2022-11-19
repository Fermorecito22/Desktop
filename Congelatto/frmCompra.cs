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
    public partial class frmCompra : Form
    {
        cConexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int x;
        int i, boton;
        public frmCompra()
        {
            InitializeComponent();
            i = 0; boton = 0;
            cn = new cConexion();
            x = -1;
        }

        private void frmCompra_Load(object sender, EventArgs e)
        {
            llenar();
            timer1.Start();
            lblFecha.Text = DateTime.UtcNow.ToString("MM-dd-yyyy");
            txtCodigo.Text = cVariablesGlobales.ProductoId;
            txtNombre.Text = cVariablesGlobales.ProdutoNombre;
            txtCategoria.Text = cVariablesGlobales.ProductoCategoria;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");

        }
        void llenar()
        {
            cmd = new SqlCommand("select Id_producto from tblProducto", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstProducto.Items.Add(dt.Rows[i][0]);
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select Id_Categoria from tblProducto where Id_producto = '" + txtCodigo.Text + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtNombre.Text = dt.Rows[0][0].ToString();
                

                Habilitar();
            }
            else
            {
                MessageBox.Show("No se encontro el producto.");
                Limpiar();
            }
        }
        void Habilitar()
        {
            btnPasauno.Enabled = true;
            btnPasatodo.Enabled = true;
            btnQuitatodo.Enabled = true;
            btnQuitauno.Enabled = true;

        }

        void Deshabilitar()
        {
            btnPasauno.Enabled = false;
            btnPasatodo.Enabled = false;
            btnQuitatodo.Enabled = false;
            btnQuitauno.Enabled = false;
        }

        void Limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCategoria.Clear();
            Deshabilitar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (boton == 1)
            {
                cmd = new SqlCommand("insert into tblProducto values('" + txtCodigo.Text + "'," +
                    " '" + txtNombre.Text + "', '" + txtCategoria.Text + "')", cn.AbrirConexion());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto Guardados");
                btnGuardar.Enabled = false;
            }

            if (boton == 3)
            {
                cmd = new SqlCommand("update tblProducto set Id_producto = '" + txtCodigo.Text + "', NombreProducto= '" + txtNombre.Text + "', Id_Categoria= '" + txtCategoria.Text + "'", cn.AbrirConexion());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Producto Modificado");
                btnGuardar.Enabled = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lstProducto.Items.Clear();
            llenar();
            lstCompra.Items.Clear();
            Limpiar();
            Deshabilitar();
        }

        private void btnPasauno_Click(object sender, EventArgs e)
        {
            x = lstProducto.SelectedIndex;
            if (x == -1)
            {
                MessageBox.Show("No hay ningun Producto.");
            }
            else
            {
                lstCompra.Items.Add(lstProducto.SelectedItem);
                lstProducto.Items.Remove(lstProducto.SelectedItem);
            }
        }

        private void btnPasatodo_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select Id_Producto from tblProducto", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstCompra.Items.Add(dt.Rows[i][0]);
            }
            lstProducto.Items.Clear();
        }

        private void btnQuitauno_Click(object sender, EventArgs e)
        {
            x = lstCompra.SelectedIndex;
            if (x == -1)
            {
                MessageBox.Show("No hay ningun Producto seleccionado");
            }
            else
            {
                lstProducto.Items.Add(lstCompra.SelectedItem);
                lstCompra.Items.Remove(lstCompra.SelectedItem);
            }
        }

        private void btnQuitatodo_Click(object sender, EventArgs e)
        {
            lstProducto.Items.Clear();
            llenar();
            lstCompra.Items.Clear();
        }
        void calcular()
        {
            int Total = 0;
            for (int i = 0; i < lstCompra.Items.Count; i++)
            {
                cmd = new SqlCommand("select Precio from tblProducto where Id_Producto = '" + lstCompra.Items[i] + "'", cn.AbrirConexion());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                Total += Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            txtTotalP.Text = Total.ToString();
        }

        private void lstCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcular();

        }

        private void lstCompra_SelectedValueChanged(object sender, EventArgs e)
        {
            calcular();

        }

        private void lstCompra_TabIndexChanged(object sender, EventArgs e)
        {
            calcular();

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
