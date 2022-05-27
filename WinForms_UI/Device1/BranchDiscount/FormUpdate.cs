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

namespace WinForms_UI.Device1.BranchDiscount
{
    public partial class FormUpdate : Form
    {
        BranchDiscountDto _branchDiscountDto;
        TypeOfDiscountManager typeOfDiscountManager = new TypeOfDiscountManager(new MsTypeOfDiscountDal());
        BranchDiscountManager branchDiscountManager = new BranchDiscountManager(new MsBranchDiscountDal());
        public FormUpdate(BranchDiscountDto branchDiscountDto)
        {
            _branchDiscountDto = branchDiscountDto;
            InitializeComponent();
        }
        private void CbbTypeOfDiscountList()
        {
            var result = typeOfDiscountManager.CbbTypeOfDiscountGetAll(true);
            if (result.Success)
            {
                cbbTypeOfDiscount.ValueMember = "TypeOfDiscountId";
                cbbTypeOfDiscount.DisplayMember = "TypeOfDiscountName";
                cbbTypeOfDiscount.DataSource = result.Data;
            }
        }
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            CbbTypeOfDiscountList();
            lblDiscount.Text = _branchDiscountDto.DiscountName;
            cbbTypeOfDiscount.SelectedValue = _branchDiscountDto.TypeOfDiscountId;
            txtAmount.Text = _branchDiscountDto.BranchDiscountAmount.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = branchDiscountManager.Update(new Entities.Concrete.BranchDiscount
            {
                BranchDiscountId = _branchDiscountDto.BranchDiscountId,
                DiscountId = _branchDiscountDto.DiscountId,
                TypeOfDiscountId = Convert.ToInt32(cbbTypeOfDiscount.SelectedValue),
                BranchDiscountAmount = Convert.ToDecimal(txtAmount.Text)
            });
            if (result.Success)
            {
                MyMessageBox.InfoMessageBox(result.Message);
                this.Close();
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
    }
}
