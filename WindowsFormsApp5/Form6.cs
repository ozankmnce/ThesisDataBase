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

namespace WindowsFormsApp5
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server =.;Database = termproject;Trusted_Connection = True;");

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM SUBJECT", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "SUBJECT");
            dataGridView1.DataSource = ds.Tables["SUBJECT"];
            conn.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO SUBJECT (SUB_ID,SUB_NAME)VALUES(@id,@name)", conn);
            komut.Parameters.AddWithValue("@id", textBox1.Text);
            komut.Parameters.AddWithValue("@name", textBox2.Text);

            komut.ExecuteNonQuery();
            conn.Close();

            textBox1.Clear();
            textBox2.Clear();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM SUBJECT WHERE SUB_ID = @id", conn);
            komut.Parameters.AddWithValue("@id", textBox3.Text);
            komut.ExecuteNonQuery();

            conn.Close();
            textBox3.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM SUBJECT INNER JOIN SUBJECT_OFTHESIS ON SUBJECT.SUB_ID = SUBJECT_OFTHESIS.SOT_SUBJECTID", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "SUBJECT INNER JOIN SUBJECT_OFTHESIS ON SUBJECT.SUB_ID = SUBJECT_OFTHESIS.SOT_SUBJECTID");
            dataGridView1.DataSource = ds.Tables["SUBJECT INNER JOIN SUBJECT_OFTHESIS ON SUBJECT.SUB_ID = SUBJECT_OFTHESIS.SOT_SUBJECTID"];
            conn.Close();


        }
    }
}
