using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TableDto : IDTOs
    {
        public int TableId { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string TableName { get; set; }
        public string TableCode { get; set; }
        public string TableDescription { get; set; }
        public bool Display { get; set; }
        public bool TableState { get; set; }
    }
}
