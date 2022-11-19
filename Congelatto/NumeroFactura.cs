using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Congelatto.ClaseCongelatto;
using System.Data.SqlClient;

namespace Congelatto
{
    public partial class frmFactura : Form
    {
        cConexion cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public frmFactura()
        {
            InitializeComponent();
            cn = new cConexion();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int can = 0, precio_unit = 0, precio_total, total = 0;
            cmd = new SqlCommand("select  IdProveedor from tblProveedor where Id_Proveedor = '" + dtgFactura.Rows[e.RowIndex].Cells[0].Value + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            if (dtgFactura.Columns[e.ColumnIndex].Name == "IdFactura")
            {
                try
                {
                    dtgFactura.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0][0];
                    dtgFactura.Rows[e.RowIndex].Cells[2].Value = dt.Rows[0][1];

                }
                catch (Exception)
                {
                    MessageBox.Show("Debe ingresar un código de ");
                }
            }

            if (dtgFactura.Columns[e.ColumnIndex].Name == "cantidad")
            {
                can = int.Parse(dtgFactura.Rows[e.RowIndex].Cells[3].Value.ToString());
                precio_unit = int.Parse(dtgFactura.Rows[e.RowIndex].Cells[2].Value.ToString());

                if (can != 0)
                {
                    precio_total = can * precio_unit;
                    dtgFactura.Rows[e.RowIndex].Cells[4].Value = precio_total;
                    foreach (DataGridViewRow row in dtgFactura.Rows)
                    {
                        total += Convert.ToInt32(row.Cells["total"].Value);
                    }
                    lblTotal.Text = total.ToString();
                    
                }
                else
                {
                    MessageBox.Show("Debe ingresar una cantidad");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            timer1.Start();
            cmd = new SqlCommand("Select max(idFactura) from tblFactura", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            lblNumeroFactura.Text = Convert.ToString(Convert.ToInt32(dt.Rows[0][0].ToString()) + 1);
        }

        private void txtIdProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdProducto_Leave(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select * from tblProducto where IdProducto = '" + txtIdProducto.Text + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            txtIdProducto.Text = dt.Rows[0][1].ToString();
            txtNombre.Text = dt.Rows[0][2].ToString();
            txtIdEmpleado.Text = dt.Rows[0][3].ToString();
            txtNombreE.Text = dt.Rows[0][4].ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss   MM-dd-yyyy");

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into tblProveedor values('" + lblNumeroFactura.Text + "','" + txtIdProducto.Text + "','" + lblTotal.Text + "')", cn.AbrirConexion());
            for (int i = 0; i < dtgFactura.Rows.Count - 1; i++)
            {
                cmd = new SqlCommand("insert into tblProveedor Values('" + lblNumeroFactura.Text + "','" + dtgFactura.Rows[i].Cells[0].Value.ToString() + "','" + dtgFactura.Rows[i].Cells[3].Value.ToString() + "','" + dtgFactura.Rows[i].Cells[2].Value.ToString() + "')", cn.AbrirConexion());
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Factura Guardada");
            btnGuardar.Enabled = false;
        }
    }
    }

