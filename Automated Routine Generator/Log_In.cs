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
    public partial class Log_In : MetroFramework.Forms.MetroForm
    {
        public Log_In()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string userName, password;
            userName = TextBox1.Text;
            password = TextBox2.Text;
            DatabaseAccess db = new DatabaseAccess();
            if (db.logIn(userName,password))
            {
                MessageBox.Show("Login Successful");
                Home fm3 = new Home();
                fm3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Log In");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Sign_Up fm2 = new Sign_Up();
            fm2.Show();
            this.Hide();
        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
