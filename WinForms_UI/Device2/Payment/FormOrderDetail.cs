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

namespace WinForms_UI.Device2.Payment
{
    public partial class FormOrderDetail : Form
    {
        #region Entities
        DeviceDto _deviceDto;
        public int SessionId;
        #endregion
        #region Manager
        OrderManager orderManager = new OrderManager(new MsOrderDal());
        #endregion
        public FormOrderDetail(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }

        private void OrderList(int sessionId)
        {
            var result = orderManager.OrderDtoDetailGetBySession(sessionId);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "Order Id", "Session Id", "OrderDate", "BranchDiscountContentId", "Şube İndirim İçerik Ad", "BranchProductId", "Şube Ürün Ad", "Sipariş Adet", "Birim Fiyat", "Total Fiyat", "Sipariş Not", "TypeOfOrderId", "Sipariş Tür Ad", "EmployeeId", "Personel Ad", "BranchId", "Şube Ad", "Sipariş Durum" };
                int[] visibles = { 0, 1, 3, 5, 8, 11, 13, 15 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visibles);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }

        private void FormOrderDetail_Load(object sender, EventArgs e)
        {
            OrderList(SessionId);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
