﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GYM_Management_System
{
    // Declaration of the SearchMember class, which is a partial class of Form
    public partial class SearchMember : Form
    {
        // Constructor for the SearchMember class
        public SearchMember()
        {
            // Initialize the components of the form
            InitializeComponent();
        }

        // Event handler for the Search button click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a SqlConnection and SqlCommand for database operations
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-2FC14BD;Initial Catalog=gym;Integrated Security=true";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // SQL query to select all data from the NewMember table where MID matches the entered value
                cmd.CommandText = "select * from NewMember where MID = " + txtSearch.Text + "";

                // Use SqlDataAdapter to execute the command and fill the DataSet
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                // Display the search results in the DataGridView
                dataGridView1.DataSource = DS.Tables[0];
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
