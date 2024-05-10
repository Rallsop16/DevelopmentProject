using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentProject.Shared.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

        public ICollection<Vocab>? Vocabs { get; set; }

        public ICollection<CollectionVocab>? CollectionVocabs { get; set; }

        public ICollection<Statistics>? StatisticsCol {  get; set; }

    }
}

