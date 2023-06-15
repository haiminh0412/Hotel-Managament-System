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
using Microsoft.Reporting.WinForms;

namespace Hotel_Management_System_Winforrm
{
    public partial class InHoaDon : Form
    {
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;
        private string tenphong;
        public InHoaDon(string tenphong)
        {
            InitializeComponent();
            this.tenphong = tenphong;
        }

        private void InHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = Connection.getConnection();
                sqlConnection.Open();
                string query = "select top 1 * from traphong where phong = '" + tenphong + "'";
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "traphong");
                this.rpvInHoaDon.LocalReport.ReportEmbeddedResource = "Hotel_Management_System_Winforrm.Report1.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = dataSet.Tables["traphong"];
                this.rpvInHoaDon.LocalReport.DataSources.Add(reportDataSource);
                this.rpvInHoaDon.RefreshReport();
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
          
        }
    }
}
