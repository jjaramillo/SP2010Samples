using System.Collections.Generic;

namespace SP2010Samples.PostIt.Entities
{
    public class PostIt : Item
    {
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public LookUp Owner { get; set; }
        public List<LookUp> Users { get; set; }
    }
}
