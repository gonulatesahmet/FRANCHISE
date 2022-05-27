using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms_UI.Device2.BranchGeneralReport;
using WinForms_UI.Device2.Employee;
using WinForms_UI.Device2.Payment;
using WinForms_UI.Device2.Session;

namespace WinForms_UI.Device2
{
    public partial class FormBranchMainMachine : Form
    {
        public int InstitutionId;
        public int BranchId;
        public int AreaId;
        public int TypeOfDeviceId;
        public int DeviceId;
        public int EmployeeId;
        DeviceDto _deviceDto;
        private bool EmployeeControl()
        {
            using (var form = new FormEmployeeControl())
            {
                form.BranchId = BranchId;
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    EmployeeId = form.EmployeeId;
                    return true;
                }
                return false;
            }
        }
        public FormBranchMainMachine(DeviceDto deviceDto)
        {
            this.BackColor = Color.FromArgb(49,54,56);

            _deviceDto = deviceDto;
            InitializeComponent();
            lblDeviceName.Text = deviceDto.DeviceName;
            lblDeviceCode.Text = deviceDto.DeviceCode;
            lblDeviceMac.Text = deviceDto.DeviceMac;
            lblTypeOfDevice.Text = deviceDto.TypeOfDeviceName;
            lblBranch.Text = deviceDto.BranchName;
            lblArea.Text = deviceDto.AreaName;
            InstitutionId = deviceDto.InstitutionId;
            BranchId = deviceDto.BranchId;
            AreaId = deviceDto.AreaId;
            TypeOfDeviceId = deviceDto.TypeOfDeviceId;
            DeviceId = deviceDto.DeviceId;
        }
        private void btnSession_Click(object sender, EventArgs e)
        {
            if (EmployeeControl())
            {
                FormSession frm = new FormSession(_deviceDto);
                frm.EmployeeId = EmployeeId;
                frm.ShowDialog();
            }
        }

        public void btnBranch_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            FormPayment frm = new FormPayment(_deviceDto);
            frm.ShowDialog();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            FormEmployee frm = new FormEmployee(_deviceDto);
            frm.ShowDialog();
        }

        private void btnBranchGeneralReport_Click(object sender, EventArgs e)
        {
            FormBranchGeneralReport frm = new FormBranchGeneralReport(_deviceDto);
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
