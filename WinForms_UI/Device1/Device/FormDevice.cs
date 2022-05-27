using Business.Concrete;
using Business.Constants;
using Core.Tools.DataGrivView;
using Core.Tools.MyMessageBox;
using DataAccess.Concrete.Mssql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_UI.Device
{
    public partial class FormDevice : Form
    {
        public int InstitutionId;
        public int DeviceId;
        public bool DeviceState;
        DeviceManager deviceManager = new DeviceManager(new MsDeviceDal());
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        AreaManager areaManager = new AreaManager(new MsAreaDal());
        TypeOfDeviceManager typeOfDeviceManager = new TypeOfDeviceManager(new MsTypeOfDeviceDal());
        public FormDevice()
        {
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (DeviceId == 0)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnChangeState.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnChangeState.Enabled = true;
            }
        }
        private void Clear()
        {
            DeviceId = 0;
            DeviceState = false;
            ButtonStatus();
            txtName.Text = null;
            txtCode.Text = null;
            txtDescription.Text = null;
            txtMac.Text = null;
            cbbTypeOfDevice.Text = null;
            cbbBranch.Text = null;
            cbbArea.Text = null;
        }
        private void CbbBranchList(int InstitutionId)
        {
            //var result = branchManager.CbbGetAll(InstitutionId,true);
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
            //var result = areaManager.CbbGetByBranch(BranchId,true);
            //if (result.Success)
            //{
            //    cbbArea.ValueMember = "AreaId";
            //    cbbArea.DisplayMember = "AreaName";
            //    cbbArea.DataSource = result.Data;
            //}
        }
        private void CbbTypeOfDeviceList()
        {
            //cbbTypeOfDevice.DataSource= null;
            //var result = typeOfDeviceManager.CbbGetAll(true);
            //if (result.Success)
            //{
            //    cbbTypeOfDevice.ValueMember = "TypeOfDeviceId";
            //    cbbTypeOfDevice.DisplayMember = "TypeOfDeviceName";
            //    cbbTypeOfDevice.DataSource = result.Data;
            //}
        }
        private void GetMacAddress()
        {
            string macadress = string.Empty;
            string mac = null;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                OperationalStatus ot = nic.OperationalStatus;
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macadress = nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            for (int i = 0; i <= macadress.Length - 1; i++)
            {
                mac = mac + ":" + macadress.Substring(i, 2);
                // mac adresini alırken parça parça aldığından 
                //aralarına : işaretini biz atıyoruz.
                i++;
            }
            mac = mac.Remove(0, 1);
            // en sonda kalan fazladan : işaretini siliyoruz.
            txtAvailableMac.Text = mac;
        }
        private void DeviceList()
        {
            var result = deviceManager.DeviceDtoGetAll();
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "Cihaz Ad", "Cihaz Kod", "Cihaz Açıklama", "Cihaz MAC", "Şube Ad", "Saha Ad", "Cihaz Tür Ad", "Cihaz Durum", "", "", "", "" };
                int[] visible = { 0, 9,10,11,12 };
                MyDataGridView.createDataGridView(dataGridView1,headers,visible);
            }
        }
        private void FormDevice_Load(object sender, EventArgs e)
        {
            CbbBranchList(InstitutionId);
            CbbTypeOfDeviceList();
            DeviceList();
            GetMacAddress();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = deviceManager.Add(new Entities.Concrete.Device
            {
                DeviceName = txtName.Text,
                DeviceCode = txtCode.Text,
                DeviceDescription = txtDescription.Text,
                TypeOfDeviceId = Convert.ToInt32(cbbTypeOfDevice.SelectedValue),
                InstitutionId = InstitutionId,
                BranchId = Convert.ToInt32(cbbBranch.SelectedValue),
                AreaId = Convert.ToInt32(cbbArea.SelectedValue),
                DeviceMac = txtMac.Text,
                DeviceState = true
            });
            if (result.Success)
            {
                Clear();
                DeviceList();
                MyMessageBox.InfoMessageBox(result.Message);
            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DeviceId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DeviceId"].Value);
            DeviceState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["DeviceState"].Value);
            ButtonStatus();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = deviceManager.Delete(DeviceId);
            if (result.Success)
            {
                Clear();
                DeviceList();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(Messages.DeletedFailed);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate frm = new FormUpdate();
            frm.DeviceId = DeviceId;
            frm.ShowDialog();
            Clear();
            DeviceList();
        }
        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = deviceManager.ChangeState(DeviceId, DeviceState);
            if (result.Success)
            {
                Clear();
                DeviceList();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(Messages.ChangeStatedFailed);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBranch.SelectedIndex != -1)
            {
                CbbAreaList((int)cbbBranch.SelectedValue);
            }

        }
    }
}
