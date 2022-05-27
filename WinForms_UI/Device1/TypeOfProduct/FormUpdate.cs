using Business.Concrete;
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

namespace WinForms_UI.Device1.TypeOfProduct
{
    public partial class FormUpdate : Form
    {
        Entities.Concrete.TypeOfProduct _typeOfProduct;
        TypeOfProductManager typeOfProductManager = new TypeOfProductManager(new MsTypeOfProductDal());
        public FormUpdate(Entities.Concrete.TypeOfProduct typeOfProduct)
        {
            _typeOfProduct = typeOfProduct;
            InitializeComponent();
        }
        public class CbbDisplay
        {
            public bool Value { get; set; }
            public string Key { get; set; }
        }
        public class CbbPrinter
        {
            public bool Value { get; set; }
            public string Key { get; set; }
        }
        private void cbbTrueOrFalseList()
        {
            List<CbbDisplay> cbbDisplayList = new List<CbbDisplay>()
            {
                new CbbDisplay { Value = false, Key = "Hayır" },
                new CbbDisplay { Value = true, Key = "Evet" }
            };
            List<CbbPrinter> cbbPrinterList = new List<CbbPrinter>()
            {
                new CbbPrinter { Value = false, Key = "Hayır" },
                new CbbPrinter { Value = true, Key = "Evet" }
            };
            cbbDisplay.DataSource = cbbDisplayList;
            cbbPrinter.DataSource = cbbPrinterList;
            cbbDisplay.DisplayMember = "Key";
            cbbPrinter.DisplayMember = "Key";
            cbbDisplay.ValueMember = "Value";
            cbbPrinter.ValueMember = "Value";
        }
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            cbbTrueOrFalseList();
            txtName.Text = _typeOfProduct.TypeOfProductName;
            txtCode.Text = _typeOfProduct.TypeOfProductCode;
            txtDescription.Text = _typeOfProduct.TypeOfProductDescription;
            cbbDisplay.SelectedValue = _typeOfProduct.TypeOfProductDisplay;
            cbbPrinter.SelectedValue = _typeOfProduct.TypeOfProductPrinter;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = typeOfProductManager.Update(new Entities.Concrete.TypeOfProduct
            {
                TypeOfProductName = txtName.Text,
                TypeOfProductCode = txtCode.Text,
                TypeOfProductDescription = txtDescription.Text,
                TypeOfProductDisplay = Convert.ToBoolean(cbbDisplay.SelectedValue),
                TypeOfProductPrinter = Convert.ToBoolean(cbbPrinter.SelectedValue),
                TypeOfProductId = _typeOfProduct.TypeOfProductId
            });
            if (result.Success)
            {
                MyMessageBox.InfoMessageBox(result.Message);
                this.Close();
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
                this.Close();
            }
        }
    }
}
