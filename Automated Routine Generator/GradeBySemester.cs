using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Routine_Generator
{
    class Gradebysem
    {

        private string gcourseid;  //eida foreign key hoibo curriculam er id onujayi rhkte hbe
        private string gcoursename;
        private string midtermgrade;
        private string finaltermgrade;

        //constructor
        public Gradebysem(string gcourseid, string gcoursename, string midtermgrade, string finaltermgrade)
        {
            this.gcourseid = gcourseid;
            this.gcoursename = gcoursename;
            this.midtermgrade = midtermgrade;
            this.finaltermgrade = finaltermgrade;
        }

        public Gradebysem()
        {
            // TODO: Complete member initialization
        }

        /// <summary>
        /// propirties
        /// </summary>
        /// 
        public string Gcourseid
        {
            get { return gcourseid; }
            set { gcourseid = value; }
        }

        public string Gcoursename
        {
            get { return gcoursename; }
            set { gcoursename = value; }
        }

        public string Midtermgrade
        {
            get { return midtermgrade; }
            set { midtermgrade = value; }
        }

        public string Finaltermgrade
        {
            get { return finaltermgrade; }
            set { finaltermgrade = value; }
        }
    }

}
