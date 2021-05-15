using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NorthwindDBDataContext context = new NorthwindDBDataContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            Table<Product> p=context.Products;
            dataGridView1.DataSource = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IQueryable<FindProductResult> results=context.FindProduct(Convert.ToInt32(textBox1.Text));
            foreach (var item in results)
            {
                MessageBox.Show(item.productid.ToString());
                MessageBox.Show(item.ProductName);
                MessageBox.Show(item.QuantityPerUnit);
                MessageBox.Show(Convert.ToInt32(item.UnitPrice).ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            context.UpdateEmployee(12, "Smita", "Jim");
            context.SubmitChanges();
            MessageBox.Show("done");
        }
    }
}
