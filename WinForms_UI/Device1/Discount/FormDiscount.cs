using Business.Concrete;
using Business.Constants;
using Core.Tools.DataGrivView;
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

namespace WinForms_UI.Discount
{
    public partial class FormDiscount : Form
    {
        #region Entity
        public int DiscountId;
        public bool DiscountState;
        DeviceDto _deviceDto;
        #endregion
        #region Manager
        DiscountManager discountManager = new DiscountManager(new MsDiscountDal());
        TypeOfDiscountManager typeOfDiscountManager = new TypeOfDiscountManager(new MsTypeOfDiscountDal());
        #endregion
        public FormDiscount(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (DiscountId == 0)
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
            DiscountId = 0;
            DiscountState = false;
            ButtonStatus();
            txtName.Text = null;
            txtCode.Text = null;
            txtDescription.Text = null;
            txtAmount.Text = null;
        }
        private void CbbTypeOfDiscountGetAll()
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
        private void DiscountList()
        {
            var result = discountManager.DiscountDtoGetAll(0);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "İndirim Ad", "İndirim Kod", "İndirim Açıklama", "İndirim Miktar", "İndirim Tur Id", "İndirim Tür", "İndirim Durum" };
                int[] visible = { 0, 5 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visible);
            }
        }
        private void FormDiscount_Load(object sender, EventArgs e)
        {
            Clear();
            CbbTypeOfDiscountGetAll();
            DiscountList();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DiscountId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DiscountId"].Value);
            DiscountState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["DiscountState"].Value);
            ButtonStatus();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = discountManager.Add(new Entities.Concrete.Discount
            {
                DiscountName = txtName.Text,
                DiscountCode = txtCode.Text,
                DiscountDescription = txtDescription.Text,
                DiscountAmount = Convert.ToDecimal(txtAmount.Text),
                TypeOfDiscountId = Convert.ToInt16(cbbTypeOfDiscount.SelectedValue),
                DiscountState = true
            });
            if (result.Success)
            {
                DiscountList();
                Clear();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = discountManager.Delete(DiscountId);
            if (result.Success)
            {
                DiscountList();
                Clear();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate frm = new FormUpdate(new Entities.Concrete.Discount
            {
                DiscountId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DiscountId"].Value),
                DiscountName = Convert.ToString(dataGridView1.CurrentRow.Cells["DiscountName"].Value),
                DiscountCode = Convert.ToString(dataGridView1.CurrentRow.Cells["DiscountCode"].Value),
                DiscountDescription = Convert.ToString(dataGridView1.CurrentRow.Cells["DiscountDescription"].Value),
                DiscountAmount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["DiscountAmount"].Value),
                TypeOfDiscountId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TypeOfDiscountId"].Value)
            });
            frm.ShowDialog();
            Clear();
            DiscountList();
        }
        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = discountManager.ChangeState(DiscountId, DiscountState);
            if (result.Success)
            {
                Clear();
                DiscountList();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
