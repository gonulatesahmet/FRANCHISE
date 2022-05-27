using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Core.Tools.MyMessageBox
{
    public class MyMessageBox
    {
        public static void InfoMessageBox(string text)
        {
            MessageBox.Show(text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ErrorMessageBox(string text)
        {
            MessageBox.Show(text,"Hata",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
