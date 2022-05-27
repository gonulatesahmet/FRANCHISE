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

namespace WinForms_UI.Table
{
    public partial class FormTable : Form
    {
        #region Entity
        DeviceDto _deviceDto;
        public int TableId;
        public bool TableState;
        #endregion
        #region Manager
        TableManager tableManager = new TableManager(new MsTableDal());
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        AreaManager areaManager = new AreaManager(new MsAreaDal());
        #endregion
        public FormTable(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (TableId == 0)
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
            TableId = 0;
            TableState = false;
            ButtonStatus();
            txtName.Text = null;
            txtCode.Text = null;
            txtDescription.Text = null;
        }
        private void CbbBranchList(int InstitutionId)
        {
            cbbBranch.DataSource = null;
            var result = branchManager.CbbBranchGetAll(InstitutionId, true);
            if (result.Success)
            {
                cbbBranch.ValueMember = "BranchId";
                cbbBranch.DisplayMember = "BranchName";
                cbbBranch.DataSource = result.Data;
            }
        }
        private void CbbAreaList(int BranchId)
        {
            cbbArea.DataSource = null;
            var result = areaManager.CbbAreaGetAll(BranchId, true);
            if (result.Success)
            {
                cbbArea.ValueMember = "AreaId";
                cbbArea.DisplayMember = "AreaName";
                cbbArea.DataSource = result.Data;
            }
        }
        private void TableList(int AreaId)
        {
            var result = tableManager.TableDtoGetByArea(AreaId);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "", "Saha Ad", "Masa Ad", "Masa Kod", "Masa Açıklama", "Masa Görünüm", "Masa Durum" };
                int[] visible = { 0, 1 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visible);
            }
        }
        private void FormTable_Load(object sender, EventArgs e)
        {
            CbbBranchList(_deviceDto.InstitutionId);
            ButtonStatus();
        }
        private void cbbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbbAreaList(Convert.ToInt32(cbbBranch.SelectedValue));
        }
        private void cbbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableList(Convert.ToInt32(cbbArea.SelectedValue));
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TableId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TableId"].Value);
            TableState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["TableState"].Value);
            ButtonStatus();   
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = tableManager.Add(new Entities.Concrete.Table
            {
                TableName = txtName.Text,
                TableCode = txtCode.Text,
                TableDescription = txtDescription.Text,
                Display = false,
                AreaId = Convert.ToInt32(cbbArea.SelectedValue),
                TableState = true
            });
            if (result.Success)
            {
                Clear();
                TableList(Convert.ToInt32(cbbArea.SelectedValue));
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = tableManager.Delete(TableId);
            if (result.Success)
            {
                Clear();
                TableList(Convert.ToInt32(cbbArea.SelectedValue));
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate frm = new FormUpdate(new Entities.Concrete.Table
            {
                TableId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TableId"].Value),
                TableName = Convert.ToString(dataGridView1.CurrentRow.Cells["TableName"].Value),
                TableCode = Convert.ToString(dataGridView1.CurrentRow.Cells["TableCode"].Value),
                TableDescription = Convert.ToString(dataGridView1.CurrentRow.Cells["TableDescription"].Value),
            });
            frm.ShowDialog();
            Clear();
            TableList(Convert.ToInt32(cbbArea.SelectedValue));
        }
        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = tableManager.ChangeState(TableId, TableState);
            if (result.Success)
            {
                Clear();
                TableList(Convert.ToInt32(cbbArea.SelectedValue));
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
