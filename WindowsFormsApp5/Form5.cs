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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server =.;Database = termproject;Trusted_Connection = True;");
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM LANGUAGE", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "LANGUAGE");
            dataGridView1.DataSource = ds.Tables["LANGUAGE"];

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO LANGUAGE (L_ID,L_NAME)VALUES(@id,@name)", conn);
            komut.Parameters.AddWithValue("@id", textBox1.Text);
            komut.Parameters.AddWithValue("@name", textBox2.Text);

            komut.ExecuteNonQuery();

            textBox1.Clear();
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM LANGUAGE WHERE L_ID = @id", conn);
            komut.Parameters.AddWithValue("@id", textBox3.Text);
            komut.ExecuteNonQuery();

            textBox3.Clear();
            conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM LANGUAGE INNER JOIN THESIS ON LANGUAGE.L_ID = THESIS.THESIS_LANGUAGE", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"LANGUAGE INNER JOIN THESIS ON LANGUAGE.L_ID = THESIS.THESIS_LANGUAGE");
            dataGridView1.DataSource = ds.Tables["LANGUAGE INNER JOIN THESIS ON LANGUAGE.L_ID = THESIS.THESIS_LANGUAGE"];
            conn.Close();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM LANGUAGE WHERE L_ID LIKE '%" + textBox4.Text + "%'",conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "LANGUAGE L_ID LIKE '%" + textBox4.Text + "%'");
            dataGridView1.DataSource = ds.Tables["LANGUAGE L_ID LIKE '%" + textBox4.Text + "%'"];
            conn.Close();
            textBox4.Clear();


        }
    }
}
