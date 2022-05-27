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

namespace WinForms_UI.Area
{
    public partial class FormUpdate : Form
    {
        public int InstitutionId;
        Entities.Concrete.Area _area;
        AreaManager areaManager = new AreaManager(new MsAreaDal());
        BranchManager branchManager = new BranchManager(new MsBranchDal());
        public FormUpdate(Entities.Concrete.Area area)
        {
            _area = area;
            InitializeComponent();
        }
        private void FormUpdate_Load(object sender, EventArgs e)
        {
            txtName.Text = _area.AreaName;
            txtCode.Text = _area.AreaCode;
            txtDescription.Text = _area.AreaDescription;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = areaManager.Update(new Entities.Concrete.Area
            {
                AreaId = _area.AreaId,
                AreaName = txtName.Text,
                AreaCode = txtCode.Text,
                AreaDescription = txtDescription.Text
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
