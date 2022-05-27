using Business.Concrete;
using Core.Tools.DataGrivView;
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
using Entities.Concrete;
using Business.Constants;
using Business.Abstract;
using Core.Utilites.Results;
using Entities.DTOs;

namespace WinForms_UI.Appellation
{
    public partial class FormAppellation : Form
    {
        #region Entity
        DeviceDto _deviceDto;
        int AppellationId;
        bool AppellationState;
        #endregion
        #region Manager
        AppellationManager appellationManager = new AppellationManager(new MsAppellationDal());
        #endregion

        public FormAppellation(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (AppellationId == 0)
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
            AppellationId = 0;
            AppellationState = false;
            txtName.Text = null;
            txtCode.Text = null;
            txtDescription.Text = null;
            ButtonStatus();
        }
        private void AppellationGetAll()
        {
            
            var result = appellationManager.GetAll(0);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] HeaderText = { "", "Unvan Ad", "Unvan Kod", "Unvan Açıklama", "Unvan Durum" };
                int[] VisibleColumn = { 0 };
                MyDataGridView.createDataGridView(dataGridView1, HeaderText, VisibleColumn);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void FormAppellation_Load(object sender, EventArgs e)
        {
            ButtonStatus();
            AppellationGetAll();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Tiklandiginda ID yi  Alir.
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AppellationId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppellationId"].Value);
            AppellationState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["AppellationState"].Value);
            ButtonStatus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = appellationManager.Add(new Entities.Concrete.Appellation
            {
                AppellationName = txtName.Text,
                AppellationCode = txtCode.Text,
                AppellationDescription = txtDescription.Text,
                AppellationState = true
            });
            if (result.Success)
            {
                Clear();
                AppellationGetAll();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = appellationManager.Delete(AppellationId);
            if (result.Success)
            {
                AppellationGetAll();
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
            FormUpdate frm = new FormUpdate(new Entities.Concrete.Appellation
            {
                AppellationId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppellationId"].Value),
                AppellationName = Convert.ToString(dataGridView1.CurrentRow.Cells["AppellationName"].Value),
                AppellationCode= Convert.ToString(dataGridView1.CurrentRow.Cells["AppellationCode"].Value),
                AppellationDescription = Convert.ToString(dataGridView1.CurrentRow.Cells["AppellationDescription"].Value)
            });
            frm.ShowDialog();
            Clear();
            AppellationGetAll();
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            var result = appellationManager.ChangeState(AppellationId, AppellationState);
            if (result.Success)
            {
                Clear();
                AppellationGetAll();
                MyMessageBox.InfoMessageBox(result.Message);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }

    }
}
