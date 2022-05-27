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

namespace WinForms_UI.TypeOfPayment
{
    public partial class FormTypeOfPayment : Form
    {
        #region Entity
        DeviceDto _deviceDto;
        public int TypeOfPaymentId;
        public bool TypeOfPaymentState;
        #endregion
        #region Manager
        TypeOfPaymentManager typeOfPaymentManager = new TypeOfPaymentManager(new MsTypeOfPaymentDal());
        #endregion
        public FormTypeOfPayment(DeviceDto deviceDto)
        {
            _deviceDto= deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (TypeOfPaymentId == 0)
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
            TypeOfPaymentId = 0;
            TypeOfPaymentState = false;
            ButtonStatus();
            txtName.Text = null;
            txtCode.Text = null;
            txtDescription.Text = null;
        }
        private void TypeOfPaymentList()
        {
            var result = typeOfPaymentManager.GetAll(_deviceDto.InstitutionId);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "Ödeme Tür Ad", "Ödeme Tür Kod", "Ödeme Tür Açıklama", "Ödeme Tür Durum" };
                int[] visible = { 0 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visible);
            }
        }
        private void FormTypeOfPayment_Load(object sender, EventArgs e)
        {
            Clear();
            TypeOfPaymentList();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TypeOfPaymentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TypeOfPaymentId"].Value);
            TypeOfPaymentState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["TypeOfPaymentState"].Value);
            ButtonStatus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = typeOfPaymentManager.Add(new Entities.Concrete.TypeOfPayment
            {
                TypeOfPaymentName = txtName.Text,
                TypeOfPaymentCode = txtCode.Text,
                TypeOfPaymentDescription = txtDescription.Text,
                TypeOfPaymentState = true
            });
            if (result.Success)
            {
                Clear();
                TypeOfPaymentList();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = typeOfPaymentManager.Delete(TypeOfPaymentId);
            if (result.Success)
            {
                Clear();
                TypeOfPaymentList();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate frm = new FormUpdate(new Entities.Concrete.TypeOfPayment
            {
                TypeOfPaymentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TypeOfPaymentId"].Value),
                TypeOfPaymentName = Convert.ToString(dataGridView1.CurrentRow.Cells["TypeOfPaymentName"].Value),
                TypeOfPaymentCode = Convert.ToString(dataGridView1.CurrentRow.Cells["TypeOfPaymentCode"].Value),
                TypeOfPaymentDescription = Convert.ToString(dataGridView1.CurrentRow.Cells["TypeOfPaymentDescription"].Value)
            });
            frm.ShowDialog();
            Clear();
            TypeOfPaymentList();
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = typeOfPaymentManager.ChangeState(TypeOfPaymentId, TypeOfPaymentState);
            if (result.Success)
            {
                Clear();
                TypeOfPaymentList();
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
