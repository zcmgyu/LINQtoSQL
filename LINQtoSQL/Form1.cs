using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQtoSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new DatabaseDataContext();
            var cate = new Category();
            cate.CategoryName = textBox1.Text;
            db.Categories.InsertOnSubmit(cate);
            db.SubmitChanges();
            MessageBox.Show("Saved");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var db = new DatabaseDataContext();
            var query = from c in db.Categories
                        select c;

            comboBox1.DataSource = query.ToList();
            comboBox1.DisplayMember = "CategoryName";
        }
    }
}
