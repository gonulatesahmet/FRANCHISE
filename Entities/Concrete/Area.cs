using Core.Entities;

namespace Entities.Concrete
{
    public class Area : IEntity
    {
        public int AreaId { get; set; }
        public int BranchId { get; set; }
        public string AreaName { get; set; }
        public string AreaCode { get; set; }
        public string AreaDescription { get; set; }
        public bool AreaState { get; set; }
    }
}
