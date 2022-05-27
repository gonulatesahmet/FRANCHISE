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

namespace WinForms_UI.Discount
{
    public partial class FormUpdate : Form
    {
        Entities.Concrete.Discount _discount;
        DiscountManager discountManager = new DiscountManager(new MsDiscountDal());
        TypeOfDiscountManager typeOfDiscountManager = new TypeOfDiscountManager(new MsTypeOfDiscountDal());
        public FormUpdate(Entities.Concrete.Discount discount)
        {
            _discount = discount;
            InitializeComponent();
        }
        private void CbbTypeOfDiscountList()
        {
            cbbTypeOfDiscount.DataSource = null;
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
            cbbTypeOfDiscount.SelectedValue = _discount.TypeOfDiscountId;
            txtName.Text = _discount.DiscountName;
            txtCode.Text = _discount.DiscountCode;
            txtDescription.Text = _discount.DiscountDescription;
            txtAmount.Text = _discount.DiscountAmount.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = discountManager.Update(new Entities.Concrete.Discount
            {
                DiscountId = _discount.DiscountId,
                DiscountName = txtName.Text,
                DiscountCode = txtCode.Text,
                DiscountDescription = txtDescription.Text,
                DiscountAmount = Convert.ToDecimal(txtAmount.Text),
                TypeOfDiscountId = Convert.ToInt16(cbbTypeOfDiscount.SelectedValue)
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
