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

namespace WinForms_UI.Device2
{
    public partial class FormMoveTheTable : Form
    {
        #region Entities
        DeviceDto _deviceDto;
        public int SessionId;
        #endregion
        #region Manager
        AreaManager areaManager = new AreaManager(new MsAreaDal());
        TableManager tableManager = new TableManager(new MsTableDal());
        SessionManager sessionManager = new SessionManager(new MsSessionDal());
        OrderManager orderManager = new OrderManager(new MsOrderDal());
        PaymentManager paymentManager = new PaymentManager(new MsPaymentDal());
        #endregion
        public FormMoveTheTable(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }

        private void AreaList(int branchId)
        {
            var result = areaManager.CbbAreaGetAll(branchId, true);
            if (result.Success)
            {
                for (int i = 0; i < result.Data.Count; i++)
                {
                    Button btnArea = new Button();
                    btnArea.Text = result.Data[i].AreaName;
                    btnArea.Name = "btn" + result.Data[i].AreaId.ToString();
                    btnArea.Width = 280;
                    btnArea.Height = 77;
                    btnArea.Dock = DockStyle.Top;
                    btnArea.TextAlign = ContentAlignment.MiddleCenter;
                    btnArea.Font = new Font("Palatino Linotype", 15, FontStyle.Bold);
                    if (result.Data[i].AreaId == _deviceDto.AreaId)
                    {
                        btnArea.BackColor = Color.Yellow;
                        btnArea.FlatAppearance.BorderColor = Color.Yellow;
                        btnArea.Enabled = false;
                    }
                    else
                    {
                        btnArea.BackColor = Color.Gainsboro;
                    }
                    flowLayoutPanel1.Controls.Add(btnArea);
                    btnArea.Click += (sender, e) =>
                    {
                        foreach (Button item in flowLayoutPanel1.Controls.OfType<Button>().Where(item => (item).BackColor == Color.Yellow))
                        {
                            (item).BackColor = Color.Gainsboro;
                            item.Enabled = true;
                        }

                        btnArea.BackColor = Color.Yellow;
                        btnArea.Enabled = false;
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
                    btnTable.TableId = result.Data[i].TableId;
                    btnTable.Name = "btnTable" + result.Data[i].TableId.ToString();
                    btnTable.Text = result.Data[i].TableName;
                    btnTable.Width = 261;
                    btnTable.Height = 126;
                    btnTable.TextAlign = ContentAlignment.MiddleCenter;
                    btnTable.Font = new Font("Palatino Linotype", 15, FontStyle.Italic, GraphicsUnit.Point, 1, false);
                    var sessionControl = sessionManager.SessionControl(result.Data[i].TableId, true);
                    if (sessionControl.Success)
                    {
                        btnTable.BackColor = Color.Green;
                        btnTable.SessionId = sessionControl.Data.SessionId;
                    }
                    else
                    {
                        btnTable.BackColor = Color.Gainsboro;
                    }
                    flowLayoutPanel2.Controls.Add(btnTable);
                    btnTable.Click += BtnTable_Click;
                    


                }
            }
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            if(((TableButton)sender).SessionId == 0)
            {
                var result = sessionManager.MoveTheTable(SessionId, ((TableButton)sender).TableId);
                if (result.Success)
                {
                    MyMessageBox.InfoMessageBox(result.Message);
                    this.Close();
                }
                else
                {
                    MyMessageBox.ErrorMessageBox(result.Message);
                }
            }
            else
            {
                if(OrderChangeSession(SessionId, ((TableButton)sender).SessionId))
                {
                    if(PaymentChangeSession(SessionId, ((TableButton)sender).SessionId))
                    {
                        SessionDelete(SessionId);
                    }
                }
            }
        }

        private bool PaymentChangeSession(int oldSessionId, int newSessionId)
        {
            var result = paymentManager.PaymentChangeSession(oldSessionId, newSessionId);
            if (result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool OrderChangeSession(int oldSessionId, int newSessionId)
        {
            var result = orderManager.OrderChangeSession(oldSessionId, newSessionId);
            if (result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void SessionDelete(int sessionId)
        {
            var result = sessionManager.Delete(sessionId);
            if (result.Success)
            {
                this.Close();
            }
        }

        private void FormMoveTheTable_Load(object sender, EventArgs e)
        {
            AreaList(_deviceDto.BranchId);
            TableList(_deviceDto.AreaId);
        }
    }
}
