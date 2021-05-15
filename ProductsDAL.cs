using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class ProductsDAL
    {
        public bool UpdateProductDataUsingDA(Products p)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=spd\\sqlexpress;Integrated Security=true;database=northwind");
            SqlDataAdapter da = new SqlDataAdapter("select * from products", cn);//adapters can connect/disconnect dynamically
            DataSet ds = new DataSet("nw");//Dataset is In -memory cache
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "products");//u can store multiple objects  in the daataset
                                    //1 type among the objects is table
                                    //Datatable is inside the dataset
                                    //DataTable-- products
            DataRow drow=ds.Tables["products"].Rows.Find(p.ProductID);
            drow[1] = p.ProductName;
            drow[2] = p.SupplierID;
            drow[3] = p.CategoryID;
            drow[4] = p.QtyPerUnit;
            drow[5] = p.UnitPrice;
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(ds.Tables["products"]);
            status = true;
            return status;

        }


            public bool DeleteProductDataUsingDA(int productid)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=spd\\sqlexpress;Integrated Security=true;database=northwind");
            SqlDataAdapter da = new SqlDataAdapter("select * from products", cn);//adapters can connect/disconnect dynamically
            DataSet ds = new DataSet("nw");//Dataset is In -memory cache
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "products");//u can store multiple objects  in the daataset
                                    //1 type among the objects is table
                                    //Datatable is inside the dataset
                                    //DataTable-- products


            ds.Tables["products"].Rows.Find(productid).Delete();

            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(ds.Tables["products"]);
            status = true;
            return status;
        }


            public bool InsertProductDataUsingDA(Products p)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=spd\\sqlexpress;Integrated Security=true;database=northwind");
            SqlDataAdapter da = new SqlDataAdapter("select * from products",cn);//adapters can connect/disconnect dynamically
            DataSet ds = new DataSet("nw");//Dataset is In -memory cache
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "products");//u can store multiple objects  in the daataset
            //1 type among the objects is table
            //Datatable is inside the dataset
            //DataTable-- products
            DataRow row = ds.Tables["products"].NewRow();//blank row
            row["ProductName"] = p.ProductName;
            row["SupplierID"] = p.SupplierID;
            row["CategoryID"] = p.CategoryID;
            row["QuantityPerUnit"] = p.QtyPerUnit;
            row["UnitPrice"] = p.UnitPrice;
            try
            {
                ds.Tables["products"].Rows.Add(row);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Update(ds.Tables["products"]);
                status = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
            return status;
                    
        }

        public List<Products> GetProductsDA()
        {

            SqlConnection cn = new SqlConnection("server=spd\\sqlexpress;Integrated Security=true;database=northwind");
            SqlDataAdapter da = new SqlDataAdapter("select * from products", cn);//adapters can connect/disconnect dynamically
            DataSet ds = new DataSet("nw");//Dataset is In -memory cache
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "products");
            List<Products> products = new List<Products>();
            for (int i = 0; i < ds.Tables["products"].Rows.Count; i++)
            {
                Products p = new Products();
                p.ProductID = Convert.ToInt32(ds.Tables["products"].Rows[i][0]);
                p.ProductName = ds.Tables["products"].Rows[i][1].ToString();
                p.SupplierID= Convert.ToInt32(ds.Tables["products"].Rows[i][2]);
                p.CategoryID= Convert.ToInt32(ds.Tables["products"].Rows[i][3]);
                p.QtyPerUnit = ds.Tables["products"].Rows[i][4].ToString();
                p.UnitPrice = Convert.ToDouble(ds.Tables["products"].Rows[i][5]);

                products.Add(p);
            }
            return products;

        }

    }
}
