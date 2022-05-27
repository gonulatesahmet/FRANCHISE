using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PageAuth : IEntity
    {
        public int PageAuthId { get; set; }
        public int PageId { get; set; }
        public int AuthId { get; set; }
        public bool PageAuthState { get; set; }
    }
}
