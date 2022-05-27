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
using System.Windows.Forms.DataVisualization.Charting;

namespace WinForms_UI.Device2.BranchGeneralReport
{
    public partial class FormBranchGeneralReport : Form
    {
        #region Entities
        DeviceDto _deviceDto;
        #endregion
        #region Manager
        OrderManager orderManager = new OrderManager(new MsOrderDal());
        PaymentManager paymentManager = new PaymentManager(new MsPaymentDal());
        BranchProductManager branchProductManager = new BranchProductManager(new MsBranchProductDal());

        #endregion
        public FormBranchGeneralReport(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void TabControlSelectedIndex()
        {
            if (tabControl1.SelectedIndex == 1)
            {
                BranchTypeOfPaymentReport(_deviceDto.BranchId, dateTimePicker1.Value, 0);
            }
            if (tabControl1.SelectedIndex == 2)
            {
                BranchProductDailySales(_deviceDto.BranchId, dateTimePicker1.Value);
            }
            if (tabControl1.SelectedIndex == 3)
            {
                BranchTypeOfOrderReport(_deviceDto.BranchId, dateTimePicker1.Value);
            }
            if (tabControl1.SelectedIndex == 5)
            {
                BranchEmployeeSales(_deviceDto.BranchId, dateTimePicker1.Value);
            }
            if (tabControl1.SelectedIndex == 6)
            {
                BranchTypeOfProductReport(_deviceDto.BranchId, dateTimePicker1.Value);
            }
            if (tabControl1.SelectedIndex == 7)
            {
                BranchDiscountContentReport(_deviceDto.BranchId, dateTimePicker1.Value);
            }
            if (tabControl1.SelectedIndex == 8)
            {
                BranchCategoryBasedOrderDetails(_deviceDto.BranchId, dateTimePicker1.Value);
                BranchTypeOfPaymentReport(_deviceDto.BranchId, dateTimePicker1.Value, 1);
            }
        }
        //Sube Gunluk Ciro Raporu
        private void BranchDailyEndorsement(int branchId)
        {
            var result = orderManager.BranchDailyEndorsement(branchId);
            if (result.Success)
            {
                //Series series = new Series("Sube Günlük Ciro");
                //for(int i = 0; i<result.Data.Count; i++)
                //{
                //    series.Points.AddXY(result.Data[i].OrderDate, result.Data[i].TotalPrice);
                //}
                //chart1.Series.Add(series);

                DateTime date = DateTime.Now;
                Series s = new Series("s");
                for (int i = 0; i < 30; i++)
                {

                    foreach (var item in result.Data)
                    {
                        if (date.Date == item.OrderDate)
                        {
                            s.Points.AddXY(date, item.TotalPrice);
                            goto a1;
                        }
                    }
                    s.Points.AddXY(date, 0);
                a1:

                    date = date.AddDays(-1);
                }
                chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart1.ChartAreas[0].AxisX.Interval = 1;
                s.IsValueShownAsLabel = true;
                chart1.Series.Add(s);
            }
        }
        //Sube Odeme Tur Raporu
        private void BranchTypeOfPaymentReport(int branchId, DateTime date, int x)
        {
            chart2.Series.Clear();
            var result = paymentManager.BranchTypeOfPaymentReport(branchId, date);
            if (result.Success)
            {
                Series s = new Series("Odeme Tur");
                for (int i = 0; i < result.Data.Count; i++)
                {
                    s.Points.AddXY(result.Data[i].TypeOfPaymentName, result.Data[i].PaymentAmount);
                }
                chart2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart2.ChartAreas[0].AxisX.Interval = 1;
                chart2.ChartAreas[0].RecalculateAxesScale();
                s.IsValueShownAsLabel = true;
                chart2.Series.Add(s);
                if(x == 1)
                {
                    decimal totalPayment = 0;

                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = result.Data;
                    string[] headers = { "", "", "", "Ödeme Tür", "", "Ödeme Miktar", "", "", "", "", "", "" };
                    int[] visibles = { 0, 1, 2, 4, 6, 7, 8, 9, 10, 11 };
                    MyDataGridView.createDataGridView(dataGridView2, headers, visibles);

                    for(int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        totalPayment += Convert.ToDecimal(dataGridView2.Rows[i].Cells[5].Value);
                    }
                    lblTotalPaymentPrice.Text = totalPayment.ToString();
                    lblTotalPaymentPrice2.Text = lblTotalPaymentPrice.Text;
                    lblTotalTypeOfPaymentCount.Text = dataGridView2.Rows.Count.ToString();
                }
            }
            else
            {
                MyMessageBox.ErrorMessageBox("Hata");
            }
        }
        //Sube Urun Gunluk Satis Raporu
        private void BranchProductDailySales(int branchId, DateTime date)
        {
            var result = orderManager.BranchProductDailySales(branchId, date);
            if (result.Success)
            {
                chart3.Series.Clear();
                Series s = new Series("");
                s.ChartType = SeriesChartType.Doughnut;
                for (int i = 0; i < result.Data.Count; i++)
                {
                    s.Points.AddXY(result.Data[i].ProductName, result.Data[i].OrderPiece);
                }
                chart3.ChartAreas[0].RecalculateAxesScale();
                chart3.Series.Add(s);
                chart3.Series[0].Label = "#VALX\n#VALY";
            }
        }
        //Siparis Tur Bazli Rapor
        private void BranchTypeOfOrderReport(int branchId, DateTime date)
        {
            var result = orderManager.BranchTypeOfOrderReport(branchId, date);
            if (result.Success)
            {
                chart4.Series.Clear();
                Series s = new Series();

                for (int i = 0; i < result.Data.Count; i++)
                {
                    s.Points.AddXY(result.Data[i].TypeOfOrderName, result.Data[i].OrderPiece);
                }
                chart4.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart4.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart4.ChartAreas[0].AxisX.Interval = 1;
                chart4.ChartAreas[0].RecalculateAxesScale();
                s.IsValueShownAsLabel = true;
                chart4.Series.Add(s);
            }
        }
        //Personel Bazli Rapor
        private void BranchEmployeeSales(int branchId, DateTime date)
        {
            var result = orderManager.BranchEmployeeSales(branchId, date);
            if (result.Success)
            {
                chart5.Series.Clear();

                var group = from product in result.Data
                            orderby product.EmployeeName
                            group product by product.EmployeeName into p
                            select p;
                foreach (var x in group)
                {
                    Series s = new Series(x.Key);
                    foreach (var y in x)
                    {
                        s.Points.AddXY(y.ProductName, y.OrderPiece);
                    }
                    s.IsValueShownAsLabel = true;
                    chart5.Series.Add(s);
                }

                chart5.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart5.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart5.ChartAreas[0].AxisX.Interval = 1;
                chart5.ChartAreas[0].RecalculateAxesScale();

            }
        }
        //Urun Tur Bazli Rapor
        private void BranchTypeOfProductReport(int branchId, DateTime date)
        {
            var result = orderManager.BranchTypeOfProductReport(branchId, date);
            if (result.Success)
            {
                chart6.Series.Clear();
                Series s = new Series("Ürün Tür");
                for (int i = 0; i < result.Data.Count; i++)
                {
                    s.Points.AddXY(result.Data[i].TypeOfOrderName, result.Data[i].OrderPiece);
                }
                chart6.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart6.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart6.ChartAreas[0].AxisX.Interval = 1;
                chart6.ChartAreas[0].RecalculateAxesScale();
                s.IsValueShownAsLabel = true;
                chart6.Series.Add(s);
            }
        }
        //Sube Indirim Icerik Bazli Rapor
        private void BranchDiscountContentReport(int branchId, DateTime date)
        {
            var result = orderManager.BranchDiscountContentReport(branchId, date);
            if (result.Success)
            {
                chart7.Series.Clear();
                Series s = new Series();
                for (int i = 0; i < result.Data.Count; i++)
                {
                    s.Points.AddXY(result.Data[i].BranchDiscountContentName, result.Data[i].OrderPiece);
                }
                chart7.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart7.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                chart7.ChartAreas[0].AxisX.Interval = 1;
                chart7.ChartAreas[0].RecalculateAxesScale();
                s.IsValueShownAsLabel = true;
                chart7.Series.Add(s);
            }
        }
        //Sube Kategori Bazli Siparis Detaylari
        private void BranchCategoryBasedOrderDetails(int branchId, DateTime date)
        {
            var result = orderManager.BranchCategoryBasedOrderDetails(branchId, date);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "Order Id", "Session Id", "OrderDate", "BranchDiscountContentId", "Şube İndirim İçerik Ad", "BranchProductId", "Kategori Ad", "Sipariş Adet", "Birim Fiyat", "Total Fiyat", "Sipariş Not", "TypeOfOrderId", "Sipariş Tür Ad", "EmployeeId", "Personel Ad", "BranchId", "Şube Ad", "Sipariş Durum" };
                int[] visibles = { 0, 1, 2, 3, 4, 5, 8, 10, 11, 12, 13, 14, 15, 16, 17 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visibles);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                decimal totalPrice = 0;
                int ProductCount = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    totalPrice += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ProductCount += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                }
                lblTotalCategoryCount.Text = dataGridView1.Rows.Count.ToString();
                lblTotalProduct.Text = ProductCount.ToString();
                lblTotalOrderPrice.Text = totalPrice.ToString();
                lblTotalOrderPrice2.Text = lblTotalOrderPrice.Text;

            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
            TabControlSelectedIndex();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value == DateTime.Now.Date)
            {
                MyMessageBox.ErrorMessageBox("Ileri Tarih Raporlari Henuz Olusturulmadi.");
            }
            else
            {
                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
                TabControlSelectedIndex();
            }
        }

        private void FormBranchGeneralReport_Load(object sender, EventArgs e)
        {
            BranchDailyEndorsement(_deviceDto.BranchId);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

            TabControlSelectedIndex();
        }


    }
}
