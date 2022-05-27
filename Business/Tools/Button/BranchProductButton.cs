using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tools.Button
{
    public class BranchProductButton : System.Windows.Forms.Button
    {
        public int BranchProductId { get; set; }
        public decimal BranchProductPrice { get; set; }
        public string ProductName { get; set; }
    }
}
