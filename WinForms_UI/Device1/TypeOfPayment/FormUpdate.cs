using Business.Concrete;
using Business.Constants;
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

namespace WinForms_UI.TypeOfPayment
{
    public partial class FormUpdate : Form
    {
        Entities.Concrete.TypeOfPayment _typeOfPayment;
        TypeOfPaymentManager typeOfPaymentManager = new TypeOfPaymentManager(new MsTypeOfPaymentDal());
        public FormUpdate(Entities.Concrete.TypeOfPayment typeOfPayment)
        {
            _typeOfPayment = typeOfPayment;
            InitializeComponent();
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            txtName.Text = _typeOfPayment.TypeOfPaymentName;
            txtCode.Text = _typeOfPayment.TypeOfPaymentCode;
            txtDescription.Text = _typeOfPayment.TypeOfPaymentDescription;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = typeOfPaymentManager.Update(new Entities.Concrete.TypeOfPayment
            {
                TypeOfPaymentName = txtName.Text,
                TypeOfPaymentCode = txtCode.Text,
                TypeOfPaymentDescription = txtDescription.Text,
                TypeOfPaymentId = _typeOfPayment.TypeOfPaymentId
            });
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
    }
}
