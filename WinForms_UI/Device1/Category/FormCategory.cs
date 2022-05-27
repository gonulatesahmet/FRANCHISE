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

namespace WinForms_UI.Category
{
    public partial class FormCategory : Form
    {
        #region Entity
        DeviceDto _deviceDto;
        public int CategoryId;
        public bool CategoryState;
        #endregion
        #region Manager
        CategoryManager categoryManager = new CategoryManager(new MsCategoryDal());
        #endregion
        public FormCategory()
        {
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (CategoryId == 0)
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
            CategoryId = 0;
            CategoryState = false;
            ButtonStatus();
            txtName.Text = null;
            txtCode.Text = null;
            txtDescription.Text = null;
        }
        private void CategoryGetAll()
        {
            var result = categoryManager.GetAll(0);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "Kategori Ad", "Kategori Kod", "Kategori Açıklama", "Kategori Durum" };
                int[] visible = { 0 };
                MyDataGridView.createDataGridView(dataGridView1,headers,visible);
            }
        }
        private void FormCategory_Load(object sender, EventArgs e)
        {
            Clear();
            ButtonStatus();
            CategoryGetAll();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CategoryId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CategoryId"].Value);
            CategoryState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["CategoryState"].Value);
            ButtonStatus();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = categoryManager.Add(new Entities.Concrete.Category
            {
                CategoryName = txtName.Text,
                CategoryDescription = txtDescription.Text,
                CategoryCode = txtCode.Text,
                CategoryState = true
            });
            if (result.Success)
            {
                Clear();
                CategoryGetAll();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var  result = categoryManager.Delete(CategoryId);
            if (result.Success)
            {
                CategoryGetAll();
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
            FormUpdate frm = new FormUpdate(new Entities.Concrete.Category
            {
                CategoryId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CategoryId"].Value),
                CategoryName = Convert.ToString(dataGridView1.CurrentRow.Cells["CategoryName"].Value),
                CategoryCode = Convert.ToString(dataGridView1.CurrentRow.Cells["CategoryCode"].Value),
                CategoryDescription = Convert.ToString(dataGridView1.CurrentRow.Cells["CategoryDescription"].Value)
            });
            frm.ShowDialog();
            Clear();
            CategoryGetAll();
        }
        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = categoryManager.ChangeState(CategoryId, CategoryState);
            if (result.Success)
            {
                Clear();
                CategoryGetAll();
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
