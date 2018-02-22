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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }
          SqlConnection conn = new SqlConnection("Server =.;Database = termproject;Trusted_Connection = True;");
        private void button1_Click(object sender, EventArgs e)
        {
            

            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM AUTHOR", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "AUTHOR");
            dataGridView1.DataSource = ds.Tables["AUTHOR"];

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO AUTHOR(A_ID,A_NAME,A_LASTNAME,A_INSTITUTEID)VALUES(@id,@name,@lastname,@instituteid)", conn);
            komut.Parameters.AddWithValue("@id", textBox1.Text);
            komut.Parameters.AddWithValue("@name", textBox2.Text);
            komut.Parameters.AddWithValue("@lastname", textBox3.Text);
            komut.Parameters.AddWithValue("@instituteid", textBox4.Text);

            komut.ExecuteNonQuery();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM AUTHOR WHERE A_ID = @id", conn);
            komut.Parameters.AddWithValue("@id", textBox5.Text);
            komut.ExecuteNonQuery();
            textBox5.Clear();
            conn.Close();

        }
       // ARAMA 
        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM AUTHOR WHERE A_ID LIKE '%" + textBox6.Text + "%'", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "AUTHOR WHERE T_NAME LIKE '%" + textBox6.Text + "%'");
            dataGridView1.DataSource = ds.Tables["AUTHOR WHERE T_NAME LIKE '%" + textBox6.Text + "%'"];
            conn.Close();
            textBox6.Clear();


        }
        //GÜNCELLE
        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM AUTHOR WHERE A_ID = '" + dataGridView1.CurrentCell.Value.ToString() + "'";
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["A_ID"].ToString();
                textBox2.Text = dr["A_NAME"].ToString();
                textBox3.Text = dr["A_LASTNAME"].ToString();
                textBox4.Text = dr["A_INSTITUTEID"].ToString();
            }
            conn.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM AUTHOR INNER JOIN INSTITUTE ON AUTHOR.A_INSTITUTEID = INSTITUTE.INS_ID INNER JOIN THESIS ON THESIS.THESIS_AUTHOR = AUTHOR.A_INSTITUTEID",conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "AUTHOR INNER JOIN INSTITUTE ON AUTHOR.A_INSTITUTEID = INSTITUTE.INS_ID INNER JOIN THESIS ON THESIS.THESIS_AUTHOR = AUTHOR.A_INSTITUTEID");
            dataGridView1.DataSource = ds.Tables["AUTHOR INNER JOIN INSTITUTE ON AUTHOR.A_INSTITUTEID = INSTITUTE.INS_ID INNER JOIN THESIS ON THESIS.THESIS_AUTHOR = AUTHOR.A_INSTITUTEID"];
            conn.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("UPDATE AUTHOR SET A_ID=@id, A_NAME=@name, A_LASTNAME=@lastname, A_INSTITUTEID=@instituteid WHERE A_ID = '" + dataGridView1.CurrentCell.Value.ToString() + "'", conn);            
            komut.Parameters.AddWithValue("@id", textBox1.Text);
            komut.Parameters.AddWithValue("@name", textBox2.Text);
            komut.Parameters.AddWithValue("@lastname", textBox3.Text);
            komut.Parameters.AddWithValue("@instituteid", textBox4.Text);

            komut.ExecuteNonQuery();
            
            conn.Close();
            MessageBox.Show("Yazar Bilgileri Güncellendi.");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
