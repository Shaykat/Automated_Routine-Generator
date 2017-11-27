using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using HtmlAgilityPack;
using System.Windows.Forms;

namespace Automated_Routine_Generator
{
    class DatabaseAccess
    {
        private SqlCeConnection con;
        public DatabaseAccess()
        {
            con = new SqlCeConnection(@"Data Source=C:\Users\student\Desktop\Automated Routine Generator\Automated Routine Generator\Database1.sdf");
            con.Open();
        }

        public DatabaseAccess(string con_String)
        {
            SqlCeConnection con = new SqlCeConnection(@con_String);
            con.Open();
        }

        public void insert_Item(string userName, string firstName, string lastName, string email, string password)
        {
            string sn = "INSERT INTO Register(User_Name,First_Name,Last_Name,Email,Password) VALUES(@userName,@firstName,@lastName,@email,@password)";
            SqlCeCommand cmd = new SqlCeCommand(sn, con);
            cmd.Parameters.AddWithValue("@userName", userName);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Pre_Requirement getData(string courseName)
        {
            string prq1 = "", prq2 = "";
            string sn = "SELECT Pre_Requirement_1,Pre_Requirement_2 FROM Curriculum WHERE Course_Name='" + courseName + "'";
            SqlCeCommand cmd = new SqlCeCommand(sn, con);
            SqlCeDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                prq1 = rdr["Pre_Requirement_1"].ToString();
                prq2 = rdr["Pre_Requirement_2"].ToString();
            }
            con.Close();
            Pre_Requirement pq = new Pre_Requirement(prq1,prq2);
            return pq;
        }

        public OpenedCourses openedCourses()
        {
            string courseName, status, prerq;
            List<string> lt = new List<string>();

            string sn = "SELECT Course_Name,Pre_Requirement_1 FROM Curriculum";
            SqlCeCommand cmd = new SqlCeCommand(sn, con);
            SqlCeDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                courseName = rdr["Course_Name"].ToString().Trim();
                prerq = rdr["Pre_Requirement_1"].ToString().Trim();

                string pn = "SELECT Status FROM Grade_By_Semester WHERE Course_Name='" + prerq + "'";
                SqlCeCommand pmd = new SqlCeCommand(pn, con);
                SqlCeDataReader pdr = pmd.ExecuteReader();
                

                while (pdr.Read())
                {
                    //ListView.Checkboxes = true;
                    status = pdr["Status"].ToString().Trim();
                    if (status == "YES")
                    {
                        lt.Add(courseName);
                    }

                }
            }
            OpenedCourses opc = new OpenedCourses(lt);

            con.Close();
            return opc;
        }

        public bool logIn(string userName,string password)
        {
            string sn = "SELECT User_Name,Password FROM Register WHERE User_Name='" + userName + "' and Password='" + password + "'";
            SqlCeCommand cmd = new SqlCeCommand(sn, con);
            SqlCeDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                MessageBox.Show("Incorrect login");
                return false;
            }
        }


    }
}
