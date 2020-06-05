using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSysApi.Models
{
    public class Question
    {
        public long Id { get; set; }

        public string question { get; set; }

        public string answer1 { get; set; }

        public string answer2 { get; set; }

        public string answer3 { get; set; }

        public string answer4 { get; set; }

        public Int32 true_answer { get; set; }
    }
}
