using Business.Concrete;
using Business.Constants;
using Core.Tools.MyMessageBox;
using DataAccess.Concrete.Mssql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_UI.Device
{
    public partial class FormUpdate : Form
    {
        public int InstitutionId;
        public int DeviceId;
        DeviceManager deviceManager = new DeviceManager(new MsDeviceDal());
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        AreaManager areaManager = new AreaManager(new MsAreaDal());
        TypeOfDeviceManager typeOfDeviceManager = new TypeOfDeviceManager(new MsTypeOfDeviceDal());
        public FormUpdate()
        {
            InitializeComponent();
        }
        private void CbbBranchList(int InstitutionId)
        {
            //var result = branchManager.CbbGetAll(InstitutionId, true);
            //if (result.Success)
            //{
            //    cbbBranch.ValueMember = "BranchId";
            //    cbbBranch.DisplayMember = "BranchName";
            //    cbbBranch.DataSource = result.Data;
            //}
        }
        private void CbbAreaList(int BranchId)
        {
            //cbbArea.DataSource = null;
            //var result = areaManager.CbbGetByBranch(BranchId, true);
            //if (result.Success)
            //{
            //    cbbArea.ValueMember = "AreaId";
            //    cbbArea.DisplayMember = "AreaName";
            //    cbbArea.DataSource = result.Data;
            //}
        }
        private void CbbTypeOfDeviceList()
        {
            //cbbTypeOfDevice.DataSource = null;
            //var result = typeOfDeviceManager.CbbGetAll(true);
            //if (result.Success)
            //{
            //    cbbTypeOfDevice.ValueMember = "TypeOfDeviceId";
            //    cbbTypeOfDevice.DisplayMember = "TypeOfDeviceName";
            //    cbbTypeOfDevice.DataSource = result.Data;
            //}
        }
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            var result = deviceManager.GetById(DeviceId);
            if (result.Success)
            {
                CbbBranchList(InstitutionId);
                CbbTypeOfDeviceList();
                txtName.Text = result.Data.DeviceName;
                txtCode.Text = result.Data.DeviceCode;
                txtDescription.Text = result.Data.DeviceDescription;
                txtMac.Text = result.Data.DeviceMac;
                cbbTypeOfDevice.SelectedValue = result.Data.TypeOfDeviceId;
                cbbBranch.SelectedValue = result.Data.BranchId;
                CbbAreaList(result.Data.BranchId);
                cbbArea.SelectedValue = result.Data.AreaId;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = deviceManager.Update(new Entities.Concrete.Device
            {
                DeviceId = DeviceId,
                DeviceName = txtName.Text,
                DeviceCode = txtCode.Text,
                DeviceDescription = txtDescription.Text,
                DeviceMac = txtMac.Text,
                BranchId = Convert.ToInt32(cbbBranch.SelectedValue),
                AreaId = Convert.ToInt32(cbbArea.SelectedValue),
                TypeOfDeviceId = Convert.ToInt32(cbbTypeOfDevice.SelectedValue)
            });
            if (result.Success)
            {
                MyMessageBox.InfoMessageBox(result.Message);
                this.Close();
            }
            else
            {
                MyMessageBox.ErrorMessageBox(Messages.UpdatedFailed);
                this.Close();
            }
        }
    }
}
