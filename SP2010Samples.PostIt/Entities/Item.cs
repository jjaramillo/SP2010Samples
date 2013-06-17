using System;

namespace SP2010Samples.PostIt.Entities
{
    public class Item
    {
        private DateTime? _Created;
        private DateTime? _Updated;
        private LookUp _CreatedBy;
        private LookUp _UpdatedBy;

        public string Title { get; set; }
        public DateTime? Created { get { return _Created; } }
        public DateTime? Updated { get { return _Updated; } }
        public LookUp CreatedBy { get { return _CreatedBy; } }
        public LookUp UpdateBy { get { return _UpdatedBy; } }
    }
}
