using Business.Concrete;
using Business.Constants;
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

namespace WinForms_UI.Auth
{
    
    public partial class FormAuth : Form
    {
        public int InstitutionId;
        public int AuthId;
        public bool AuthState;
        AuthManager authManager = new AuthManager(new MsAuthDal());
        public FormAuth()
        {
            InitializeComponent();
        }
        private void ButtonStatus()
        {
            if (AuthId == 0)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnChangeState.Enabled = false;
            }
            else
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnChangeState.Enabled = true;
            }
        }
        private void Clear()
        {
            AuthId = 0;
            AuthState = false;
            ButtonStatus();
            txtName.Text = null;
            txtCode.Text = null;
            txtDescription.Text = null;
        }
        private void AuthList()
        {
            var result = authManager.GetAll(InstitutionId);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "Yetki Ad", "Yetki Kod", "Yetki Açıklama", "Yetki Durum" };
                int[] visible = { 0 };
                MyDataGridView.createDataGridView(dataGridView1,headers,visible);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(result.Message);
            }
        }
        private void FormAuth_Load(object sender, EventArgs e)
        {
            Clear();
            ButtonStatus();
            AuthList();
        }

        //Secili Yetkiyi Siler
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            var result = authManager.Delete(AuthId);
            if (result.Success)
            {
                Clear();
                AuthList();
                MyMessageBox.InfoMessageBox(Messages.AuthDeleted);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(Messages.DeletedFailed);
            }
        }
        //Yeni Yetki Ekler
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            var result = authManager.Add(new Entities.Concrete.Auth
            {
                AuthName = txtName.Text,
                AuthCode = txtCode.Text,
                AuthDescription = txtDescription.Text,
                AuthState = true
            });
            if (result.Success)
            {
                Clear();
                AuthList();
                MyMessageBox.InfoMessageBox(Messages.AuthAdded);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(Messages.AddedFailed);
            }
        }
        //Yetki Guncelleme Sayfasini Acar
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            FormUpdate frm = new FormUpdate();
            frm.AuthId = AuthId;
            frm.ShowDialog();
            Clear();
            AuthList();
        }
        //Yetki Durumunu Degistirir
        private void btnChangeState_Click_1(object sender, EventArgs e)
        {
            var result = authManager.ChangeState(AuthId, AuthState);
            if (result.Success)
            {
                Clear();
                AuthList();
                MyMessageBox.InfoMessageBox(Messages.AuthChangeState);
            }
            else
            {
                MyMessageBox.ErrorMessageBox(Messages.ChangeStatedFailed);
            }
        }
        //Sayfayi Kapat
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //Yetki Satir Secimi
        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            AuthId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AuthId"].Value);
            AuthState = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["AuthState"].Value);
            ButtonStatus();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {

            }
            if(tabControl1.SelectedIndex == 1)
            {
                CbbAuthList();
            }
            if(tabControl1.SelectedIndex == 2)
            {

            }
        }

        private void CbbAuthList()
        {
            var result = authManager.CbbAuthGetAll(true);
            if (result.Success)
            {
                cbbAuth.DataSource = null;
                cbbAuth.DataSource = result.Data;
                cbbAuth.DisplayMember = "AuthName";
                cbbAuth.ValueMember = "AuthId";
            }
        }
        
    }
}
