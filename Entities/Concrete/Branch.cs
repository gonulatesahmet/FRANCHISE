using Core.Entities;

namespace Entities.Concrete
{
    public class Branch : IEntity
    {
        public int BranchId { get; set; }
        public int InstitutionId { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string BranchDescription { get; set; }
        public string AuthorizedPerson { get; set; }
        public string BranchPhone { get; set; }
        public string BranchMail { get; set; }
        public string BranchRegion { get; set; }
        public string BranchCity { get; set; }
        public string BranchDistrict { get; set; }
        public string BranchAddress { get; set; }
        public bool BranchState { get; set; }
    }
}
