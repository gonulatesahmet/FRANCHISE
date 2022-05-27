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

namespace WinForms_UI.Device1.TypeOfProduct
{
    public partial class FormTypeOfProduct : Form
    {
        #region Entity
        public int TypeOfProductId;
        public bool TypeOfProductState;
        DeviceDto _deviceDto;
        #endregion
        #region Manager
        TypeOfProductManager typeOfProductManager = new TypeOfProductManager(new MsTypeOfProductDal());
        #endregion

        public FormTypeOfProduct(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (TypeOfProductId == 0)
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
            TypeOfProductId = 0;
            TypeOfProductState = false;
            ButtonStatus();
            txtName.Text = null;
            txtCode.Text = null;
            txtDescription.Text = null;
            cbbPrinter.SelectedValue = false;
            cbbDisplay.SelectedValue = false;
        }
        public class CbbDisplay
        {
            public bool Value { get; set; }
            public string Key { get; set; }
        }
        public class CbbPrinter
        {
            public bool Value { get; set; }
            public string Key { get; set; }
        }
        private void cbbTrueOrFalseList()
        {
            List<CbbDisplay> cbbDisplayList = new List<CbbDisplay>()
            {
                new CbbDisplay { Value = false, Key = "Hayır" },
                new CbbDisplay { Value = true, Key = "Evet" }
            };
            List<CbbPrinter> cbbPrinterList = new List<CbbPrinter>()
            {
                new CbbPrinter { Value = false, Key = "Hayır" },
                new CbbPrinter { Value = true, Key = "Evet" }
            };
            cbbDisplay.DataSource = cbbDisplayList;
            cbbPrinter.DataSource = cbbPrinterList;
            cbbDisplay.DisplayMember = "Key";
            cbbPrinter.DisplayMember = "Key";
            cbbDisplay.ValueMember = "Value";
            cbbPrinter.ValueMember = "Value";
        }
        private void TypeOfProductGetAll()
        {
            var result = typeOfProductManager.GetAll(0);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "Ürün Tür Ad", "Ürün Tür Kod", "Ürün Tür Açıklama", "Ürün Tür Görünüm", "Ürün Tür Yazıcı", "Ürün Tür Durum" };
                int[] visible = { 0 };
                MyDataGridView.createDataGridView(dataGridView1,headers, visible);
            }
        }
        private void FormTypeOfProduct_Load(object sender, EventArgs e)
        {
            ButtonStatus();
            cbbTrueOrFalseList();
            TypeOfProductGetAll();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = typeOfProductManager.Add(new Entities.Concrete.TypeOfProduct
            {
                TypeOfProductName = txtName.Text,
                TypeOfProductCode = txtCode.Text,
                TypeOfProductDescription = txtDescription.Text,
                TypeOfProductDisplay = Convert.ToBoolean(cbbDisplay.SelectedValue),
                TypeOfProductPrinter = Convert.ToBoolean(cbbPrinter.SelectedValue),
                TypeOfProductState = true
            });
            if (result.Success)
            {
                TypeOfProductGetAll();
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
            var result = typeOfProductManager.Delete(TypeOfProductId);
            if (result.Success)
            {
                TypeOfProductGetAll();
                Clear();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(Messages.DeletedFailed);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate frm = new FormUpdate(new Entities.Concrete.TypeOfProduct
            {
                TypeOfProductId=Convert.ToInt32(dataGridView1.CurrentRow.Cells["TypeOfProductId"].Value),
                TypeOfProductName = Convert.ToString(dataGridView1.CurrentRow.Cells["TypeOfProductName"].Value),
                TypeOfProductCode = Convert.ToString(dataGridView1.CurrentRow.Cells["TypeOfProductCode"].Value),
                TypeOfProductDescription = Convert.ToString(dataGridView1.CurrentRow.Cells["TypeOfProductDescription"].Value),
                TypeOfProductDisplay = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["TypeOfProductDisplay"].Value),
                TypeOfProductPrinter = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["TypeOfProductPrinter"].Value)
            });
            frm.ShowDialog();
            Clear();
            TypeOfProductGetAll();
        }
        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = typeOfProductManager.ChangeState(TypeOfProductId,TypeOfProductState);
            if (result.Success)
            {
                TypeOfProductGetAll();
                Clear();
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
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TypeOfProductId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TypeOfProductId"].Value);
            TypeOfProductState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["TypeOfProductState"].Value);
            ButtonStatus();
        }
    }
}
