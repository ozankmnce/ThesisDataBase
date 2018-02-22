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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server =.;Database = termproject;Trusted_Connection = True;");

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM THESIS", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "THESIS");
            dataGridView1.DataSource = ds.Tables["THESIS"];
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO THESIS(THESIS_ID,THESIS_TITLE,THESIS_AUTHOR,THESIS_YEAR,THESIS_PAGECOUNT,THESIS_LANGUAGE,THESIS_SUBDATE,THESIS_TOPICID)VALUES(@id,@title,@author,@year,@pagecount,@language,@subdate,@topicid)", conn);
            komut.Parameters.AddWithValue("@id", textBox1.Text);
            komut.Parameters.AddWithValue("@title", textBox2.Text);
            komut.Parameters.AddWithValue("@author", textBox3.Text);
            komut.Parameters.AddWithValue("@year", textBox4.Text.ToString());
            komut.Parameters.AddWithValue("@pagecount", textBox5.Text);
            komut.Parameters.AddWithValue("@language", textBox6.Text);
            komut.Parameters.AddWithValue("@subdate", textBox7.Text.ToString());
            komut.Parameters.AddWithValue("@topicid", textBox8.Text);

            komut.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM THESIS WHERE THESIS_ID = @id", conn);
            komut.Parameters.AddWithValue("@id", textBox9.Text);
            komut.ExecuteNonQuery();
            textBox9.Clear();

            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
