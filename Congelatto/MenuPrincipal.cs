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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void ingresoDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.Show();
        }

        private void ingresoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.Show();
        }

        private void ingresoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleados frm = new frmEmpleados();
            frm.Show();
        }

        private void ingresoDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompra frm = new frmCompra();
            frm.Show();
        }

        private void ingresoDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmVentas frm = new frmVentas();
            //frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbClientes_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.Show();
        }

        private void tsbProveedores_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.Show();
        }

    }
}
