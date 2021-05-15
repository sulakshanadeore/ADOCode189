using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        NorthwindDBDataContext context = new NorthwindDBDataContext();

        private void Form2_Load(object sender, EventArgs e)
        {
            Table<Product> p = context.Products;
            dataGridView1.DataSource = p;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.ProductName = "Cold Drinks";
            p.UnitPrice = 30;
            p.SupplierID = 1;
            p.CategoryID = 1;
            p.QuantityPerUnit = "1";
            context.Products.InsertOnSubmit(p);
            context.SubmitChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(TxtPid.Text);
            Product proddata=context.Products.Where(p => p.ProductID == id).SingleOrDefault();
            proddata.ProductName = "Coke";
            context.SubmitChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtPid.Text);
            Product proddata = context.Products.Where(p => p.ProductID == id).SingleOrDefault();
            context.Products.DeleteOnSubmit(proddata);
            context.SubmitChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtPid.Text);
            Product proddata = context.Products.Where(p => p.ProductID == id).SingleOrDefault();
            MessageBox.Show("Found the product with follwoing details: " + proddata.ProductName + " " + proddata.UnitPrice);
        }
    }
}
