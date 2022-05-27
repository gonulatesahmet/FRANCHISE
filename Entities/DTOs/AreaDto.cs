using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AreaDto : IDTOs
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string AreaCode { get; set; }
        public string AreaDescription { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public bool AreaState { get; set; }
    }
}
