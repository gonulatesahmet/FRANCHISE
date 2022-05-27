using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PageAuthDto : IDTOs
    {
        public int PageAuthId { get; set; }
        public int PageId { get; set; }
        public string PageText { get; set; }
        public int AuthId { get; set; }
        public string AuthName { get; set; }
        public bool PageAuthState { get; set; }
    }
}
