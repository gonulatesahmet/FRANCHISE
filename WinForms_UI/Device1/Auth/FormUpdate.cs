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

namespace WinForms_UI.Auth
{
    public partial class FormUpdate : Form
    {
        public int AuthId;
        AuthManager authManager = new AuthManager(new MsAuthDal());
        public FormUpdate()
        {
            InitializeComponent();
        }

        private void FormUpdate_Load(object sender, EventArgs e)
        {
            var result = authManager.GetById(AuthId);
            if (result.Success)
            {
                txtName.Text = result.Data.AuthName;
                txtCode.Text = result.Data.AuthCode;
                txtDescription.Text = result.Data.AuthDescription;
            }
            else
            {
                MyMessageBox.ErrorMessageBox(Messages.UpdatedFailed);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = authManager.Update(new Entities.Concrete.Auth
            {
                AuthId = AuthId,
                AuthName = txtName.Text,
                AuthCode = txtCode.Text,
                AuthDescription = txtDescription.Text
            });
            if (result.Success)
            {
                MyMessageBox.InfoMessageBox(Messages.AuthUpdated);
                this.Close();
            }
            else
            {
                MyMessageBox.ErrorMessageBox(Messages.UpdatedFailed);
                this.Close();
            }
        }
    }
}
