using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentProject.Shared.Entities
{
    public class CollectionMap
    {
        public int CollectionMapId { get; set; }

        public int VocabId { get; set; } // foreign key from vocab table

        public int CollectionVocabId { get; set; } // foreign key from collection table

        public Vocab? Vocab { get; set; }
        public CollectionVocab? CollectionVocab { get; set; }
    }
}
