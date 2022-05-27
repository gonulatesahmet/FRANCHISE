using Business.Concrete;
using Core.Tools.MyMessageBox;
using Core.Utilities.Security.DeviceInformation;
using DataAccess.Concrete.Mssql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms_UI.Device2;

namespace WinForms_UI
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DeviceManager deviceManager = new DeviceManager(new MsDeviceDal());
            var result = deviceManager.DeviceDtoGetByDeviceMac(DeviceMac.GetDeviceMac());
            if (result.Success)
            {
                if (result.Data.TypeOfDeviceId == 1)
                {
                    Application.Run(new FormMain(result.Data));
                }
                if (result.Data.TypeOfDeviceId == 2)
                {
                    Application.Run(new FormBranchMainMachine(result.Data));
                }
                if (result.Data.TypeOfDeviceId == 3)
                {
                    Application.Run(new Form1());
                }
                if (result.Data.TypeOfDeviceId == 4)
                {
                    Application.Run(new Form1());
                }
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }

        }
    }
}
