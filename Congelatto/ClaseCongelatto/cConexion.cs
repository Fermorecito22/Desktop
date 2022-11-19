using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace Congelatto.ClaseCongelatto
{
     class cConexion
    {
        //se define la ruta de la base de datos 
        static private String CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LuisFernandoRengifoP\Documents\dbHeladeria.mdf;Integrated Security=True;Connect Timeout=30";
        //Define una variable para cargar la base de datos 
        private SqlConnection Conexion = new SqlConnection(CadenaConexion);

        //Es el que trae los comandos de sql

        //Metodo para abrir la base de datos 
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        //Metodo para cerrar la base de datos 
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
