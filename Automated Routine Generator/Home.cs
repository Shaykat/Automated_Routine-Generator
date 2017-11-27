using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automated_Routine_Generator
{
    public partial class Home : MetroFramework.Forms.MetroForm
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pre_Requirement_Search fm4 = new Pre_Requirement_Search();
            fm4.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Routine_Criteria fm5 = new Routine_Criteria();
            fm5.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Log_In fm1 = new Log_In();
            this.Hide();
            fm1.Show();
        }
    }
}
