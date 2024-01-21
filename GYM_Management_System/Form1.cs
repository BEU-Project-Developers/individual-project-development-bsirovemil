using System;
using System.Drawing;
using System.Windows.Forms;

// Namespace declaration for the GYM_Management_System
namespace GYM_Management_System
{
    // Declaration of the Form1 class, which is a partial class of Form
    public partial class Form1 : Form
    {
        // Constructor for the Form1 class
        public Form1()
        {
            // Initialize the components of the form
            InitializeComponent();
        }

        // Variable to track the state of the menu (docked left or top)
        bool b = true;

        // Event handler for the ToolStripMenuItem1 click event
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Toggle between docking the menu left or top
            if (b == true)
            {
                menuStrip1.Dock = DockStyle.Left;
                b = false;
                toolStripMenuItem1.Image = Image.FromFile(@"../../Name-48-50px/img3.jpg");
            }
            else
            {
                menuStrip1.Dock = DockStyle.Top;
                b = true;
                toolStripMenuItem1.Image = Image.FromFile(@"../../Name-48-50px/img2.jpg");
            }
        }

        // Event handler for the Form1 Load event
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the initial image for ToolStripMenuItem1 during form load
            toolStripMenuItem1.Image = Image.FromFile(@"../../Name-48-50px/img2.jpg");
        }

        // Event handlers for various menu item clicks to open corresponding forms
        private void newMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMember nm = new NewMember();
            nm.Show();
        }

        private void newStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewStaff ns = new NewStaff();
            ns.Show();
        }

        private void equipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Equipment equipment = new Equipment();
            equipment.Show();
        }

        private void searchMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchMember sm = new SearchMember();
            sm.Show();
        }

        private void deleteMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteMember dm = new DeleteMember();
            dm.Show();
        }

        // Event handler for the Exit menu item click
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prompt user to confirm application closure
            if (MessageBox.Show("This will close your application. Confirm?", "CLOSE", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                // If confirmed, exit the application
                Application.Exit();
            }
            else
            {
                // If canceled, display a welcome back message
                MessageBox.Show("Welcome back!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event handler for the Log Out menu item click
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prompt user to confirm log out
            if ((MessageBox.Show("You will log out! Confirm?", "LOG OUT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK))
            {
                // If confirmed, close the current form and show the login form
                this.Close();
                Login lg = new Login();
                lg.Show();
            }
        }
    }
}
