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
using WinForms_UI.Device1.BranchDiscount;
using WinForms_UI.Device1.BranchDiscountContent;
using WinForms_UI.Device1.BranchDiscountContentBranchProduct;
using WinForms_UI.Device1.BranchProduct;
using WinForms_UI.Device1.Institution;
using WinForms_UI.Device1.Page;
using WinForms_UI.Device1.TypeOfProduct;

namespace WinForms_UI
{
    public partial class FormMain : Form
    {
        public int InstitutionId;
        public int BranchId;
        public int AreaId;
        public int TypeOfDeviceId;
        public int DeviceId;

        DeviceDto _deviceDto;
        public FormMain(DeviceDto deviceDto)
        {
            

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

        private void btnBranch_Click(object sender, EventArgs e)
        {
            Branch.FormBranch frm = new Branch.FormBranch(_deviceDto);
            frm.ShowDialog();
        }

        private void btnAppellation_Click(object sender, EventArgs e)
        {
            Appellation.FormAppellation frm = new Appellation.FormAppellation(_deviceDto);
            frm.ShowDialog();
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            Auth.FormAuth frm = new Auth.FormAuth();
            frm.ShowDialog();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Category.FormCategory frm = new Category.FormCategory();
            frm.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Product.FormProduct frm = new Product.FormProduct(_deviceDto);
            frm.ShowDialog();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Employee.FormEmployee frm = new Employee.FormEmployee(_deviceDto);
            frm.ShowDialog();
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            Discount.FormDiscount frm = new Discount.FormDiscount(_deviceDto);
            frm.ShowDialog();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTypeOfPayment_Click(object sender, EventArgs e)
        {
            TypeOfPayment.FormTypeOfPayment frm = new TypeOfPayment.FormTypeOfPayment(_deviceDto);
            frm.ShowDialog();
        }

        private void btnDevice_Click(object sender, EventArgs e)
        {
            Device.FormDevice frm = new Device.FormDevice();
            frm.ShowDialog();
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            Area.FormArea frm = new Area.FormArea(_deviceDto);
            frm.ShowDialog();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            Table.FormTable frm = new Table.FormTable(_deviceDto);
            frm.ShowDialog();
        }

        private void btnBranchProduct_Click(object sender, EventArgs e)
        {
            FormBranchProduct frm = new FormBranchProduct(_deviceDto);
            frm.ShowDialog();
        }

        private void btnBranchDiscount_Click(object sender, EventArgs e)
        {
            FormBranchDiscount frm = new FormBranchDiscount(_deviceDto);
            frm.ShowDialog();
        }

        private void btnBranchDiscountContent_Click(object sender, EventArgs e)
        {
            FormBranchDiscountContent frm = new FormBranchDiscountContent(_deviceDto);
            frm.ShowDialog();
        }

        private void btnBranchDiscountContentBranchProduct_Click(object sender, EventArgs e)
        {
            FormBranchDiscountContentBranchProduct frm = new FormBranchDiscountContentBranchProduct(_deviceDto);
            frm.ShowDialog();
        }

        private void btnInstitution_Click(object sender, EventArgs e)
        {
            FormInstitution frm = new FormInstitution(_deviceDto);
            frm.ShowDialog();
        }

        private void btnTypeOfProduct_Click(object sender, EventArgs e)
        {
            FormTypeOfProduct frm = new FormTypeOfProduct(_deviceDto);
            frm.ShowDialog();
        }

        private void btnPage_Click(object sender, EventArgs e)
        {
            FormPage frm = new FormPage(_deviceDto);
            frm.ShowDialog();
        }
    }
}
