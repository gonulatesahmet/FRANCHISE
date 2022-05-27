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
    public class MyPhoneTextBox : MaskedTextBox
    {
        public MyPhoneTextBox()
        {
            Mask = "+00 (999) 000-0000";
        }

        
    }
}
