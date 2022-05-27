using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.Tools.MyTextBox
{
    [ToolboxItem(true)]
    public class MyIDNumberTextBox : MaskedTextBox
    {
        public MyIDNumberTextBox()
        {
            Mask = "00000000000";
        }
    }
}
