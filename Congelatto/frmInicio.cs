using System;
using System.Collections.Generic;
using System.ComponentModel;
using Congelatto.ClaseCongelatto;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Congelatto
{
    public partial class frmInicio : Form
    {
        cConexion cn;// variable cConexion 
        int contador;
        SqlCommand cmd; //Variable para traer los comandos de sql
        SqlDataAdapter da;//Se necesita para las consultas
        DataTable dt;

        public frmInicio()
        {
            InitializeComponent();
            cn = new cConexion();

        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("Select * from tblUsuario where NombreUsuario= '" + txtUsuario.Text + "' and Contraseña = '" + txtContraseña.Text + "' and cargo='" + txtCargo.Text + "'", cn.AbrirConexion());

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt); //llena el dt o la tabla con la consulta de cmd 

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                contador++;
                MessageBox.Show("Llevas" + contador + " equivocaciones");
                txtContraseña.Clear();
                txtUsuario.Clear();

                if (contador >= 3)
                {
                    MessageBox.Show("No puedes ingresar!! Datos incorrectos!!");
                    this.Close();
                }
            }
            else
            {
                cVariablesGlobales.tipousuario = dt.Rows[0][1].ToString();
                MenuPrincipal frm = new MenuPrincipal();
                frm.Show();
                this.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
