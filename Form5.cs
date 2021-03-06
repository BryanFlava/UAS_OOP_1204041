using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS_OOP_1204041
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private SqlConnection conn;
        private SqlCommand cmd1;
        private SqlDataAdapter DataAdapter;
        private DataSet DataSet;

        private void Form5_Load(object sender, EventArgs e)
        {
            string constr = @"Data Source=DESKTO-R03IJG5\BRYAN;Initial Catalog=UAS;Integrated Security=True";
            conn = new SqlConnection(constr);
            conn.Open();
            cmd1 = new SqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "SELECT * FROM ms_prodi_mhs";
            DataSet = new DataSet();
            DataAdapter = new SqlDataAdapter(cmd1);
            DataAdapter.Fill(DataSet, "ms_prodi_mhs");
            dgProdi.DataSource = DataSet;
            dgProdi.DataMember = "ms_prodi_mhs";
            dgProdi.Refresh();
            conn.Close();
        }
    }
}
