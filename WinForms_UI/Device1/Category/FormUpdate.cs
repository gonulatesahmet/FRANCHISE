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

namespace WinForms_UI.Category
{
    public partial class FormUpdate : Form
    {
        Entities.Concrete.Category _category;
        CategoryManager categoryManager = new CategoryManager(new MsCategoryDal());
        public FormUpdate(Entities.Concrete.Category category)
        {
            _category = category;
            InitializeComponent();
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            txtName.Text = _category.CategoryName;
            txtCode.Text = _category.CategoryCode;
            txtDescription.Text = _category.CategoryDescription;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = categoryManager.Update(new Entities.Concrete.Category
            {
                CategoryId = _category.CategoryId,
                CategoryName = txtName.Text,
                CategoryCode = txtCode.Text,
                CategoryDescription = txtDescription.Text
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
