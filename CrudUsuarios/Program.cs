using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Program.cs: Este archivo sirve como punto de entrada principal de la aplicación. Configura la apariencia visual de la aplicación, 
establece la compatibilidad con el renderizado de texto e inicia la ejecución mostrando el formulario principal Form1.
*/

namespace CrudUsuarios
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // Mostrar mensaje de bienvenida al inicio
            //MessageBox.Show("¡Bienvenido a la aplicación CRUD de Usuarios!", "Bienvenida", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Habilitar estilos visuales de la aplicación
            Application.EnableVisualStyles();

            // Establecer la compatibilidad predeterminada con texto renderizado
            Application.SetCompatibleTextRenderingDefault(false);

            // Ejecutar la aplicación mostrando el formulario principal Form1
            Application.Run(new Form1());
        }
    }
}
