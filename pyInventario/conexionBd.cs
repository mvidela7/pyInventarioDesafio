using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pyInventario
{
    internal class conexionBd
    {
        internal class clsConexionBD
        {
            //cadena de conexion
            //sql - string cadenaConexion = "Server=localhost;Database=Ventas2;Trusted_Connection=True;";
            string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\BaseDatos\\bdRPG.accdb";
            //conector
            //SqlConnection coneccionBaseDatos;
            OleDbConnection coneccionBaseDatos;
            //comando
            //SqlCommand comandoBaseDatos;
            OleDbCommand comandoBaseDatos;

            public string nombreBaseDeDatos;

            public void ConectarBD()
            {
                try
                {
                    //coneccionBaseDatos = new SqlConnection(cadenaConexion);
                    coneccionBaseDatos = new OleDbConnection(cadenaConexion);

                    nombreBaseDeDatos = coneccionBaseDatos.Database;

                    coneccionBaseDatos.Open();

                    MessageBox.Show("Conectado a " + nombreBaseDeDatos);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Tiene un errorcito - " + error.Message);
                }
            }
        }
    }
}
