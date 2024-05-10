using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentProject.Shared.Entities
{
    public class Vocab
    {
        public int VocabId { get; set; }
        public string? Original_word { get; set; }

        public string? Translated_word { get; set; }

        public string? Original_language { get; set; }

        public string? Translated_language { get; set; }

        public int UserId { get; set; } // foreign key from user table

        public User? User { get; set; }

        public ICollection<CollectionMap>? CollectionMaps { get; set; }
    }

}

