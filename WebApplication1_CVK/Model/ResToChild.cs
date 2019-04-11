using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1_CVK.Model
{
    public class ResToChild
    {
        public string NumOkrug { set; get; }
        public List<Department> departments { set; get; }

        public ResToChild()
        {
        }
    }
}