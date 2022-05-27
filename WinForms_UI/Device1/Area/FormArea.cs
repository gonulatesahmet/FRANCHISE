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

namespace WinForms_UI.Area
{
    public partial class FormArea : Form
    {
        #region Entity
        DeviceDto _deviceDto;
        public int AreaId;
        public bool AreaState;
        #endregion
        #region Manager
        AreaManager areaManager = new AreaManager(new MsAreaDal());
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        #endregion
        public FormArea(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (AreaId == 0)
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
            AreaId = 0;
            AreaState = false;
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
        private void AreaDtoGetByBranch(int branchId)
        {
            var result = areaManager.AreaDtoGetByBranch(branchId);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "Saha Ad", "Saha Kod", "Saha Açıklama", "", "Şube Ad", "Saha Durum" };
                int[] visible = { 0, 4 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visible);
            }
        }
        private void FormArea_Load(object sender, EventArgs e)
        {
            ButtonStatus();
            CbbBranchList(_deviceDto.InstitutionId);
            AreaDtoGetByBranch(Convert.ToInt32(cbbBranch.SelectedValue));
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AreaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AreaId"].Value);
            AreaState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["AreaState"].Value);
            ButtonStatus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = areaManager.Add(new Entities.Concrete.Area
            {
                AreaName = txtName.Text,
                AreaCode = txtCode.Text,
                AreaDescription = txtDescription.Text,
                BranchId = Convert.ToInt32(cbbBranch.SelectedValue),
                AreaState = true
            });
            if (result.Success)
            {
                AreaDtoGetByBranch(Convert.ToInt32(cbbBranch.SelectedValue));
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
            var result = areaManager.Delete(AreaId);
            if (result.Success)
            {
                Clear();
                AreaDtoGetByBranch(Convert.ToInt32(cbbBranch.SelectedValue));
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormUpdate frm = new FormUpdate(new Entities.Concrete.Area
            {
                AreaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AreaId"].Value),
                AreaName = Convert.ToString(dataGridView1.CurrentRow.Cells["AreaName"].Value),
                AreaCode = Convert.ToString(dataGridView1.CurrentRow.Cells["AreaCode"].Value),
                AreaDescription = Convert.ToString(dataGridView1.CurrentRow.Cells["AreaDescription"].Value)
            });
            frm.ShowDialog();
            Clear();
            AreaDtoGetByBranch(Convert.ToInt32(cbbBranch.SelectedValue));
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = areaManager.ChangeState(AreaId, AreaState);
            if (result.Success)
            {
                Clear();
                AreaDtoGetByBranch(Convert.ToInt32(cbbBranch.SelectedValue));
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

        private void cbbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaDtoGetByBranch(Convert.ToInt32(cbbBranch.SelectedValue));
        }
    }
}
