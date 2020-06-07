using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSysApi.Models
{
    public class Worker
    {
        public long Id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public bool did_test { get; set; }
        public bool pass_test { get; set; }

    }
}
