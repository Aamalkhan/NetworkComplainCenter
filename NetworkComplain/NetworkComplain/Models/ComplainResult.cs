using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkComplain.Models
{
    public class ComplainResult
    {
        public List<Complain> complains { get; set; }

        public int CurrentPage { get; set; }

        public int TotalComplain { get; set; }

        public int PageSize { get; set; }

    }
}