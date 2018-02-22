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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server =.;Database = termproject;Trusted_Connection = True;");
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM UNIVERSITY", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "UNIVERSITY");
            dataGridView1.DataSource = ds.Tables["UNIVERSITY"];
            conn.Close();


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO UNIVERSITY(UNI_ID,UNI_NAME,UNI_LOCATION)VALUES(@id,@name,@location)", conn);
            komut.Parameters.AddWithValue("@id", textBox1.Text);
            komut.Parameters.AddWithValue("@name", textBox2.Text);
            komut.Parameters.AddWithValue("@location", textBox3.Text);

            komut.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM UNIVERSITY WHERE UNI_ID = @id", conn);
            komut.Parameters.AddWithValue("@id", textBox4.Text);
            komut.ExecuteNonQuery();
            textBox4.Clear();
            conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM UNIVERSITY INNER JOIN INSTITUTE ON UNIVERSITY.UNI_ID = INSTITUTE.INS_university", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "UNIVERSITY INNER JOIN INSTITUTE ON UNIVERSITY.UNI_ID = INSTITUTE.INS_university");
            dataGridView1.DataSource = ds.Tables["UNIVERSITY INNER JOIN INSTITUTE ON UNIVERSITY.UNI_ID = INSTITUTE.INS_university"];
            conn.Close();

        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
}
