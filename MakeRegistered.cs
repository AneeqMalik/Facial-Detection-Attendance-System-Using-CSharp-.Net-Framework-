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
using Excel = Microsoft.Office.Interop.Excel;

namespace Project
{
    public partial class MakeRegistered : Form
    {
        SqlConnection con;
        public MakeRegistered()
        {
            InitializeComponent();
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\C# Project\Project\Project\Attendance.mdf;Integrated Security=True";
            con = new SqlConnection(constr);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string aa = "no";
            string usertype = "Student";
            string query = "SELECT Name,roll_no,reg_date from Register_User where user_type='" + usertype + "'AND Registered='" + aa + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            da.Update(dt);
            con.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            string aa = "no";
            string usertype = "Teacher";
            string query = "SELECT Name,Specification,reg_date from Register_User where user_type='" + usertype + "' AND Registered='" + aa + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            da.Update(dt);
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * from Attendance";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            da.Update(dt);
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1 && dataGridView1.SelectedRows[0].Index != dataGridView1.Rows.Count - 1)
            {
                int aa = 1;
                string querry = "update Register_User set Registered='" + aa + "' where Name='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(querry, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Verified Registeration");

            }
            else
            {
                MessageBox.Show("Please Select row first Or Invalid Data", "Warning");

            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection cnn;

            string connectionString = null;

            string sql = null;

            string data = null;

            int i = 0;

            int j = 0;



            Excel.Application xlApp;

            Excel.Workbook xlWorkBook;

            Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;



            xlApp = new Excel.Application();

            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);



            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\C# Project\Project\Project\Attendance.mdf;Integrated Security=True";

            cnn = new SqlConnection(connectionString);

            cnn.Open();

            sql = "SELECT * FROM Attendance ";

            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);

            DataSet ds = new DataSet();

            dscmd.Fill(ds);



            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {

                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {

                    data = ds.Tables[0].Rows[i].ItemArray[j].ToString();

                    xlWorkSheet.Cells[i + 1, j + 1] = data;

                }

            }



            xlWorkBook.SaveAs("ATTENDANCE.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);


            xlWorkBook.Close(true, misValue, misValue);

            xlApp.Quit();



            releaseObject(xlWorkSheet);

            releaseObject(xlWorkBook);

            releaseObject(xlApp);



            MessageBox.Show("Excel file created");

        }
        private void releaseObject(object obj)

        {

            try

            {

                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);

                obj = null;

            }

            catch (Exception ex)

            {

                obj = null;

                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());

            }

            finally

            {

                GC.Collect();

            }

        }
    }
    
}
