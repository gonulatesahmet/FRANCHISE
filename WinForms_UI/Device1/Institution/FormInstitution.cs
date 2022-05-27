using Business.Concrete;
using Business.Constants;
using Core.Tools.MyMessageBox;
using DataAccess.Concrete.Mssql;
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

namespace WinForms_UI.Device1.Institution
{
    public partial class FormInstitution : Form
    {
        DeviceDto _deviceDto;
        public FormInstitution(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        InstitutionManager institutionManager = new InstitutionManager(new MsInstitutionDal());
        private void FormInstitution_Load(object sender, EventArgs e)
        {
            var result = institutionManager.GetById(_deviceDto.InstitutionId);
            if (result.Success)
            {
                txtName.Text = result.Data.InstitutionName;
                txtCode.Text = result.Data.InstitutionCode;
                txtDescription.Text = result.Data.InstitutionDescription;
                txtUserName.Text = result.Data.UserName;
                txtUserPassword.Text = result.Data.UserPassword;
                txtPhone.Text = result.Data.InstitutionPhone;
                txtMail.Text = result.Data.InstitutionMail;
                txtAddress.Text = result.Data.InstitutionAddress;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = institutionManager.Update(new Entities.Concrete.Institution
            {
                InstitutionId = _deviceDto.InstitutionId,
                InstitutionName = txtName.Text,
                InstitutionCode = txtCode.Text,
                InstitutionDescription = txtDescription.Text,
                UserName = txtUserName.Text,
                UserPassword = txtUserPassword.Text,
                InstitutionPhone = txtPhone.Text,
                InstitutionMail = txtMail.Text,
                InstitutionAddress = txtAddress.Text
            });
            if (result.Success)
            {
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(Messages.UpdatedFailed);
            }
        }
    }
}
