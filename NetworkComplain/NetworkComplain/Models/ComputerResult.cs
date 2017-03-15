using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkComplain.Models
{
    public class ComputerResult
    {

        public List<Computer> computers { get; set; }

        public int CurrentPage { get; set; }

        public int TotalComputer { get; set; }

        public int PageSize { get; set; }

    }
}