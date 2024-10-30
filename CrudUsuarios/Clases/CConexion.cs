using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
CConexion.cs: Esta clase se encarga de gestionar la conexión a una base de datos MySQL. Define la configuración de conexión 
(servidor, base de datos, usuario, contraseña, puerto) y proporciona métodos para establecer y cerrar la conexión con la base de datos. 
*/

namespace CrudUsuarios.Clases
{
    internal class CConexion
    {
        // Objeto de conexión MySQL
        MySqlConnection conex = new MySqlConnection();

        // Variables estáticas para la configuración de la conexión
        static string servidor = "localhost";
        static string bd = "prueba_c";
        static string usuario = "root";
        static string password = "";
        static string puerto = "3306";

        // Cadena de conexión construida a partir de las variables estáticas
        string cadenaConexion = "server=" + servidor + ";" +
                                "port=" + puerto + ";" +
                                "user id=" + usuario + ";" +
                                "password=" + password + ";" +
                                "database=" + bd + ";";

        // Método para establecer la conexión a la base de datos
        public MySqlConnection establecerConexion()
        {
            try
            {
                // Configurar la cadena de conexión y abrir la conexión
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                //MessageBox.Show("¡Se conectó a la Base de datos exitosamente!");
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si no se puede establecer la conexión
                MessageBox.Show("No se conectó a la Base de datos, error" + ex.ToString());
            }
            return conex;
        }

        // Método para cerrar la conexión a la base de datos
        public void cerrarConexion()
        {
            conex.Close();
        }

    }
}
