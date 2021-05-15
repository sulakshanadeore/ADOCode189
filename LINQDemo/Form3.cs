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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            List<Student> students = new List<Student>() {
                new Student{Rollno=1,Name="Anand",Age=10},
                new Student{Rollno=3,Name="Ramesh",Age=11 },
                new Student{Rollno=2,Name="Suresh",Age=12},
                new Student{Rollno=4,Name="Ganesh",Age=12},
                new Student{Rollno=6,Name="Harish",Age=12},
                new Student{Rollno=5,Name="Ameya",Age=11}
                };


            var groupedData = from s in students
                              group s by s.Age;

            foreach (var item in groupedData)
            {
                listBox1.Items.Add("Age Group= " + item.Key);
                foreach (var studs in item)
                {
                    listBox1.Items.Add(studs.Name + "  " + studs.Rollno + " " + studs.Age);
                }
                listBox1.Items.Add("**************");
            }

            //Method Syntax
            var data = students.GroupBy(s => s.Age);

            foreach (var item in groupedData)
            {
                listBox2.Items.Add("Age Group= " + item.Key);
                foreach (var studs in item)
                {
                    listBox2.Items.Add(studs.Name + "  " + studs.Rollno + " " + studs.Age);
                }
                listBox2.Items.Add("**************");
            }



            var data1 = students.ToLookup(s => s.Age);
            foreach (var item in groupedData)
            {
                listBox3.Items.Add("Age Group= " + item.Key);
                foreach (var studs in item)
                {
                    listBox3.Items.Add(studs.Name + "  " + studs.Rollno + " " + studs.Age);
                }
                listBox3.Items.Add("**************");
            }



        }
    }
}
