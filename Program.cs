using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFirstLibrary;
using System.Data.Entity;
namespace EFDemo_DBFirst
{
    class Program
    {
        static void Main(string[] args)
        {

            //Insert
            //Category c = new Category();
            //c.CategoryName = "Breakfast";
            //c.Description = "Breakfast Items";
            //NorthwindEntities entities = new NorthwindEntities();
            //entities.Categories.Add(c);
            //entities.SaveChanges();


            //Update
            //Category c = new Category();
            //c.Description = "Idli,Coffee";
            //NorthwindEntities entities = new NorthwindEntities();
            //Category founddata=entities.Categories.Find(18);
            //founddata.Description = c.Description;
            //entities.SaveChanges();

            //Show all
            //NorthwindEntities entities = new NorthwindEntities();
            //DbSet<Category> categorieslist=entities.Categories;

            //foreach (var item in categorieslist)
            //{
            //    Console.WriteLine(item.CategoryID);
            //    Console.WriteLine(item.CategoryName);
            //    Console.WriteLine(item.Description);
            //}

            //Delete

            NorthwindEntities entities = new NorthwindEntities();
            Category founddata = entities.Categories.Find(18);
            entities.Categories.Remove(founddata);
            entities.SaveChanges();
            Console.WriteLine("Deleted");

            Console.Read();

        }
    }
}
