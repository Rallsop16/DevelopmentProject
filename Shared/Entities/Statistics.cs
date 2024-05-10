using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentProject.Shared.Entities
{
    public class Statistics
    {
        public int StatisticsId { get; set; }

        public int? Experience { get; set; }

        public int? Time { get; set; }

        public string? Language { get; set; }
        public int UserId { get; set; } // foreign key from user table
        public User? User { get; set; }
    }
}
