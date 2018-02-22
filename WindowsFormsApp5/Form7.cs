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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server =.;Database = termproject;Trusted_Connection = True;");

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *FROM SUBJECT_OFTHESIS", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "SUBJECT_OFTHESIS");
            dataGridView1.DataSource = ds.Tables["SUBJECT_OFTHESIS"];
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO SUBJECT_OFTHESIS(SOT_ID,SOT_THESISID,SOT_SUBJECTID)VALUES(@id,@thesisid,@subjectid)", conn);
            komut.Parameters.AddWithValue("@id", textBox1.Text);
            komut.Parameters.AddWithValue("@thesisid", textBox2.Text);
            komut.Parameters.AddWithValue("@subjectid", textBox3.Text);

            komut.ExecuteNonQuery();

            conn.Close();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM SUBJECT_OFTHESIS WHERE SOT_ID = @id", conn);
            komut.Parameters.AddWithValue("@id", textBox4.Text);
            komut.ExecuteNonQuery();
            conn.Close();
            textBox4.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM SUBJECT_OFTHESIS INNER JOIN SUBJECT ON SUBJECT_OFTHESIS.SOT_SUBJECTID = SUBJECT.SUB_ID INNER JOIN THESIS ON THESIS.THESIS_ID = SUBJECT_OFTHESIS.SOT_THESISID", conn);
            DataSet ds = new DataSet();

            adapter.Fill(ds, "SUBJECT_OFTHESIS INNER JOIN SUBJECT ON SUBJECT_OFTHESIS.SOT_SUBJECTID = SUBJECT.SUB_ID INNER JOIN THESIS ON THESIS.THESIS_ID = SUBJECT_OFTHESIS.SOT_THESISID");
            dataGridView1.DataSource = ds.Tables["SUBJECT_OFTHESIS INNER JOIN SUBJECT ON SUBJECT_OFTHESIS.SOT_SUBJECTID = SUBJECT.SUB_ID INNER JOIN THESIS ON THESIS.THESIS_ID = SUBJECT_OFTHESIS.SOT_THESISID"];
            conn.Close();


        }

    }
}
