using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

// Namespace declaration for the GYM_Management_System
namespace GYM_Management_System
{
    // Declaration of the NewMember class, which is a partial class of Form
    public partial class NewMember : Form
    {
        // Constructor for the NewMember class
        public NewMember()
        {
            // Initialize the components of the form
            InitializeComponent();
        }

        // Event handler for the Save button click
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            // Retrieve data from the form controls
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;

            string gender = "";

            // Check which radio button is checked to determine the gender
            bool isChecked = radioButton1.Checked;
            if (isChecked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }

            string dob = dateTimePickerDOB.Text;
            Int64 mobile = Int64.Parse(txtMobile.Text);
            string email = txtEmail.Text;
            string joindate = dateTimePickerJoinDate.Text;
            string gymTime = comboBoxGymTime.Text;
            string address = txtAddress.Text;
            string membership = comboBoxMembership.Text;

            try
            {
                // Create a SqlConnection and SqlCommand for database operations
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-2FC14BD;Initial Catalog=gym;Integrated Security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                
                // SQL query to insert data into the NewMember table
                cmd.CommandText = "insert into NewMember (Fname, Lname, Gender, Dob, Mobile, Email, JoinDate, Gymtime, Maddress, MembershipTime) values ('" + fname + "','" + lname + "','" + gender + "','" + dob + "','" + mobile + "','" + email + "','" + joindate + "','" + gymTime + "','" + address + "','" + membership + "')";

                // Use SqlDataAdapter to execute the command and fill the DataSet
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                // Display a success message
                MessageBox.Show("Data is saved.");
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
            txtFirstName.Clear();
            txtLastName.Clear();

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            txtMobile.Clear();
            txtEmail.Clear();

            comboBoxGymTime.ResetText();
            comboBoxMembership.ResetText();
            txtAddress.ResetText();

            dateTimePickerDOB.Value = DateTime.Now;
            dateTimePickerJoinDate.Value = DateTime.Now;
        }
    }
}
