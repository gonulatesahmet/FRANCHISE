using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tools.Button
{
    public class TableButton : System.Windows.Forms.Button
    {
        public int TableId { get; set; }
        public int AreaId { get; set; }
        public string TableName { get; set; }
        public bool Display { get; set; }
        public bool TableState { get; set; }
        public int SessionId { get; set; }

    }
}
