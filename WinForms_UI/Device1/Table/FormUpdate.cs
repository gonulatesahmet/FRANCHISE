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

namespace WinForms_UI.Table
{
    public partial class FormUpdate : Form
    {
        Entities.Concrete.Table _table;
        TableManager tableManager = new TableManager(new MsTableDal());
        AreaManager areaManager = new AreaManager(new MsAreaDal());
        public FormUpdate(Entities.Concrete.Table table)
        {
            _table = table;
            InitializeComponent();
        }
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            txtName.Text = _table.TableName;
            txtCode.Text = _table.TableCode;
            txtDescription.Text = _table.TableDescription;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = tableManager.Update(new Entities.Concrete.Table
            {
                TableId = _table.TableId,
                TableName = txtName.Text,
                TableCode = txtCode.Text,
                TableDescription = txtDescription.Text
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
