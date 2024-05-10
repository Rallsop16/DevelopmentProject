using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentProject.Shared.Entities
{
    public class CollectionVocab
    {
        public int CollectionVocabId { get; set; }

        public string? CollectionVocabName { get; set; }

        public int UserId { get; set; } // foreign key from user table
        public User? User { get; set; }

        public ICollection<CollectionMap>? CollectionMaps { get; set; }
    }
}
