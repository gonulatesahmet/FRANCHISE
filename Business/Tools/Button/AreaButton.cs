using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tools.Button
{
    public class AreaButton : System.Windows.Forms.Button
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public bool AreaState { get; set; }
    }
}
