using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated_Routine_Generator
{
    class OpenedCourses
    {
        private List<string> courses = new List<string>();

        public OpenedCourses(List<string> crs)
        {
            courses = crs;
        }

        public List<string> getCourses()
        {
            return courses;
        }
    }
}
