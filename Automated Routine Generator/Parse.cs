using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;


//super parse class
namespace Automated_Routine_Generator
{
    class parse
    {

        //variables
        private string xPath;
        private HtmlDocument document;

        //constructor
        public parse() { }

        //properties
        public string Xpath
        {
            get { return xPath; }
            set { xPath = value; }
        }


        public HtmlDocument Document
        {
            get { return document; }
            set { document = value; }
        }

        //virtual method
        public virtual void parsefile(HtmlDocument doc, string xpath, int chk)
        {
            //do nothing
        }

        //public virtual void getgradedetails();



    }
}
