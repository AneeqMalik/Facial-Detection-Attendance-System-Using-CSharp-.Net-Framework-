using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Project
{
    public partial class Register : Form
    {
        SqlConnection con;
        public Register()
        {
            InitializeComponent();
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\C# Project\Project\Project\Attendance.mdf;Integrated Security=True";
            con = new SqlConnection(constr);
        }

        private void Register_Load(object sender, EventArgs e)
        {
            textBox5.Text = DateTime.Now.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string reg = "no";
            string query = "insert into Register_User(Name,Email,Password,Contact,user_type,reg_date,Specification,roll_no,Registered)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + reg + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if(a != 0)
            {
                MessageBox.Show("Registered Succesfully"+MessageBoxButtons.OK + MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Not Registered" + MessageBoxButtons.OK + MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            if (comboBox1.SelectedItem.ToString().Equals("Student"))
            {
                textBox7.Visible = true;
                label7.Visible = true;
                label8.Visible = false;
                textBox6.Visible = false;
            }
            else if (comboBox1.SelectedItem.ToString().Equals("Teacher"))
            {
                label7.Visible = false;
                label8.Visible = true;
                textBox7.Visible = false;
                textBox6.Visible = true;

            }
            else
            {
                label7.Visible = false;
                label8.Visible = false;
                textBox7.Visible = false;
                textBox6.Visible = false;
            }

        }
    }
}
