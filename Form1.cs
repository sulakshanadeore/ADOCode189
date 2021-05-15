using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using DAL;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProductsDAL dal = new ProductsDAL();
            DataView dt = dal.filterDataUsingDataView();
            dataGridView1.DataSource = dt;
            bool foundstatus=dal.SearchDataUsingDataView("Ernst Handeler");
            if (foundstatus)
            {
                MessageBox.Show("Found");
            }
            else
            {
                MessageBox.Show("Not found");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductsDAL dal = new ProductsDAL();
            DataView dv=dal.DataViewFilterContactName("Maria Anders");
            dataGridView2.DataSource = dv;

        }
    }
}
