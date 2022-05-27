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

namespace WinForms_UI.Device2.Session
{
    public partial class FormOrderDetail : Form
    {

        #region Entities
        public int SessionId;
        int OrderId;
        Entities.Enums.OrderStateEnum.OrderState orderState;
        #endregion
        #region Manager
        OrderManager orderManager = new OrderManager(new MsOrderDal());
        #endregion
        public FormOrderDetail()
        {
            InitializeComponent();
        }
        private void OrderDetail()
        {
            var result = orderManager.OrderDtoDetailGetBySession(SessionId);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "Order Id", "Session Id", "OrderDate", "BranchDiscountContentId", "Şube İndirim İçerik Ad", "BranchProductId", "Şube Ürün Ad", "Sipariş Adet", "Birim Fiyat", "Total Fiyat", "Sipariş Not", "TypeOfOrderId", "Sipariş Tür Ad", "EmployeeId", "Personel Ad", "BranchId", "Şube Ad", "Sipariş Durum" };
                int[] visibles = { 0, 1, 3, 5, 8, 11, 13, 15 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visibles);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void ButtonStatus(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btn1":
                    txtEmployeeCode.Text += (1).ToString();
                    break;
                case "btn2":
                    txtEmployeeCode.Text += (2).ToString();
                    break;
                case "btn3":
                    txtEmployeeCode.Text += (3).ToString();
                    break;
                case "btn4":
                    txtEmployeeCode.Text += (4).ToString();
                    break;
                case "btn5":
                    txtEmployeeCode.Text += (5).ToString();
                    break;
                case "btn6":
                    txtEmployeeCode.Text += (6).ToString();
                    break;
                case "btn7":
                    txtEmployeeCode.Text += (7).ToString();
                    break;
                case "btn8":
                    txtEmployeeCode.Text += (8).ToString();
                    break;
                case "btn9":
                    txtEmployeeCode.Text += (9).ToString();
                    break;
                case "btn0":
                    txtEmployeeCode.Text += (0).ToString();
                    break;
                case "btnq":
                    txtEmployeeCode.Text += "Q";
                    break;
                case "btnw":
                    txtEmployeeCode.Text += "W";
                    break;
                case "btne":
                    txtEmployeeCode.Text += "E";
                    break;
                case "btnr":
                    txtEmployeeCode.Text += "R";
                    break;
                case "btnt":
                    txtEmployeeCode.Text += "T";
                    break;
                case "btny":
                    txtEmployeeCode.Text += "Y";
                    break;
                case "btnu":
                    txtEmployeeCode.Text += "U";
                    break;
                case "btnii":
                    txtEmployeeCode.Text += "I";
                    break;
                case "btno":
                    txtEmployeeCode.Text += "O";
                    break;
                case "btnp":
                    txtEmployeeCode.Text += "P";
                    break;
                case "btnyg":
                    txtEmployeeCode.Text += "Ğ";
                    break;
                case "btniu":
                    txtEmployeeCode.Text += "Ü";
                    break;
                case "btna":
                    txtEmployeeCode.Text += "A";
                    break;
                case "btns":
                    txtEmployeeCode.Text += "S";
                    break;
                case "btnd":
                    txtEmployeeCode.Text += "D";
                    break;
                case "btnf":
                    txtEmployeeCode.Text += "F";
                    break;
                case "btng":
                    txtEmployeeCode.Text += "G";
                    break;
                case "btnh":
                    txtEmployeeCode.Text += "H";
                    break;
                case "btnj":
                    txtEmployeeCode.Text += "J";
                    break;
                case "btnk":
                    txtEmployeeCode.Text += "K";
                    break;
                case "btnl":
                    txtEmployeeCode.Text += "L";
                    break;
                case "btnis":
                    txtEmployeeCode.Text += "Ş";
                    break;
                case "btni":
                    txtEmployeeCode.Text += "İ";
                    break;
                case "btnz":
                    txtEmployeeCode.Text += "Z";
                    break;
                case "btnx":
                    txtEmployeeCode.Text += "X";
                    break;
                case "btnc":
                    txtEmployeeCode.Text += "C";
                    break;
                case "btnv":
                    txtEmployeeCode.Text += "V";
                    break;
                case "btnb":
                    txtEmployeeCode.Text += "B";
                    break;
                case "btnn":
                    txtEmployeeCode.Text += "N";
                    break;
                case "btnm":
                    txtEmployeeCode.Text += "M";
                    break;
                case "btnio":
                    txtEmployeeCode.Text += "Ö";
                    break;
                case "btnic":
                    txtEmployeeCode.Text += "Ç";
                    break;
                case "btnnokta":
                    txtEmployeeCode.Text += ".";
                    break;
                case "btnspc":
                    txtEmployeeCode.Text += " ";
                    break;
                case "btnyldz":
                    txtEmployeeCode.Text += "*";
                    break;
                case "btncizgi":
                    txtEmployeeCode.Text += "-";
                    break;
                case "btndel":
                    if (txtEmployeeCode.Text.Length == 0)
                    {
                        MyMessageBox.ErrorMessageBox("Kutu Zaten Boş");
                    }
                    else
                    {
                        txtEmployeeCode.Text = txtEmployeeCode.Text.Remove(txtEmployeeCode.Text.Length - 1, 1);
                    }
                    break;
                default:
                    MyMessageBox.ErrorMessageBox("Sayı Giriniz.");
                    break;
            }
        }
        private void FormOrderDetail_Load(object sender, EventArgs e)
        {
            btn1.Click += new EventHandler(ButtonStatus);
            btn2.Click += new EventHandler(ButtonStatus);
            btn3.Click += new EventHandler(ButtonStatus);
            btn4.Click += new EventHandler(ButtonStatus);
            btn5.Click += new EventHandler(ButtonStatus);
            btn6.Click += new EventHandler(ButtonStatus);
            btn7.Click += new EventHandler(ButtonStatus);
            btn8.Click += new EventHandler(ButtonStatus);
            btn9.Click += new EventHandler(ButtonStatus);
            btn0.Click += new EventHandler(ButtonStatus);
            btnyldz.Click += new EventHandler(ButtonStatus);
            btncizgi.Click += new EventHandler(ButtonStatus);
            btndel.Click += new EventHandler(ButtonStatus);
            btnq.Click += new EventHandler(ButtonStatus);
            btnw.Click += new EventHandler(ButtonStatus);
            btne.Click += new EventHandler(ButtonStatus);
            btnr.Click += new EventHandler(ButtonStatus);
            btnt.Click += new EventHandler(ButtonStatus);
            btny.Click += new EventHandler(ButtonStatus);
            btnu.Click += new EventHandler(ButtonStatus);
            btnii.Click += new EventHandler(ButtonStatus);
            btno.Click += new EventHandler(ButtonStatus);
            btnp.Click += new EventHandler(ButtonStatus);
            btnyg.Click += new EventHandler(ButtonStatus);
            btniu.Click += new EventHandler(ButtonStatus);
            btna.Click += new EventHandler(ButtonStatus);
            btns.Click += new EventHandler(ButtonStatus);
            btnd.Click += new EventHandler(ButtonStatus);
            btnf.Click += new EventHandler(ButtonStatus);
            btng.Click += new EventHandler(ButtonStatus);
            btnh.Click += new EventHandler(ButtonStatus);
            btnj.Click += new EventHandler(ButtonStatus);
            btnk.Click += new EventHandler(ButtonStatus);
            btnl.Click += new EventHandler(ButtonStatus);
            btnis.Click += new EventHandler(ButtonStatus);
            btni.Click += new EventHandler(ButtonStatus);
            btnz.Click += new EventHandler(ButtonStatus);
            btnx.Click += new EventHandler(ButtonStatus);
            btnc.Click += new EventHandler(ButtonStatus);
            btnv.Click += new EventHandler(ButtonStatus);
            btnb.Click += new EventHandler(ButtonStatus);
            btnn.Click += new EventHandler(ButtonStatus);
            btnm.Click += new EventHandler(ButtonStatus);
            btnio.Click += new EventHandler(ButtonStatus);
            btnic.Click += new EventHandler(ButtonStatus);
            btnnokta.Click += new EventHandler(ButtonStatus);
            btnspc.Click += new EventHandler(ButtonStatus);



            OrderDetail();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OrderId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OrderId"].Value);
            orderState = (Entities.Enums.OrderStateEnum.OrderState)dataGridView1.CurrentRow.Cells["OrderState"].Value;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOrderNote_Click(object sender, EventArgs e)
        {
            if(orderState == (Entities.Enums.OrderStateEnum.OrderState)0)
            {
                var result = orderManager.OrderNoteAdd(OrderId, txtEmployeeCode.Text);
                if (result.Success)
                {
                    MyMessageBox.InfoMessageBox(result.Message);
                }
                else
                {
                    MyMessageBox.ErrorMessageBox(result.Message);
                }
            }
            else
            {
                MyMessageBox.ErrorMessageBox("Siparise Girilecek Not Mutfakta Gozukmeyecektir.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (orderState == (Entities.Enums.OrderStateEnum.OrderState)0)
            {
                var result = orderManager.Delete(OrderId);
                if (result.Success)
                {
                    MyMessageBox.InfoMessageBox(result.Message);
                }
                else
                {
                    MyMessageBox.ErrorMessageBox(result.Message);
                }
            }
            else
            {
                MyMessageBox.ErrorMessageBox("Siparis Durumu Degismis Siparisler Silinemez");
            }
        }
    }
}
