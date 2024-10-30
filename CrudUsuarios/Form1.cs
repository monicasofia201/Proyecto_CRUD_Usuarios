using CrudUsuarios.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Form1.cs: Este archivo define la interfaz de usuario principal de la aplicación CRUD de usuarios. 
Al cargar, inicializa componentes visuales, muestra la lista de usuarios en un DataGridView utilizando la clase CUsuarios, 
permite buscar usuarios, guardar nuevos usuarios, modificar usuarios existentes, eliminar usuarios y mostrar detalles de usuarios seleccionados en controles TextBox. 
*/

namespace CrudUsuarios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Inicialización de componentes del formulario
            InitializeComponent();

            // Crear objeto de la clase CUsuarios para gestionar operaciones de usuarios
            Clases.CUsuarios objetoUsuarios = new Clases.CUsuarios();

            // Mostrar todos los usuarios en el DataGridView al cargar el formulario
            objetoUsuarios.mostrarUsuarios(dgUsuarios);
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Crear objeto de conexión a la base de datos al hacer clic en el botón Buscar
            Clases.CConexion objetoConexion = new Clases.CConexion();
            objetoConexion.establecerConexion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener el correo electrónico del TextBox txtCorreo
            string correo = txtCorreo.Text.Trim();

            // Validar el formato del correo electrónico usando el método EsCorreoValido
            if (EsCorreoValido(correo))
            {
                // Crear objeto de la clase CUsuarios para guardar un nuevo usuario
                Clases.CUsuarios objetoUsuarios = new Clases.CUsuarios();

                // Guardar el usuario con los datos ingresados en los TextBox
                objetoUsuarios.guardarUsuarios(txtNombres, txtApellidos, txtCelular, txtCorreo, txtDireccion);

                // Actualizar la lista de usuarios mostrada en el DataGridView
                objetoUsuarios.mostrarUsuarios(dgUsuarios);
            }
            else
            {
                MessageBox.Show("El correo electrónico no es válido. Por favor, ingresa uno válido."); // Mostrar mensaje de error si el correo no es válido
                txtCorreo.Focus(); // Enfocar el TextBox de correo para corregirlo
            }
        }

        private bool EsCorreoValido(string correo)
        {
            // Expresión regular para validar un correo electrónico
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Verificar si el correo coincide con el patrón
            return Regex.IsMatch(correo, patronCorreo);
        }


        private void dgUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Crear objeto de la clase CUsuarios para seleccionar y mostrar detalles de un usuario al hacer doble clic en una celda del DataGridView
            Clases.CUsuarios objetoUsuarios = new Clases.CUsuarios();

            // Mostrar los detalles del usuario seleccionado en los TextBox correspondientes
            objetoUsuarios.seleccionarUsuarios(dgUsuarios, txtId, txtNombres, txtApellidos, txtCelular, txtCorreo, txtDireccion);

            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnGuardar.Enabled = false;

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            // Crear objeto de la clase CUsuarios para modificar los datos de un usuario existente
            Clases.CUsuarios objetoUsuarios = new Clases.CUsuarios();

            // Modificar los datos del usuario con los valores actuales de los TextBox
            objetoUsuarios.modificarUsuarios(txtId, txtNombres, txtApellidos, txtCelular, txtCorreo, txtDireccion);

            // Actualizar la lista de usuarios mostrada en el DataGridView
            objetoUsuarios.mostrarUsuarios(dgUsuarios);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Crear objeto de la clase CUsuarios para eliminar un usuario
            Clases.CUsuarios objetoUsuarios = new Clases.CUsuarios();

            // Eliminar el usuario con el ID ingresado en el TextBox
            objetoUsuarios.eliminarUsuarios(txtId);

            // Actualizar la lista de usuarios mostrada en el DataGridView
            objetoUsuarios.mostrarUsuarios(dgUsuarios);
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled=true;
            txtId.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtCelular.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
