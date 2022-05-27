using Business.Concrete;
using Business.Tools.Button;
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

namespace WinForms_UI.Device2.Payment
{
    public partial class FormPayment : Form
    {
        #region Entites
        DeviceDto _deviceDto;
        #endregion
        #region Manager
        AreaManager areaManager = new AreaManager(new MsAreaDal());
        TableManager tableManager = new TableManager(new MsTableDal());
        SessionManager sessionManager = new SessionManager(new MsSessionDal());
        #endregion
        public FormPayment(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void AreaList(int branchId)
        {
            var result = areaManager.AreaDtoGetByBranch(branchId);
            if (result.Success)
            {
                for (int i = 0; i < result.Data.Count; i++)
                {
                    if (result.Data[i].AreaState == true)
                    {
                        AreaButton btn = new AreaButton
                        {
                            Name = "btnArea" + result.Data[i].AreaId,
                            Text = result.Data[i].AreaName,
                            AreaName = result.Data[i].AreaName,
                            AreaId = result.Data[i].AreaId,
                            Width = 280,
                            Height = 77,
                            Dock = DockStyle.Top,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Palatino Linotype", 15, FontStyle.Bold),
                            FlatStyle = FlatStyle.Flat,
                        };
                        if (result.Data[i].AreaId == _deviceDto.AreaId)
                        {
                            btn.BackColor = Color.FromArgb(15, 8, 75);
                            btn.ForeColor = Color.FromArgb(166, 207, 213);
                        }
                        else
                        {
                            btn.BackColor = Color.FromArgb(38, 64, 139);
                            btn.ForeColor = Color.FromArgb(166, 207, 213);
                        }
                        btn.FlatAppearance.BorderSize = 0;
                        flowLayoutPanel1.Controls.Add(btn);
                        btn.Click += btnArea;
                    }
                }
            }
        }
        private void TableList(int areaId)
        {
            flowLayoutPanel2.Controls.Clear();
            var result = tableManager.TableGetByArea(areaId, true);
            if (result.Success)
            {
                for (int i = 0; i < result.Data.Count; i++)
                {
                    TableButton btn = new TableButton
                    {
                        Name = "btnTable" + result.Data[i].TableId,
                        Text = result.Data[i].TableName,
                        TableId = result.Data[i].TableId,
                        TableName = result.Data[i].TableName,
                        AreaId = result.Data[i].AreaId,
                        Display = result.Data[i].Display,
                        Width = 261,
                        Height = 126,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Palatino Linotype", 15, FontStyle.Italic, GraphicsUnit.Point, 1, false),
                        FlatStyle = FlatStyle.Flat,
                        ForeColor = Color.FromArgb(166, 207, 213)
                    };

                    var sessionControl = sessionManager.SessionControl(result.Data[i].TableId, true);
                    if (sessionControl.Success)
                    {
                        btn.BackColor = Color.FromArgb(42, 145, 52);
                        btn.SessionId = sessionControl.Data.SessionId;
                    }
                    else
                    {
                        btn.BackColor = Color.FromArgb(38, 64, 139);
                        btn.Enabled = false;
                    }
                    btn.Click += btnTable;
                    flowLayoutPanel2.Controls.Add(btn);
                }

            }
        }

        private void btnTable(object sender, EventArgs e)
        {
            FormPaymentDetail frm = new FormPaymentDetail(_deviceDto);
            frm.SessionId = ((TableButton)sender).SessionId;
            frm.TableName = ((TableButton)sender).TableName;
            frm.ShowDialog();
            this.Close();
        }

        private void btnArea(object sender, EventArgs e)
        {
            foreach (AreaButton item in flowLayoutPanel1.Controls.OfType<AreaButton>().Where(item => (item).BackColor == Color.FromArgb(15, 8, 75)))
            {
                (item).BackColor = Color.FromArgb(38, 64, 139);
                (item).ForeColor = Color.FromArgb(166, 207, 213);
            }
            ((AreaButton)sender).BackColor = Color.FromArgb(15, 8, 75);
            ((AreaButton)sender).ForeColor = Color.FromArgb(166, 207, 213);
            TableList(((AreaButton)sender).AreaId);
        }

        private void FormPayment_Load(object sender, EventArgs e)
        {
            AreaList(_deviceDto.BranchId);
            TableList(_deviceDto.AreaId);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
