using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Routine_Generator
{
    class Pre_Requirement
    {
        private string preReq_1;
        private string preReq_2;

        public string PreReq_1
        {
            get { return preReq_1; }
            set { preReq_1 = value; }
        }

        public string PreReq_2
        {
            get { return preReq_2; }
            set { preReq_2 = value; }
        }
       

        public Pre_Requirement(string p,string q)
        {
            preReq_1 = p;
            preReq_2 = q;
        }
    }
}
