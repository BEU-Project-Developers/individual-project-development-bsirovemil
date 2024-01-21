using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

// Namespace declaration for the GYM_Management_System
namespace GYM_Management_System
{
    // Declaration of the Equipment class, which is a partial class of Form
    public partial class Equipment : Form
    {
        // Constructor for the Equipment class
        public Equipment()
        {
            // Initialize the components of the form
            InitializeComponent();
        }

        // Event handler for the Save button click
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Retrieve data from the form controls
            string EquipName = txtEquipName.Text;
            string Description = txtDescription.Text;
            string MUsed = txtMusclesUsed.Text;
            string DDate = dateTimePickerDeliveryDate.Text;
            Int64 Cost = Int64.Parse(txtCost.Text);

            try
            {
                // Create a SqlConnection and SqlCommand for database operations
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-2FC14BD;Initial Catalog=gym;Integrated Security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // SQL query to insert data into the Equipment table
                cmd.CommandText = "insert into Equipment (EquipName, EDescription, MUsed, DDate, Cost) values ('" + EquipName + "','" + Description + "','" + MUsed + "','" + DDate + "'," + Cost + ")";

                // Use SqlDataAdapter to execute the command and fill the DataSet
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                // Display a success message
                MessageBox.Show("Data is saved.", "Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the Reset button click
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset the values of various form controls
            txtEquipName.Clear();
            txtDescription.Clear();
            txtMusclesUsed.Clear();
            txtCost.Clear();
            dateTimePickerDeliveryDate.Value = DateTime.Now;
        }

        // Event handler for the View Equipment button click
        private void btnViewEq_Click(object sender, EventArgs e)
        {
            // Create an instance of the ViewEquipment form and show it
            ViewEquipment ve = new ViewEquipment();
            ve.Show();
        }
    }
}
