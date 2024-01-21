using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Namespace declaration for the GYM_Management_System
namespace GYM_Management_System
{
    // Declaration of the DeleteMember class, which is a partial class of Form
    public partial class DeleteMember : Form
    {
        // Constructor for the DeleteMember class
        public DeleteMember()
        {
            // Initialize the components of the form
            InitializeComponent();
        }

        // Event handler for the Delete button click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the user confirms the deletion
                if (MessageBox.Show("This will delete your data. Confirm?", "Delete data", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Create a SqlConnection and SqlCommand for database operations
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-2FC14BD;Initial Catalog=gym;Integrated Security=true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    // SQL query to delete data from the NewMember table based on the entered member ID
                    cmd.CommandText = "delete from NewMember where MID = " + txtDelete.Text + "";

                    // Use SqlDataAdapter to execute the command and fill the DataSet
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);

                    // Display the updated data in the DataGridView
                    dataGridView1.DataSource = DS.Tables[0];
                }
                else
                {
                    // If deletion is not confirmed, reload the original data
                    this.Activate();
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-2FC14BD;Initial Catalog=gym;Integrated Security=true";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    // SQL query to select all data from the NewMember table
                    cmd.CommandText = "select * from NewMember";

                    // Use SqlDataAdapter to execute the command and fill the DataSet
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);

                    // Display the original data in the DataGridView
                    dataGridView1.DataSource = DS.Tables[0];
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the form's Load event
        private void DeleteMember_Load(object sender, EventArgs e)
        {
            // Load the data from the NewMember table into the DataGridView when the form is loaded
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-2FC14BD;Initial Catalog=gym;Integrated Security=true";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            // SQL query to select all data from the NewMember table
            cmd.CommandText = "select * from NewMember";

            // Use SqlDataAdapter to execute the command and fill the DataSet
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            // Display the data in the DataGridView
            dataGridView1.DataSource = DS.Tables[0];
        }
    }
}
