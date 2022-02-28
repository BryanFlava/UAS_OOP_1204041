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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        //membuat method updateDB dengan parameter cmd
        private void UpdateDB(string cmd)
        {
            try
            {

                SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTO-R03IJG5\BRYAN;Initial Catalog=UAS;Integrated Security=True");

                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();

                myCommand.Connection = myConnection;

                myCommand.CommandText = cmd;

                myCommand.ExecuteNonQuery();

                MessageBox.Show("Data Berhasil Disubmit !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void clear()
        {
            txtNPM.Text = "";
            txtNamaMhs.Text = "";
            txtProdi.Text = "";
            txtBikul.Text = "";
            rbA.Checked = false;
            rbB.Checked = false;
            rbC.Checked = false;
            txtPotBiaya.Text = "";
            txtTotal.Text = "";

        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (txtNPM.Text != "")
            {
                if (rbA.Checked != false || rbB.Checked != false || rbC.Checked != false)
                {
                    string grade = "";
                    if (rbA.Checked)
                    {
                        grade = "A";
                    }
                    if (rbB.Checked)
                    {
                        grade = "B";
                    }
                    if (rbC.Checked)
                    {
                        grade = "C";
                    }

                    string cmd = "INSERT INTO tr_daftar_ulang VALUES ('"
                       + txtNPM.Text + "','"
                       + grade + "','"
                       + txtTotal.Text + "')";

                    UpdateDB(cmd);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Grade Seleksi harus dipilih !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("NPM harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string getSql = "SELECT nama_mhs,nama_prodi,biaya_kuliah FROM ms_mhs " +
               "JOIN ms_prodi ON ms_mhs.kode_prodi=ms_prodi.kode_prodi WHERE npm='" + txtNPM.Text + "'";

            string connection = @"Data Source=DESKTO-R03IJG5\BRYAN;Initial Catalog=UAS;Integrated Security=True";
            SqlConnection myConnection = new SqlConnection(connection);
            myConnection.Open();
            SqlCommand sc = new SqlCommand(getSql, myConnection);
            SqlDataReader Result;

            Result = sc.ExecuteReader();
            if (Result.HasRows)
            {
                while (Result.Read())
                {
                    txtNamaMhs.Text = Result["nama_mhs"].ToString();
                    txtProdi.Text = Result["nama_prodi"].ToString();
                    txtBikul.Text = Result["biaya_kuliah"].ToString();
                }
            }

        }

        private void rbA_CheckedChanged(object sender, EventArgs e)
        {
            int diskon = (Int32.Parse(txtBikul.Text.ToString()) * 50) / 100;
            txtPotBiaya.Text = diskon.ToString();
            int totalbiaya = Int32.Parse(txtBikul.Text.ToString()) - diskon;
            txtBikul.Text = totalbiaya.ToString();
        }

        private void rbB_CheckedChanged(object sender, EventArgs e)
        {
            int diskon = (Int32.Parse(txtBikul.Text.ToString()) * 25) / 100;
            txtPotBiaya.Text = diskon.ToString();
            int totalbiaya = Int32.Parse(txtBikul.Text.ToString()) - diskon;
            txtBikul.Text = totalbiaya.ToString();
        }

        private void rbC_CheckedChanged(object sender, EventArgs e)
        {
            int diskon = (Int32.Parse(txtBikul.Text.ToString()) * 10) / 100;
            txtPotBiaya.Text = diskon.ToString();
            int totalbiaya = Int32.Parse(txtBikul.Text.ToString()) - diskon;
            txtBikul.Text = totalbiaya.ToString();
        }
    }
}
     

