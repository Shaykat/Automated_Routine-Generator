using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
//using System.Data.SqlClient;
using System.Data.Sql;

namespace Automated_Routine_Generator
{
    public partial class Pre_Requirement_Search : MetroFramework.Forms.MetroForm
    {
        public Pre_Requirement_Search()
        {
            InitializeComponent();
        }

        private void Pre_Requirement_Search_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DatabaseAccess db = new DatabaseAccess();
            string courseName, prq1 = "", prq2 = "";
            courseName = textBox1.Text;
            Pre_Requirement pq = db.getData(courseName);
            prq1 = pq.PreReq_1;
            prq2 = pq.PreReq_2;
            listBox1.DataSource = null;
            if (prq1 != null)
            {
                listBox1.Items.Add(prq1);
            }
            if (prq2 != null)
            {
                listBox1.Items.Add(prq2);
            }
        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home fm2 = new Home();
            this.Hide();
            fm2.Show();
        }
    }
}
