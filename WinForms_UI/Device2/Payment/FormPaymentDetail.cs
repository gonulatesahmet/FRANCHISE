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
    public partial class FormPaymentDetail : Form
    {
        #region Entities
        DeviceDto _deviceDto;
        public int SessionId;
        public string TableName;
        int PaymentId;
        int TypeOfPaymentId;
        #endregion
        #region Manager
        SessionManager sessionManager = new SessionManager(new MsSessionDal());
        OrderManager orderManager = new OrderManager(new MsOrderDal());
        PaymentManager paymentManager = new PaymentManager(new MsPaymentDal());
        TypeOfPaymentManager typeOfPaymentManager = new TypeOfPaymentManager(new MsTypeOfPaymentDal());
        TableManager tableManager = new TableManager(new MsTableDal());
        #endregion
        public FormPaymentDetail(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        //Buton Ile Sayilari Yazma Islemini Yapar
        private void WriteTextBox(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btn1":
                    txtAmount.Text += (1).ToString();
                    break;
                case "btn2":
                    txtAmount.Text += (2).ToString();
                    break;
                case "btn3":
                    txtAmount.Text += (3).ToString();
                    break;
                case "btn4":
                    txtAmount.Text += (4).ToString();
                    break;
                case "btn5":
                    txtAmount.Text += (5).ToString();
                    break;
                case "btn6":
                    txtAmount.Text += (6).ToString();
                    break;
                case "btn7":
                    txtAmount.Text += (7).ToString();
                    break;
                case "btn8":
                    txtAmount.Text += (8).ToString();
                    break;
                case "btn9":
                    txtAmount.Text += (9).ToString();
                    break;
                case "btn0":
                    txtAmount.Text += (0).ToString();
                    break;
                case "btna":
                    txtAmount.Text += (',').ToString();
                    break;
                case "btnx":
                    if (txtAmount.Text.Length == 0)
                    {
                        MyMessageBox.ErrorMessageBox("Kutu Zaten Boş");
                    }
                    else
                    {
                        txtAmount.Text = txtAmount.Text.Remove(txtAmount.Text.Length - 1, 1);
                    }
                    break;
                default:
                    MyMessageBox.ErrorMessageBox("Sayı Giriniz.");
                    break;
            }
        }
        private void btnClickEvent()
        {
            btn1.Click += new EventHandler(WriteTextBox);
            btn2.Click += new EventHandler(WriteTextBox);
            btn3.Click += new EventHandler(WriteTextBox);
            btn4.Click += new EventHandler(WriteTextBox);
            btn5.Click += new EventHandler(WriteTextBox);
            btn6.Click += new EventHandler(WriteTextBox);
            btn7.Click += new EventHandler(WriteTextBox);
            btn8.Click += new EventHandler(WriteTextBox);
            btn9.Click += new EventHandler(WriteTextBox);
            btn0.Click += new EventHandler(WriteTextBox);
            btnx.Click += new EventHandler(WriteTextBox);
            btna.Click += new EventHandler(WriteTextBox);
        }





        //Odeme Bilgileri GroupBox'ini Doldurur.
        private void PaymentDetail()
        {
            decimal totalPrice = 0;
            decimal totalPayment = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                totalPrice += Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value);
            }
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                totalPayment += Convert.ToDecimal(dataGridView2.Rows[i].Cells[5].Value);
            }
            lblTotalPrice.Text = totalPrice.ToString();
            lblTotalPayment.Text = totalPayment.ToString();
            lblMissingAmount.Text = (totalPrice - totalPayment).ToString();
            lblTableName.Text = TableName;
            lblSessionId.Text = SessionId.ToString();
        }
        //Payment Butonlarini PaymentId ye Gore Aktif ya da Pasif Duruma Getirir.
        private void PaymentButtonStatus()
        {
            if (PaymentId == 0)
            {
                btnPaymentDelete.Enabled = false;
                btnPaymentUpdate.Enabled = false;
            }
            else
            {
                btnPaymentDelete.Enabled = true;
                btnPaymentUpdate.Enabled = true;
            }
        }
        //SessionId'ye Gore Odemeleri Listeler.
        private void PaymentList(int sessionId)
        {
            var result = paymentManager.PaymentDtoGetBySession(sessionId);
            if (result.Success)
            {
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = result.Data;
                string[] headers = { "", "", "", "Ödeme Tür", "Ödeme Tarih", "Ödeme Miktar", "Ödeme Not", "BranchId", "Sube Ad","EmployeeId","Personel Ad", "Ödeme Durum" };
                int[] visibles = { 0, 1, 2, 6, 7, 8, 9, 10 };
                MyDataGridView.createDataGridView(dataGridView2, headers, visibles);
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        //Odeme Ekler
        private bool PaymentAdd(decimal PaymentAmount)
        {
            
            if (PaymentAmount > Convert.ToDecimal(lblMissingAmount.Text))
            {
                MyMessageBox.ErrorMessageBox("Ödeme, Ödenecek Miktardan Büyük Olamaz.");
                return false;
            }
            else
            {
                var result = paymentManager.Add(new Entities.Concrete.Payment
                {
                    BranchId = _deviceDto.BranchId,
                    PaymentAmount = PaymentAmount,
                    PaymentDate = DateTime.Now,
                    PaymentState = true,
                    SessionId = SessionId,
                    TypeOfPaymentId = TypeOfPaymentId
                });
                if (result.Success)
                {
                    PaymentList(SessionId);
                    PaymentDetail();
                    MyMessageBox.InfoMessageBox(result.Message);
                    return true;
                }
                else
                {
                    MyMessageBox.ErrorMessageBox(result.Message);
                    return false;
                }
            }

        }





        //Session Bilgilerini Getirir. Masa Acilis Saatini Gostermek Icin
        private void SessionGetById(int sessionId)
        {
            var result = sessionManager.GetById(sessionId);
            if (result.Success)
            {
                lblSessionStartDate.Text = result.Data.StartDate.ToString();
                lblTableId.Text = result.Data.TableId.ToString();
            }
        }
        //Session Durumunu Degistirir
        private void SessionEnd(int sessionId)
        {
            var result = sessionManager.SessionEnd(new Entities.Concrete.Session
            {
                SessionId = sessionId,
                DueDate = DateTime.Now,
                SessionState = false,
                TotalPrice = Convert.ToDecimal(lblTotalPrice.Text)
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





        //Masa Displayini Degistirir.
        private void TableChangeDisplay(int tableId)
        {
            tableManager.TableChangeDisplay(tableId, false);
        }





        //Ilgili Labellari Doldurur.
        private void DeviceDetail()
        {
            lblTable.Text = TableName;
            lblArea.Text = _deviceDto.AreaName;
            lblDevice.Text = _deviceDto.DeviceName;
            lblDateTimeNow.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
        }
        
        



        //Siparisleri SessionId'ye Gore Toplu Sekilde Listeler.
        private void OrderList(int sessionId)
        {
            var result = orderManager.OrderDtoGetBySession(sessionId);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "OrderId", "SessionId", "Siparis Tarih", "İndirim İçerik Id", "İndirim İçerik Ad", "Sube Urun Id", "Urun Ad", "Adet","Birim Fiyat", "Total Tutar","Sipariş Not", "Siparis Tur Id", "Siparis Tur Ad", "Employee Id", "Calisan Ad", "Sube Id", "Sube Ad", "Siparis Durum" };
                int[] visibles = { 0, 1, 2, 3, 5, 10, 11, 12, 13, 14, 15, 16 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visibles);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        




        //Odeme Tur Bilgilerini Listeler
        private void TypeOfPaymentList()
        {
            var result = typeOfPaymentManager.CbbTypeOfPaymentGetAll(true);
            if (result.Success)
            {
                for(int i =0; i<result.Data.Count; i++)
                {
                    Button btn = new Button
                    {
                        Name = "btnTypeOfPayment" + result.Data[i].TypeOfPaymentId.ToString(),
                        Text = result.Data[i].TypeOfPaymentName,
                        Tag = result.Data[i].TypeOfPaymentId,
                        Width = 145,
                        Height = 105,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Palatino Linotype", 15, FontStyle.Italic, GraphicsUnit.Point, 1, false)
                    };
                    flowLayoutPanel1.Controls.Add(btn);
                    btn.Click += Btn_Click;
                }
            }
        }
        //Odeme Turunu Secer
        private void Btn_Click(object sender, EventArgs e)
        {
            lblTypeOfPaymentName.Text = ((Button)sender).Text.ToString();
            lblTypeOfPaymentId.Text = ((Button)sender).Tag.ToString();
            TypeOfPaymentId = Convert.ToInt32(((Button)sender).Tag.ToString());
        }
        




        private void FormPaymentDetail_Load(object sender, EventArgs e)
        {
            btnClickEvent();
            SessionGetById(SessionId);
            TypeOfPaymentList();
            OrderList(SessionId);
            PaymentList(SessionId);

            PaymentButtonStatus();
            DeviceDetail();
            PaymentDetail();

        }






        //TextBoxtaki Degeri PaymentAdd Fonksiyonuna Gonderir.
        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            PaymentAdd(Convert.ToDecimal(txtAmount.Text));
            txtAmount.Clear();
            lblTypeOfPaymentId.Text = "*";
            lblTypeOfPaymentName.Text = "*";
            TypeOfPaymentId = 0;
        }

        //Siparis Detaylarini Gosteren Sayfayi Acar.
        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            FormOrderDetail frm = new FormOrderDetail(_deviceDto);
            frm.SessionId = SessionId;
            frm.ShowDialog();
        }

        //Secili Odemeyi Siler Odeme Tekrar Listelenir Odeme Bilgileri Guncellenir
        private void btnPaymentDelete_Click(object sender, EventArgs e)
        {
            var result = paymentManager.Delete(PaymentId);
            if (result.Success)
            {
                PaymentList(SessionId);
                PaymentDetail();
                MyMessageBox.InfoMessageBox(result.Message);
                PaymentId = 0;
                PaymentButtonStatus();
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }

        //Odeme Tablosuna Tiklandiginda ID'yi Alir Ve Buton Durumlarini Degistirir
        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PaymentId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["PaymentId"].Value);
            PaymentButtonStatus();
        }

        //Secilen Odemeyi Guncellemek Icin Yeni Sayfa Acar
        private void btnPaymentUpdate_Click(object sender, EventArgs e)
        {

        }

        //Sayfayi Kapatir
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Odenecek Tutar Kadar Odeme Yapar - Session Kapanir - Masa Gorunumu Degistirilir.
        private void btnAddPaymentAndSessionClose_Click(object sender, EventArgs e)
        {
            if (PaymentAdd(Convert.ToDecimal(lblMissingAmount.Text)))
            {
                SessionEnd(SessionId);
                TableChangeDisplay(Convert.ToInt32(lblTableId.Text));
                this.Close();
            }
            
            
        }
    }
}
