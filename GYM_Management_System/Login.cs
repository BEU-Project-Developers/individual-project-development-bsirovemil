using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Namespace declaration for the GYM_Management_System
namespace GYM_Management_System
{
    // Declaration of the Login class, which is a partial class of Form
    public partial class Login : Form
    {
        // Constructor for the Login class
        public Login()
        {
            // Initialize the components of the form
            InitializeComponent();
        }

        // Event handler for the login button click
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Check if the entered username and password are both "admin"
            if (txtBoxUsername.Text == "admin" && txtBoxPassword.Text == "admin")
            {
                // If credentials are correct, create an instance of Form1 and show it
                Form1 fm = new Form1();
                fm.Show();
                
                // Hide the current login form
                this.Hide();
            }
            else
            {
                // If credentials are incorrect, show an error message
                MessageBox.Show("Incorrect Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
