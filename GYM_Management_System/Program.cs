using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// Namespace declaration for the GYM_Management_System
namespace GYM_Management_System
{
    // Internal static class representing the entry point of the program
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable visual styles for the application
            Application.EnableVisualStyles();

            // Set compatible text rendering default for the application
            Application.SetCompatibleTextRenderingDefault(false);

            // Run the application, starting with the Login form
            Application.Run(new Login());
        }
    }
}
