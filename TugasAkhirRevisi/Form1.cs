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
    public partial class Form1 : Form
    {
        private string stringConnection = "data source= HP; " + "database=TugasAkhir; User ID=sa; Password=123";
        private SqlConnection connection;
        private string nama, jenis, harga, stok;
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection(stringConnection);
            refreshform();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void start_Click_1(object sender, EventArgs e)
        {
            txtNama.Enabled = true;
            txtHarga.Enabled = true;
            txtStok.Enabled = true;
            txtJenis.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            refreshform();
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJenis_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHarga_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStok_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datagridvied()
        {
            connection.Open();
            string str = "select * from dbo.produk";
            SqlDataAdapter adapter = new SqlDataAdapter(str, connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            datagridvied();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtNama.Text = row.Cells["nama_produk"].Value.ToString();
                txtJenis.Text = row.Cells["jenis_produk"].Value.ToString();
                txtHarga.Text = row.Cells["harga_produk"].Value.ToString();
                txtStok.Text = row.Cells["stok"].Value.ToString();
                
            }
            catch (Exception X) 
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connection.Open();
            string QueryString = "Update dbo.produk set nama_produk'" + txtNama.Text + "', jenis_produk'" + txtJenis.Text + "', harga_produk ='" + txtHarga.Text + "' stok ='" + "'";
            SqlCommand cmd = new SqlCommand(QueryString, connection);
            cmd.CommandType = CommandType.Text; 
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Update data berhasil");
            datagridvied();
            refreshform();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus data : " + txtNama.Text + "?","Konfirmasi",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                connection.Open();
                string QueryString = "Delete dbo.produk where nama_produk ='" + txtNama.Text + "'";
                SqlCommand cmd = new SqlCommand(QueryString, connection);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Hapus data berhasil");
                datagridvied();
                refreshform();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            nama = txtNama.Text;
            jenis = txtJenis.Text;
            harga = txtHarga.Text;
            stok = txtStok.Text;
            connection.Open();
            string strs = "insert into dbo.produk (nama_produk,jenis_produk,harga_produk,stok)" +
                "values(@nama_produk,@jenis_produk,@harga_produk,@stok)";
            SqlCommand cmd = new SqlCommand(strs, connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("nama_produk", nama));
            cmd.Parameters.Add(new SqlParameter("jenis_produk", jenis));
            cmd.Parameters.Add(new SqlParameter("harga_produk", harga));
            cmd.Parameters.Add(new SqlParameter("stok", stok));
            cmd.ExecuteNonQuery();

            connection.Close();

            MessageBox.Show("Data Berhasil di simpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refreshform();
        }

        private void refreshform()
        {
            txtNama.Text = "";
            txtJenis.Text = "";
            txtHarga.Text = "";
            txtStok.Text = "";
            txtNama.Enabled = false;
            txtJenis.Enabled = false;
            txtHarga.Enabled = false;
            txtStok.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
    }
}
