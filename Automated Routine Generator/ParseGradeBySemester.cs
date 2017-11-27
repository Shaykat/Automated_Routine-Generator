using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using HtmlAgilityPack;

namespace Automated_Routine_Generator
{
    class Parsegradebysem : parse
    {
        //variables
        private List<Gradebysem> gbsl = new List<Gradebysem>();

        //constructor
        public Parsegradebysem() { }

        //methods
        //colelcting grade by sem html and creating xpath
        public void getgradedetails()
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            //*[@id="main-content"]/div/fieldset/div/table[1]
            htmlDoc.Load("bySemester.html");



            //create x path for course name
            Xpath = "//*[@id=\"main-content\"]/div/fieldset/div/table[2]/tbody/tr[position()>0]/td[2]";
            //parsecoursename(htmlDoc ,xpath1);
            this.parsefile(htmlDoc, Xpath, 1);


            //for midterm grade
            Xpath = "//*[@id=\"main-content\"]/div/fieldset/div/table[2]/tbody/tr[position()>0]/td[4]";
            //parsemidgrade(htmlDoc, xpath2);
            this.parsefile(htmlDoc, Xpath, 2);

            //for final grade
            Xpath = "//*[@id=\"main-content\"]/div/fieldset/div/table[2]/tbody/tr[position()>0]/td[6]";
            //parsefinalgrade(htmlDoc, xpath3);
            this.parsefile(htmlDoc, Xpath, 3);
        }

        //show gradeinfo
        public void insertgradeinfo()
        {
            SqlCeConnection con = new SqlCeConnection(@"Data Source=C:\Users\Shaykat\Google Drive\C#\Project\Automated Routine Generator\Automated Routine Generator\Database1.sdf");
            string  courseName, status, midGrade,finalGrade;
            int courseId = 1;
            con.Open();
            //Console.WriteLine("sz " + gbsl.Count);

            foreach (Gradebysem g in gbsl)
            {
                //courseId = g.Gcourseid.Trim();
                courseName = g.Gcoursename.Trim();
                midGrade = g.Midtermgrade.Trim();
                finalGrade = g.Finaltermgrade.Trim();

                if (finalGrade != null) {
                    if (finalGrade == "W" || finalGrade == "F")
                    {
                        status = "NO";
                    }
                    else
                    {
                        status = "YES";
                    }
                }
                else
                {
                    if (midGrade == "W" || midGrade == "F")
                    {
                        status = "NO";
                    }
                    else
                    {
                        status = "YES";
                    }
                }
                string sn = "INSERT INTO Grade_By_Semester(Course_Id,Course_Name,Status) VALUES(@courseId,@courseName,@status)";
                SqlCeCommand cmd = new SqlCeCommand(sn, con);
                cmd.Parameters.AddWithValue("@courseId", courseId);
                cmd.Parameters.AddWithValue("@courseName", courseName);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
                courseId++;
            }
            con.Close();
        }


        //overridden  parse file 

        public override void parsefile(HtmlDocument doc, string xpath, int chk)
        {
            //base.parsefile(doc, xpath, chk);
            int cnt = 0;
            foreach (var a in doc.DocumentNode.SelectNodes(xpath))
            {
                string whole = "";
                foreach (var b in a.ChildNodes)
                {
                    string line = b.InnerText;
                    if (line != null && !line.Contains("\n"))
                    {
                        whole += line;

                        if (chk == 1)
                        {

                            if (whole[0] >= 'A' && whole[0] <= 'Z' && whole != "Description")
                            {
                                whole = whole.Replace("amp;", "");
                                //Console.WriteLine(whole);
                                //coursename.Add(whole);
                                Gradebysem gbs = new Gradebysem("0", whole, "", "");  //curriculam er id onujayi course id set kora lagbo

                                //ei jaigai curriculam onujaiyi courseid set kora lgbo
                                gbsl.Add(gbs);

                            }
                        }
                        if (chk == 2)
                        {
                            if (whole != "MTG" && (whole[0] >= 'A' && whole[0] <= 'Z' || whole[0] == '-'))
                            {
                                //whole = whole.Replace("amp;", "");
                                // Console.WriteLine(whole);
                                // midgrade.Add(whole);
                                gbsl[cnt].Midtermgrade = whole;
                                cnt++;

                            }
                        }
                        else if (chk == 3)
                        {

                            if ((whole != "FG" && (whole[0] >= 'A' && whole[0] <= 'Z') || whole[0] == '-'))
                            {
                                //whole = whole.Replace("amp;", "");
                                // Console.WriteLine(whole);
                                //finalgrade.Add(whole);
                                gbsl[cnt].Finaltermgrade = whole;
                                cnt++;
                            }
                        }
                    }
                }
            }
        }


    }


}
