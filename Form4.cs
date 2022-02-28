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
namespace UAS_OOP_1204041
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        //membuat method updateDB dengan parameter cmd
        private void UpdateDB(string cmd)
        {
            //exception handler
            try
            {
                //connection untuk koneksi ke basisdata P6_1204049
                SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-R03IJG5\BRYAN;Initial Catalog=UAS;Integrated Security=True");

                //membuka koneksi, menggunakan object myConnection
                myConnection.Open();

                //membuat objek dengan nama myCommand, inisialisasi dari class sqlCommand
                SqlCommand myCommand = new SqlCommand();

                //menetapkan koneksi basisdata yang digunakan yaitu object myConnection
                myCommand.Connection = myConnection;

                //mengatur query yang digunakan, diambil dari parameter cmd
                myCommand.CommandText = cmd;

                //eksekusi myCommand yang diambil dari parameter cmd
                myCommand.ExecuteNonQuery();

                //menampilkan pesan jika eksekusi berhasil
                MessageBox.Show("Data Berhasil Disubmit !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //penanganan apabila terjadi error pada saat try, exception diset dalam variabel ex
            catch (Exception ex)
            {
                //menampilkan pesan kesalahan
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void clear()
        {
            txtKodeProdi.Text = "";
            txtNamaProdi.Text = "";
            txtSingkatan.Text = "";
            txtBiayaKuliah.Text = "";
        }
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            string myCmd = "INSERT INTO ms_prodi_mhs VALUES('"
         + txtKodeProdi.Text + "','"
         + txtNamaProdi.Text + "','"
         + txtSingkatan.Text + "','"
         + txtBiayaKuliah.Text + "')";


            UpdateDB(myCmd);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
