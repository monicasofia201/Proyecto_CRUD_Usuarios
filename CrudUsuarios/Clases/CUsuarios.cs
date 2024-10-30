using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
CUsuarios.cs: Esta clase maneja las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) relacionadas con usuarios en una base de datos MySQL. 
Incluye métodos para mostrar todos los usuarios en un DataGridView, guardar nuevos usuarios, seleccionar detalles de usuarios para editar, 
modificar usuarios existentes y eliminar usuarios.
 */

namespace CrudUsuarios.Clases
{
    internal class CUsuarios
    {
        // Método para mostrar todos los usuarios en un DataGridView
        public void mostrarUsuarios(DataGridView tablaUsuarios)
        {
            try
            {
                // Crear objeto de conexión a la base de datos
                CConexion objetoConexion = new CConexion();

                // Consulta SQL para seleccionar todos los usuarios
                String query = "select * from usuarios";

                // Limpiar el origen de datos del DataGridView
                tablaUsuarios.DataSource = null;

                // Adaptador para ejecutar la consulta y obtener los resultados
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());

                // Crear una tabla en memoria para almacenar los datos
                DataTable dt = new DataTable();

                // Llenar la tabla con los datos obtenidos de la consulta
                adapter.Fill(dt);

                // Establecer la tabla como origen de datos del DataGridView
                tablaUsuarios.DataSource = dt;

                // Cerrar la conexión después de usarla
                objetoConexion.cerrarConexion();

            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre una excepción
                MessageBox.Show("No se mostraron los datos de la Base de Datos, error: " + ex.ToString());
            }
        }

        // Método para guardar un nuevo usuario en la base de datos
        public void guardarUsuarios(
            TextBox nombres,
            TextBox apellidos,
            TextBox celular,
            TextBox correo,
            TextBox direccion
            )
        {
            try
            {
                // Crear objeto de conexión a la base de datos
                CConexion objetoConexion = new CConexion();

                // Consulta SQL para insertar un nuevo usuario con los datos proporcionados
                String query = "insert into usuarios (nombres,apellidos,celular,correo,direccion)" +
                    "values ('" + nombres.Text + "','" + apellidos.Text + "','" + celular.Text + "','" + correo.Text + "','" + direccion.Text + "' )";

                // Ejecutar el comando SQL para insertar y obtener el resultado
                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myComand.ExecuteReader();

                // Mostrar mensaje de éxito después de guardar
                MessageBox.Show("¡Se guardó los registros exitosamente!");

                // Liberar recursos y cerrar la conexión
                while (reader.Read()) { /* no se realiza ninguna acción aquí */ }
                objetoConexion.cerrarConexion();

            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre una excepción
                MessageBox.Show("No se mostraron los datos de la Base de Datos, error: " + ex.ToString());
            }
        }

        // Método para seleccionar y mostrar los detalles de un usuario en controles TextBox
        public void seleccionarUsuarios(
            DataGridView tablaUsuarios,
            TextBox id,
            TextBox nombres,
            TextBox apellidos,
            TextBox celular,
            TextBox correo,
            TextBox direccion
            )
        {
            try
            {
                // Obtener los valores de la fila seleccionada en el DataGridView
                id.Text = tablaUsuarios.CurrentRow.Cells[0].Value.ToString();
                nombres.Text = tablaUsuarios.CurrentRow.Cells[1].Value.ToString();
                apellidos.Text = tablaUsuarios.CurrentRow.Cells[2].Value.ToString();
                celular.Text = tablaUsuarios.CurrentRow.Cells[3].Value.ToString();
                correo.Text = tablaUsuarios.CurrentRow.Cells[4].Value.ToString();
                direccion.Text = tablaUsuarios.CurrentRow.Cells[5].Value.ToString();

            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre una excepción al seleccionar
                MessageBox.Show("No se logró seleccionar, error: " + ex.ToString());
            }
        }

        // Método para modificar los datos de un usuario existente en la base de datos
        public void modificarUsuarios(
            TextBox id,
            TextBox nombres,
            TextBox apellidos,
            TextBox celular,
            TextBox correo,
            TextBox direccion
            )
        {
            try
            {
                // Crear objeto de conexión a la base de datos
                CConexion objetoConexion = new CConexion();

                // Consulta SQL para actualizar los datos del usuario
                String query = "update usuarios set nombres ='"
                                + nombres.Text +
                                "', apellidos = '" + apellidos.Text +
                                "', celular = '" + celular.Text +
                                "', correo = '" + correo.Text +
                                "', direccion = '" + direccion.Text +
                                "' where id = '" + id.Text + "';";

                // Ejecutar el comando SQL para actualizar y obtener el resultado
                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myComand.ExecuteReader();

                // Mostrar mensaje de éxito después de modificar
                MessageBox.Show("¡Se modificó los registros exitosamente!");

                // Liberar recursos y cerrar la conexión
                while (reader.Read()) { /* no se realiza ninguna acción aquí */ }
                objetoConexion.cerrarConexion();

            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre una excepción al modificar
                MessageBox.Show("No se actualizaron los datos en la Base de Datos, error: " + ex.ToString());
            }
        }

        // Método para eliminar un usuario de la base de datos
        public void eliminarUsuarios(
            TextBox id
            )
        {
            try
            {
                // Crear objeto de conexión a la base de datos
                CConexion objetoConexion = new CConexion();

                // Consulta SQL para eliminar un usuario por su ID
                String query = "delete from usuarios where id= '" + id.Text + "';";

                // Ejecutar el comando SQL para eliminar y obtener el resultado
                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myComand.ExecuteReader();

                // Mostrar mensaje de éxito después de eliminar
                MessageBox.Show("¡Se eliminó los registros exitosamente!");

                // Liberar recursos y cerrar la conexión
                while (reader.Read()) { /* no se realiza ninguna acción aquí */ }
                objetoConexion.cerrarConexion();

            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si ocurre una excepción al eliminar
                MessageBox.Show("No se eliminaron los datos en la Base de Datos, error: " + ex.ToString());
            }
        }


        private bool EsCorreoValido(string correo)
        {
            // Expresión regular para validar un correo electrónico
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Verificar si el correo coincide con el patrón
            return Regex.IsMatch(correo, patronCorreo);
        }



    }
}

