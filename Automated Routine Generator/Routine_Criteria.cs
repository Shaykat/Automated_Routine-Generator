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
using HtmlAgilityPack;

namespace Automated_Routine_Generator
{
    public partial class Routine_Criteria : MetroFramework.Forms.MetroForm
    {

        public Routine_Criteria()
        {
            InitializeComponent();
            dynamicCheckBox();
            disable();
            //groupBox4.Hide();
            //groupBox5.Hide();

        }

        public void disable()
        {
            groupBox4.Hide();
            groupBox1.Hide();
        }
        public void dynamicCheckBox()
        {
            DatabaseAccess db = new DatabaseAccess();
            OpenedCourses opc = db.openedCourses();
            CheckBox chk;
            List<string> lt = opc.getCourses();
            int p = lt.Count;
            //MessageBox.Show(p.ToString());
            for (int i = 0; i < p; i++)
            {
                chk = new CheckBox();
                chk.Name = "checkBox" + Convert.ToString(i);
                chk.Text = lt[i];
                chk.AutoSize = true;
                chk.Location = new Point(30, i * 20);
                checkedListBox1.Controls.Add(chk);
            }
        }

        private void Routine_Criteria_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            disable();
            groupBox4.Show();
        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

            disable();
            groupBox1.Show();
        }

        private void metroComboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroComboBox1.Items.Add("");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void metroComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home fm3 = new Home();
            this.Hide();
            fm3.Show();
        }

    }
}
