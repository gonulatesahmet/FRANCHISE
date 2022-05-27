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

namespace WinForms_UI.Branch
{
    public partial class FormUpdate : Form
    {
        Entities.Concrete.Branch _branch;
        public FormUpdate(Entities.Concrete.Branch branch)
        {
            _branch = branch; 
            InitializeComponent();
        }
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            
            txtName.Text = _branch.BranchName;
            txtCode.Text= _branch.BranchCode;
            txtDescription.Text= _branch.BranchDescription;
            txtAuthorizedName.Text = _branch.AuthorizedPerson;
            txtPhone.Text = _branch.BranchPhone;
            txtMail.Text = _branch.BranchMail;
            txtAddress.Text = _branch.BranchAddress;
            txtCity.Text = _branch.BranchCity;
            txtDistrict.Text = _branch.BranchDistrict;
            txtBranchRegion.Text = _branch.BranchRegion;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = branchManager.Update(new Entities.Concrete.Branch
            {
                BranchId = _branch.BranchId,
                BranchName = txtName.Text,
                BranchCode = txtCode.Text,
                BranchDescription = txtDescription.Text,
                AuthorizedPerson = txtAuthorizedName.Text,
                BranchDistrict = txtDistrict.Text,
                BranchAddress = txtAddress.Text,
                BranchCity = txtCity.Text,
                BranchRegion = txtBranchRegion.Text,
                BranchMail = txtMail.Text,
                BranchPhone = txtPhone.Text
            });
            if (result.Success)
            {
                MyMessageBox.InfoMessageBox(Messages.BranchUpdated);
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
