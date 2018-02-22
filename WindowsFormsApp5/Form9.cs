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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server =.;Database = termproject;Trusted_Connection = True;");

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM SUPERVISOR_OFTHESIS", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "SUPERVISOR_OFTHESIS");
            dataGridView1.DataSource = ds.Tables["SUPERVISOR_OFTHESIS"];
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO SUPERVISOR_OFTHESIS(SOT_ID,SOT_THESISID,SOT_SUPERVISORID)VALUES(@id,@thesisid,@supervisorid)",conn);
            komut.Parameters.AddWithValue("@id",textBox1.Text);
            komut.Parameters.AddWithValue("@thesisid", textBox2.Text);
            komut.Parameters.AddWithValue("@supervisorid", textBox3.Text);

            komut.ExecuteNonQuery();
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM SUPERVISOR_OFTHESIS WHERE SOT_ID = @id", conn);
            komut.Parameters.AddWithValue("@id", textBox4.Text);
            komut.ExecuteNonQuery();
            textBox4.Clear();
            conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM SUPERVISOR_OFTHESIS INNER JOIN SUPERVISOR ON SUPERVISOR_OFTHESIS.SOT_SUPERVISORID = SUPERVISOR.S_ID INNER JOIN THESIS ON SUPERVISOR_OFTHESIS.SOT_THESISID = THESIS.THESIS_AUTHOR",conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "SUPERVISOR_OFTHESIS INNER JOIN SUPERVISOR ON SUPERVISOR_OFTHESIS.SOT_SUPERVISORID = SUPERVISOR.S_ID INNER JOIN THESIS ON SUPERVISOR_OFTHESIS.SOT_THESISID = THESIS.THESIS_AUTHOR");
            dataGridView1.DataSource = ds.Tables["SUPERVISOR_OFTHESIS INNER JOIN SUPERVISOR ON SUPERVISOR_OFTHESIS.SOT_SUPERVISORID = SUPERVISOR.S_ID INNER JOIN THESIS ON SUPERVISOR_OFTHESIS.SOT_THESISID = THESIS.THESIS_AUTHOR"];
            conn.Close();

        }
    }
}
