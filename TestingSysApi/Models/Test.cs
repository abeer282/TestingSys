using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingSysApi.Models
{
    public class Test
    {
        public long Id { get; set; }

        public int number_of_questions { get; set; }

        public bool is_choice_random { get; set; }

        public string questions {get; set; }

        public int pass_questions_number { get; set; }

        public bool has_time { get; set; }

        public int time_in_seconds { get; set; }

        public bool can_review { get; set; }

        public int time_of_review { get; set; }

        public bool can_move_back { get; set; }

        public string answers { get; set; }
    }
}
