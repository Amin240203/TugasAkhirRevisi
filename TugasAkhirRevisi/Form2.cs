using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasAkhir
{
    public partial class Form2 : Form
    {
        private string stringConnection = "data source= HP; " + "database=TugasAkhir; User ID=sa; Password=123";
        private SqlConnection connection;
        private string username,nama, alamat;
        public Form2()
        {
            connection = new SqlConnection(stringConnection);
            refreshform();
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void refreshform()
        {
            
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            txtNama.Enabled=true;
            txtUsername.Enabled=true;
            txtAlamat.Enabled=true;
            button1.Enabled=true;
            button2.Enabled=true;
            button3.Enabled=true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            nama = txtNama.Text;
            alamat = txtAlamat.Text;

            connection.Open();
            string strs = "insert into dbo.pembeli (username_pem,nama_pem,alamat)" +
                "values(@username_pem,@nama_pem,@alamat)";
            SqlCommand cmd = new SqlCommand(strs, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("username_pem", username));
            cmd.Parameters.Add(new SqlParameter("nama_pem", nama));
            cmd.Parameters.Add(new SqlParameter("alamat", alamat)); 
            cmd.ExecuteNonQuery();

            connection.Close();

            MessageBox.Show("Data Berhasil di simpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshform();
        }   
    }
}
