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
using System.Data.SqlClient;

namespace Automated_Routine_Generator
{
    public partial class Sign_Up : MetroFramework.Forms.MetroForm
    {
        public Sign_Up()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox6_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DatabaseAccess db = new DatabaseAccess();
            Log_In fm1 = new Log_In();
            string userName, firstName, lastName, email, password, cpassword;
            userName = metroTextBox1.Text;
            firstName = metroTextBox2.Text;
            lastName = metroTextBox3.Text;
            email = metroTextBox4.Text;
            password = metroTextBox5.Text;
            cpassword = metroTextBox6.Text;
            if (password != cpassword)
            {
                MessageBox.Show("Please Insert Correct password");
                this.Refresh();
            }
            else
            {
                db.insert_Item(userName, firstName, lastName, email, password);
                this.Hide();
                fm1.Show();
            }
            //FROM CLOSE
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log_In fm1 = new Log_In();
            this.Hide();
            fm1.Show();
        }
    }
}
