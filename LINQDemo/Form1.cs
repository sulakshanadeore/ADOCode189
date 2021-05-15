using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet1.ProductsDataTable dt = new DataSet1.ProductsDataTable();
            DataSet1TableAdapters.ProductsTableAdapter da = new DataSet1TableAdapters.ProductsTableAdapter();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet1.ProductsDataTable dt = new DataSet1.ProductsDataTable();
            DataSet1TableAdapters.ProductsTableAdapter da = new DataSet1TableAdapters.ProductsTableAdapter();
            da.FillByProductID(dt, 1);
            DataTable dt1=da.GetDataByProductID(1);
           string prodname = dt1.Rows[0][1].ToString();
            string prodprice = dt1.Rows[0]["UnitPrice"].ToString();
            MessageBox.Show(prodname);
            MessageBox.Show(prodprice);

        }
    }
}
