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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //deklarasi variable dsMhs dengan tipe dataset
         private DataSet ds_Mhs;

        public DataSet CreateMhsDataSet()
        {
            DataSet myDataSet = new DataSet();

            try
            {
                
                SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-R03IJG5\BRYAN;Initial Catalog=UAS;Integrated Security=True");



                SqlCommand myCommand = new SqlCommand();

                
                myCommand.Connection = myConnection;

                
                myCommand.CommandText = "SELECT * FROM tb_mahasiswa";
                myCommand.CommandType = CommandType.Text;

                
                SqlDataAdapter myDataAdapter = new SqlDataAdapter();
                myDataAdapter.SelectCommand = myCommand;
                myDataAdapter.TableMappings.Add("Table", "Mahasiswa");

                
                myDataAdapter.Fill(myDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return myDataSet;
        }

        private void RefreshDataSet()
        {
           
            ds_Mhs = CreateMhsDataSet();
            
            dgMhs.DataSource = ds_Mhs.Tables["Mahasiswa"];
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataSet();
        }
    }
}
