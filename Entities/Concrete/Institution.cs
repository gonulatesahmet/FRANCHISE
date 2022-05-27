using Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Institution : IEntity
    {
        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionCode { get; set; }
        public string InstitutionDescription { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string InstitutionPhone { get; set; }
        public string InstitutionMail { get; set; }
        public string InstitutionAddress { get; set; }
        public bool InstitutionState { get; set; }
    }
}
