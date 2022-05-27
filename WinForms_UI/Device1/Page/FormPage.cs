using Business.Concrete;
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

namespace WinForms_UI.Device1.Page
{
    public partial class FormPage : Form
    {
        #region Entities
        DeviceDto _deviceDto;
        int PageId;
        #endregion
        #region Manager
        PageManager pageManager = new PageManager(new MsPageDal());
        #endregion
        public FormPage(DeviceDto deviceDto)
        {
            InitializeComponent();
        }
        private void TextBoxClear()
        {
            txtText.Text = null;
            txtName.Text = null;
            txtIcon.Text= null;
            PageId = 0;
        }
        private void PageList()
        {
            var result = pageManager.GetAll(0);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "PageId", "Sayfa Ad", "Sayfa Text", "Sayfa Icon", "Sayfa Durum" };
                int[] visibles = { 0 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visibles);
            }
        }

        private void FormPage_Load(object sender, EventArgs e)
        {
            PageList();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PageId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PageId"].Value);
            txtName.Text = dataGridView1.CurrentRow.Cells["PageName"].Value.ToString();
            txtText.Text = dataGridView1.CurrentRow.Cells["PageText"].Value.ToString();
            txtIcon.Text = dataGridView1.CurrentRow.Cells["PageIcon"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var result = pageManager.Update(new Entities.Concrete.Page
            {
                PageId = PageId,
                PageName = txtName.Text,
                PageText = txtText.Text,
                PageIcon = txtIcon.Text,
            });
            if (result.Success)
            {
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
