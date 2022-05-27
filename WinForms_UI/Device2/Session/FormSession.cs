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

namespace WinForms_UI.Device2.Session
{
    public partial class FormSession : Form
    {
        #region Entities
        DeviceDto _deviceDto;
        private string EmployeeName;
        public int EmployeeId;
        #endregion
        #region Manager
        EmployeeManager employeeManager = new EmployeeManager(new MsEmployeeDal());
        AreaManager areaManager = new AreaManager(new MsAreaDal());
        TableManager tableManager = new TableManager(new MsTableDal());
        SessionManager sessionManager = new SessionManager(new MsSessionDal());
        #endregion
        public FormSession(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void GetEmployee(int employeeId)
        {
            var result = employeeManager.GetById(employeeId);
            if (result.Success)
            {
                EmployeeName = result.Data.EmployeeName + " " + result.Data.EmployeeSurname;
            }
        }
        private void AreaList(int branchId)
        {
            var result = areaManager.CbbAreaGetAll(branchId, true);
            if (result.Success)
            {
                for (int i = 0; i < result.Data.Count; i++)
                {
                    Button btnArea = new Button();
                    btnArea.ForeColor = Color.FromArgb(166, 207, 213);
                    btnArea.FlatStyle = FlatStyle.Flat;
                    btnArea.FlatAppearance.BorderSize = 0;

                    btnArea.Text = result.Data[i].AreaName;
                    btnArea.Name = "btn" + result.Data[i].AreaId.ToString();
                    btnArea.Width = 280;
                    btnArea.Height = 77;
                    btnArea.Dock = DockStyle.Top;
                    btnArea.TextAlign = ContentAlignment.MiddleCenter;
                    btnArea.Font = new Font("Palatino Linotype", 15, FontStyle.Bold);

                    if (result.Data[i].AreaId == _deviceDto.AreaId)
                    {
                        btnArea.BackColor = Color.FromArgb(15, 8, 75);
                        btnArea.ForeColor = Color.FromArgb(166, 207, 213);
                    }
                    else
                    {
                        btnArea.BackColor = Color.FromArgb(38, 64, 139);
                        btnArea.ForeColor = Color.FromArgb(166, 207, 213);
                    }
                    flowLayoutPanel1.Controls.Add(btnArea);
                    btnArea.Click += (sender, e) =>
                    {
                        foreach (Button item in flowLayoutPanel1.Controls.OfType<Button>().Where(item => (item).BackColor == Color.FromArgb(15, 8, 75)))
                        {
                            (item).BackColor = Color.FromArgb(38, 64, 139);
                            (item).ForeColor = Color.FromArgb(166, 207, 213);
                        }

                        btnArea.BackColor = Color.FromArgb(15, 8, 75);
                        ((Button)sender).ForeColor = Color.FromArgb(166, 207, 213);
                        TableList(Convert.ToInt32(((Button)sender).Name.Remove(0, 3)));
                    };

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
                    TableButton btnTable = new TableButton();
                    btnTable.FlatStyle = FlatStyle.Flat;
                    btnTable.FlatAppearance.BorderSize = 0;
                    btnTable.ForeColor = Color.FromArgb(166, 207, 213);

                    btnTable.Name = "btnTable" + result.Data[i].TableId.ToString();
                    btnTable.Text = result.Data[i].TableName;
                    btnTable.Width = 261;
                    btnTable.Height = 126;
                    btnTable.TextAlign = ContentAlignment.MiddleCenter;
                    btnTable.Font = new Font("Palatino Linotype", 15, FontStyle.Italic, GraphicsUnit.Point, 1, false);
                    var sessionControl = sessionManager.SessionControl(result.Data[i].TableId, true);
                    if (sessionControl.Success)
                    {
                        btnTable.BackColor = Color.FromArgb(42,145,52);
                        btnTable.SessionId = sessionControl.Data.SessionId;
                    }
                    else
                    {
                        btnTable.BackColor = Color.FromArgb(38, 64, 139);
                    }
                    flowLayoutPanel2.Controls.Add(btnTable);
                    btnTable.Click += (sender, e) =>
                    {

                        FormSessionDetail frm = new FormSessionDetail(_deviceDto);
                        frm.EmployeeId = EmployeeId;
                        frm.EmployeeName = EmployeeName;
                        frm.TableId = Convert.ToInt32(((Button)sender).Name.Remove(0, 8));
                        frm.TableName = Convert.ToString(((Button)sender).Text);
                        frm.SessionId = ((TableButton)sender).SessionId;
                        frm.ShowDialog();
                        this.Close();
                    };


                }
            }
        }
        
        private void FormSession_Load(object sender, EventArgs e)
        {
            GetEmployee(EmployeeId);
            lblEmployee.Text = EmployeeName;
            lblBranch.Text = _deviceDto.BranchName;
            lblDevice.Text = _deviceDto.DeviceName;
            lblDateTimeNow.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            AreaList(_deviceDto.BranchId);
            TableList(_deviceDto.AreaId);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
