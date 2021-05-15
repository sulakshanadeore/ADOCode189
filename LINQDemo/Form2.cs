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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int[] arr = new int[] {12,34,2,45,11,453,324 };
            //Query Syntax
            var o = from a in arr
                    where a%2!=0
                    select a;
            foreach (var item in o)
            {
                listBox1.Items.Add(item);
            }
            //----------------------------------
            //Method Syntax
            var o1 = arr.Where(a => a % 2 != 0);
            listBox1.Items.Add("--------------------");
            foreach (var item in o1)
            {
                listBox1.Items.Add(item);
            }


            //------------------------------------
            List<Products> products = new List<Products>();
            products.Add(new Products { ProductID = 5, Price = 10, Name = "Chai" });
            products.Add(new Products { ProductID = 1, Price = 15, Name = "Chai" });
            products.Add(new Products { ProductID = 3, Price = 12, Name = "Horlicks" });
            products.Add(new Products { ProductID = 2, Price = 21, Name = "Complan" });
            products.Add(new Products { ProductID = 4, Price = 20, Name = "Milk" });

            var productsbelow20 = from p in products
                                  where p.Price < 20
                                  select p;
            //Defferred Execution----- the query output is not generated when the query variable is declared instead the query is executed when the query variable is iterated


            products.Add(new Products { ProductID = 6, Price = 10, Name = "Tea" });

            //  var productsbelow20 = products.Where(p => p.Price < 20);
            foreach (var item in productsbelow20)
            {
                listBox2.Items.Add(item.ProductID + " " + item.Name + " " + item.Price);
            }


            //var products20 = from p in products
            //                 where p.Price < 20
            //                 select new {p.ProductID,p.Name };

            var products20 = (products.Where(p => p.Price < 20).Select(p=>p.Name).ToList()).Count;
            //Immediate Execution----- the query output is generated at the place where query variable is created and doesnot require iteration.
            //tolist,toarray,todictionary
            //IEnumerable--immediate & IQueryable---deferred



            MessageBox.Show("Products 20  =" + products20);
            products.Add(new Products {ProductID=10,Price=15,Name="Chips" });
            MessageBox.Show("Products 20  =" + products20);
            //foreach (var item in products20)
            //{
            //    listBox3.Items.Add(item);
            //}


            var plist = products.Where(p => p.Price < 20).Select(pdata => new
            {
                prodname = pdata.Name,
                pprice = pdata.Price,
                pid = pdata.ProductID
            });

            foreach (var item in plist)
            {
                listBox4.Items.Add(item.pid + " " + item.prodname + " " + item.pprice);
            }
            var findproduct =products.Where(p => p.Name == "Milk").Select(p=>p.ProductID).SingleOrDefault();


            //var findproduct = products.Where(p => p.Name == "Chai").Select(p => p.Price).LastOrDefault();
            MessageBox.Show(findproduct.ToString());

            var idOrder = from p in products
                          orderby p.ProductID
                          select p;
            listBox1.Items.Add("-----");

            foreach (var item in idOrder)
            {
                listBox1.Items.Add(item.ProductID + " " + item.Name + " " + item.Price);
            }

            var orderByProductID = products.OrderBy(p => p.ProductID);
            listBox2.Items.Add("----Ordered Data---");
            foreach (var item in orderByProductID)
            {
                listBox2.Items.Add(item.ProductID + " " + item.Name + " " + item.Price);
            }




        }
    }
}
