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
    
    public partial class Login : Form
    {
        SqlConnection con;
        public Login()
        {
            InitializeComponent();
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\C# Project\Project\Project\Attendance.mdf;Integrated Security=True";
            con = new SqlConnection(constr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usertype = "";
            string querry = "select * from Register_User where Name='" + textBox1.Text + "' AND Password='" + textBox3.Text + "'";
            SqlCommand cmd = new SqlCommand(querry, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                usertype = dr["user_type"].ToString();

            }
            else
            {

                MessageBox.Show("Invalid Credintials");
            }
            if (usertype.Equals("Admin"))
            {
                this.Hide();
                MakeRegistered mr = new MakeRegistered();
                mr.Show();
            }
            else
            {
                this.Hide();
                MainForm fp = new MainForm();
                fp.Show();

            }
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register rg = new Register();
            rg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register rg = new Register();
            rg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
