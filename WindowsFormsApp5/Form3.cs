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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server =.;Database = termproject;Trusted_Connection = True;");
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM INSTITUTE",conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "INSTITUTE");
            dataGridView1.DataSource = ds.Tables["INSTITUTE"];
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO INSTITUTE(INS_ID,INS_NAME,INS_university)VALUES(@id,@name,@uni)", conn);
            komut.Parameters.AddWithValue("@id", textBox1.Text);
            komut.Parameters.AddWithValue("@name", textBox2.Text);
            komut.Parameters.AddWithValue("@uni", textBox3.Text);

            komut.ExecuteNonQuery();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM INSTITUTE WHERE INS_ID = @id", conn);
            komut.Parameters.AddWithValue("@id", textBox4.Text);
            komut.ExecuteNonQuery();

            conn.Close();
            textBox4.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM INSTITUTE INNER JOIN AUTHOR ON INSTITUTE.INS_university = AUTHOR.A_INSTITUTEID INNER JOIN UNIVERSITY ON UNIVERSITY.UNI_ID = INSTITUTE.INS_university", conn);
            DataSet ds = new DataSet("INSTITUTE INNER JOIN AUTHOR ON INSTITUTE.INS_university = AUTHOR.A_INSTITUTEID INNER JOIN UNIVERSITY ON UNIVERSITY.UNI_ID = INSTITUTE.INS_university");
            adapter.Fill(ds, "INSTITUTE INNER JOIN AUTHOR ON INSTITUTE.INS_university = AUTHOR.A_INSTITUTEID INNER JOIN UNIVERSITY ON UNIVERSITY.UNI_ID = INSTITUTE.INS_university");
            dataGridView1.DataSource = ds.Tables["INSTITUTE INNER JOIN AUTHOR ON INSTITUTE.INS_university = AUTHOR.A_INSTITUTEID INNER JOIN UNIVERSITY ON UNIVERSITY.UNI_ID = INSTITUTE.INS_university"];
            conn.Close();



        }
    }
}
