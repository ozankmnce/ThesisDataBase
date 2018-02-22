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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server =.;Database = termproject;Trusted_Connection = True;");

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM SUPERVISOR", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "SUPERVISOR");
            dataGridView1.DataSource = ds.Tables["SUPERVISOR"];

            conn.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO SUPERVISOR(S_ID,S_NAME,S_LASTNAME)VALUES(@id,@name,@lastname)", conn);
            komut.Parameters.AddWithValue("@id", textBox1.Text);
            komut.Parameters.AddWithValue("@name", textBox2.Text);
            komut.Parameters.AddWithValue("@lastname", textBox3.Text);

            komut.ExecuteNonQuery();
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            conn.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM SUPERVISOR WHERE S_ID = @id", conn);
            komut.Parameters.AddWithValue("@id", textBox4.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            textBox4.Clear();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM SUPERVISOR INNER JOIN SUPERVISOR_OFTHESIS ON SUPERVISOR.S_ID = SUPERVISOR_OFTHESIS.SOT_SUPERVISORID",conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"SUPERVISOR INNER JOIN SUPERVISOR_OFTHESIS ON SUPERVISOR.S_ID = SUPERVISOR_OFTHESIS.SOT_SUPERVISORID");
            dataGridView1.DataSource = ds.Tables["SUPERVISOR INNER JOIN SUPERVISOR_OFTHESIS ON SUPERVISOR.S_ID = SUPERVISOR_OFTHESIS.SOT_SUPERVISORID"];
            conn.Close();




        }
    }
}
