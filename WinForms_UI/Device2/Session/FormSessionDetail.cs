using Business.Concrete;
using Business.Tools.Button;
using Core.Tools.DataGrivView;
using Core.Tools.MyMessageBox;
using DataAccess.Concrete.Mssql;
using Entities.Concrete;
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
    public partial class FormSessionDetail : Form
    {
        #region Entities
        DeviceDto _deviceDto;
        public int ProductId;
        public int EmployeeId;
        public int TableId;
        public int DiscountId;

        public int SessionId;

        public string EmployeeName;
        public string TableName;

        #endregion
        #region Manager
        CategoryManager categoryManager = new CategoryManager(new MsCategoryDal());
        BranchProductManager branchProductManager = new BranchProductManager(new MsBranchProductDal());
        BranchDiscountManager branchDiscountManager = new BranchDiscountManager(new MsBranchDiscountDal());
        BranchDiscountContentManager branchDiscountContentManager = new BranchDiscountContentManager(new MsBranchDiscountContentDal());
        BranchDiscountContentBranchProductManager branchDiscountContentBranchProductManager = new BranchDiscountContentBranchProductManager(new MsBranchDiscountContentBranchProductDal());
        SessionManager sessionManager = new SessionManager(new MsSessionDal());
        OrderManager orderManager = new OrderManager(new MsOrderDal());
        TableManager tableManager = new TableManager(new MsTableDal());
        #endregion
        public FormSessionDetail(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        //Order Tablosunda Onaylanacak Siparisleri Onaylar
        private void OrderUpdate(int orderId)
        {
            orderManager.OrderUpdate(orderId, (Entities.Enums.OrderStateEnum.OrderState)1);
        }
        //Siparisleri Listeler
        private void OrderList(int SessionId)
        {
            if (SessionId != 0)
            {
                var result = orderManager.OrderDtoGetBySession(SessionId);
                if (result.Success)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = result.Data;
                    string[] headers = { "OrderId", "SessionId", "Siparis Tarih", "İndirim İçerik Id", "İndirim İçerik Ad", "Sube Urun Id", "Urun Ad", "Adet", "Birim Fiyat", "Total Tutar", "Siparis Tur Id", "Siparis Tur Ad", "Employee Id", "Calisan Ad", "Sube Id", "Sube Ad", "Siparis Durum" };
                    int[] visibles = { 0, 1, 2, 3, 5, 10, 11, 12, 13, 14, 15 };
                    MyDataGridView.createDataGridView(dataGridView1, headers, visibles);
                    dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    
                }
            }

        }
        //Yeni Session Ekler
        private void SessionAdd()
        {
            var result = sessionManager.SessionAdd(new Entities.Concrete.Session
            {
                StartDate = DateTime.Now,
                TotalPrice = 0,
                TableId = TableId,
                BranchId = _deviceDto.BranchId,
                SessionState = true
            });
            if (result.Success)
            {
                SessionId = result.Data;
                SessionControl(SessionId);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        //Session Olup Olmadigini Kontrol Eder SessionId'ye Gore Buton Durumunu Degistirir
        private void SessionControl(int sessionId)
        {
            if (sessionId == 0)
            {
                btnSessionState.Enabled = true;
                btnSessionState.Text = "Masayi Ac";
            }
            else
            {
                btnSessionState.Enabled = false;
                btnSessionState.Text = "Masa Acik";
            }
        }
        //Masa Display Bilgisini Degistirir
        private void TableChangeDisplay(int tableId, bool display)
        {
            tableManager.TableChangeDisplay(tableId, display);
        }
        //Kategori Listeler
        private void CategoryList()
        {
            var result = categoryManager.CbbCategoryGetAll(true);
            if (result.Success)
            {
                for (int i = 0; i < result.Data.Count; i++)
                {
                    Button btnCategory = new Button();
                    btnCategory.Name = "btnCategory" + result.Data[i].CategoryId.ToString();
                    btnCategory.Text = result.Data[i].CategoryName;
                    btnCategory.Width = 168;
                    btnCategory.Height = 51;

                    btnCategory.FlatStyle = FlatStyle.Flat;
                    btnCategory.FlatAppearance.BorderSize = 0;
                    btnCategory.BackColor = Color.FromArgb(38, 64, 139);
                    btnCategory.ForeColor = Color.FromArgb(166, 207, 213);
                    btnCategory.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Italic, GraphicsUnit.Point, 1, false);


                    flowLayoutPanel2.Controls.Add(btnCategory);
                    btnCategory.Click += (sender, e) =>
                    {
                        BranchProductList(_deviceDto.BranchId, Convert.ToInt32(((Button)sender).Name.Remove(0, 11)));
                    };
                }
            }
        }
        //Sube Urunleri Kategoriye Gore Listeler
        private void BranchProductList(int branchId, int categoryId)
        {
            var result = branchProductManager.BranchProductDtoGetByCategory(branchId, categoryId, true);
            if (result.Success)
            {
                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < result.Data.Count; i++)
                {
                    BranchProductButton btn = new BranchProductButton
                    {
                        Name = "btnProduct" + result.Data[i].BranchProductId.ToString(),
                        Text = result.Data[i].ProductName + Environment.NewLine + result.Data[i].BranchProductPrice.ToString(),
                        BranchProductId = result.Data[i].BranchProductId,
                        BranchProductPrice = result.Data[i].BranchProductPrice,
                        ProductName = result.Data[i].ProductName,
                        Width = 168,
                        Height = 75,
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.FromArgb(38, 64, 139),
                        ForeColor = Color.FromArgb(166, 207, 213),
                        Font = new Font("Microsoft Sans Serif", 15, FontStyle.Italic, GraphicsUnit.Point, 1, false),
                    };
                    btn.FlatAppearance.BorderSize = 0;

                    flowLayoutPanel1.Controls.Add(btn);
                    btn.Click += (sender, e) =>
                      {
                          if (SessionId != 0)
                          {
                              orderManager.Add(new Entities.Concrete.Order
                              {
                                  EmployeeId = EmployeeId,
                                  OrderDate = DateTime.Now,
                                  BranchProductId = ((BranchProductButton)sender).BranchProductId,
                                  BranchDiscountContentId = 0,
                                  Piece = 1,
                                  OrderState = 0,
                                  SessionId = SessionId,
                                  TotalPrice = ((BranchProductButton)sender).BranchProductPrice,
                                  TypeOfOrderId = 1,
                                  BranchId = _deviceDto.BranchId
                              });
                              OrderList(SessionId);
                          }
                          else
                          {
                              MyMessageBox.ErrorMessageBox("Oturum Acik Degil");
                          }
                      };
                }
            }
        }
        //Sube Indirimleri Listeler
        private void BranchDiscountList(int branchId)
        {
            flowLayoutPanel4.Controls.Clear();
            var result = branchDiscountManager.CbbBranchDiscountGetByBranch(branchId, true);
            if (result.Success)
            {
                for (int i = 0; i < result.Data.Count; i++)
                {
                    Button btn = new Button();
                    btn.Name = "btnDiscount" + result.Data[i].BranchDiscountId.ToString();
                    btn.Text = result.Data[i].BranchDiscountName;
                    btn.Width = 168;
                    btn.Height = 51;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.FromArgb(38, 64, 139);
                    btn.ForeColor = Color.FromArgb(166, 207, 213);
                    btn.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Italic, GraphicsUnit.Point, 1, false);
                    flowLayoutPanel4.Controls.Add(btn);
                    btn.Click += (sender, e) =>
                    {
                        BranchDiscountContentList(Convert.ToInt32(((Button)sender).Name.Remove(0, 11)));
                    };
                }
            }
        }
        //Sube Indirim Icerikleri Listeler
        private void BranchDiscountContentList(int branchDiscountId)
        {
            var result = branchDiscountContentManager.CbbBranchDiscountContentGetByBranchDiscount(branchDiscountId, true);
            if (result.Success)
            {
                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < result.Data.Count; i++)
                {
                    BranchDiscountContentButton btn = new BranchDiscountContentButton
                    {
                        Name = "btnBranchDiscountContent" + result.Data[i].BranchDiscountContentId.ToString(),
                        Text = result.Data[i].BranchDiscountContentName,
                        Width = 168,
                        Height = 75,
                        FlatStyle=FlatStyle.Flat,
                        BackColor = Color.FromArgb(38, 64, 139),
                        ForeColor = Color.FromArgb(166, 207, 213),
                        Font = new Font("Microsoft Sans Serif", 15, FontStyle.Italic, GraphicsUnit.Point, 1, false),
                        BranchDiscountContentId = result.Data[i].BranchDiscountContentId
                    };
                    btn.FlatAppearance.BorderSize = 0;
                    flowLayoutPanel1.Controls.Add(btn);
                    btn.Click += (sender, e) =>
                      {
                          if (SessionId != 0)
                          {
                              var branchDiscountContentBranchProduct = branchDiscountContentBranchProductManager.BranchDiscountContentBranchProductDtoGetByBranchDiscountContent(((BranchDiscountContentButton)sender).BranchDiscountContentId, true);
                              foreach (var item in branchDiscountContentBranchProduct.Data)
                              {
                                  orderManager.Add(new Entities.Concrete.Order
                                  {
                                      EmployeeId = EmployeeId,
                                      OrderDate = DateTime.Now,
                                      BranchProductId = item.BranchProductId,
                                      BranchDiscountContentId = ((BranchDiscountContentButton)sender).BranchDiscountContentId,
                                      Piece = 1,
                                      OrderState = 0,
                                      SessionId = SessionId,
                                      TotalPrice = item.BranchDiscountContentBranchProductPrice,
                                      TypeOfOrderId = 1,
                                      BranchId = _deviceDto.BranchId
                                  });
                              }
                              OrderList(SessionId);
                          }
                      };
                }
            }
        }

        private void FormSessionDetail_Load(object sender, EventArgs e)
        {
            SessionControl(SessionId);
            OrderList(SessionId);
            lblBranch.Text = _deviceDto.BranchName;
            lblDevice.Text = _deviceDto.DeviceName;
            lblEmployee.Text = EmployeeName;
            lblTable.Text = TableName;
            lblDateTimeNow.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
            CategoryList();
            BranchDiscountList(_deviceDto.BranchId);
        }
        //Session Ekler - Masa Display'i Degistirir
        private void btnSessionState_Click(object sender, EventArgs e)
        {
            SessionAdd();
            TableChangeDisplay(TableId, true);
        }

        //Onaylanacak Siparis Varsa Order Tablosundan Siler - Sayfayi Kapatir
        private void btnCancel_Click(object sender, EventArgs e)
        {
            orderManager.OrderDeleteByState(SessionId, (Entities.Enums.OrderStateEnum.OrderState)0);
            this.Close();
        }
        //Durumu 0 Olan Siparisleri Listeler - Gonderilen Id'ye Gore OrderState Degisir - Sayfayi Kapatir
        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = orderManager.OrderGetByState(SessionId, 0);
            if (result.Success)
            {
                for (int i = 0; i < result.Data.Count; i++)
                {
                    OrderUpdate(result.Data[i].OrderId);
                }
            }
            this.Close();
        }

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            FormOrderDetail frm = new FormOrderDetail();
            frm.SessionId = SessionId;
            frm.ShowDialog();
            OrderList(SessionId);
        }

        private void btnMoveTheTable_Click(object sender, EventArgs e)
        {
            FormMoveTheTable frm = new FormMoveTheTable(_deviceDto);
            frm.SessionId = SessionId;
            frm.ShowDialog();

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.flowLayoutPanel2.ClientRectangle, Color.FromArgb(38, 64, 139), ButtonBorderStyle.Solid);
        }
    }
}
