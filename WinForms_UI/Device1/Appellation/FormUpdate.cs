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

namespace WinForms_UI.Appellation
{
    public partial class FormUpdate : Form
    {
        Entities.Concrete.Appellation _appellation;
        AppellationManager appellationManager = new AppellationManager(new MsAppellationDal());

        public FormUpdate(Entities.Concrete.Appellation appellation)
        {
            _appellation = appellation;
            InitializeComponent();
        }
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            txtName.Text = _appellation.AppellationName;
            txtCode.Text = _appellation.AppellationCode;
            txtDescription.Text = _appellation.AppellationDescription;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            var result = appellationManager.Update(new Entities.Concrete.Appellation
            {
                AppellationName = txtName.Text,
                AppellationCode = txtCode.Text,
                AppellationDescription = txtDescription.Text,
                AppellationId = _appellation.AppellationId,
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
