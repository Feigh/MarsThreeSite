using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsThreeSite.Models
{
    public class NavigationModel
    {
        public class PageNavigation
        {
            public string FirstPage { get; set; }
            public string PreviousPage { get; set; }
            public string NextPage { get; set; }
            public string LastPage { get; set; }
        }
    }
}
