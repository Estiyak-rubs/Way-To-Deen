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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Way_to_Deen
{
    public partial class AdminFeedback : Form
    {
        public AdminFeedback()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UJGC92B\SQLEXPRESS;Initial Catalog=WaytoDeen;Integrated Security=True");

        private void textBox1_Click(object sender, EventArgs e)
        {
            ResetText();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            ResetText();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        string g;
        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from Feedback", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                g = "Very Unsatisfied";

            }
            else if (radioButton2.Checked == true)
            {
                g = "Unsatisfied";
            }
            else if (radioButton3.Checked == true)
            {
                g = "Comfortable";
            }
            else if (radioButton4.Checked == true)
            {
                g = "Satisfied";
            }
            else
            {
                g = "Very Satisfied";
            }
            con.Open();

            string query = "INSERT INTO Feedback VALUES (@textBoxValue, @gValue, @richTextBoxValue)";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@textBoxValue", textBox1.Text);
                command.Parameters.AddWithValue("@gValue", g); // Assuming 'g' is a variable with the appropriate value
                command.Parameters.AddWithValue("@richTextBoxValue", richTextBox1.Text);

                command.ExecuteNonQuery();
            }

            con.Close();
            MessageBox.Show("Thank you for your Feedback!", "Feedback", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            BindData();
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "delete from Feedback where id=@id";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox2.Text);


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data deleted Successfully.. ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindData();
                
            }
            else
            {
                MessageBox.Show("Data not delated !!!! ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminFeedback_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
