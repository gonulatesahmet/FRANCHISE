using Business.Concrete;
using Core.Tools.DataGrivView;
using DataAccess.Concrete.Mssql;
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

namespace WinForms_UI.Device2.Employee
{
    public partial class FormEmployee : Form
    {
        #region Entities
        DeviceDto _deviceDto;
        #endregion
        #region Manager
        EmployeeManager employeeManager = new EmployeeManager(new MsEmployeeDal());
        #endregion
        public FormEmployee(DeviceDto deviceDto)
        {
            _deviceDto = deviceDto;
            InitializeComponent();
        }
        private void EmployeeList(int branchId)
        {
            var result = employeeManager.EmployeeDtoGetByBranch(branchId);
            if (result.Success)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result.Data;
                string[] headers = { "", "Personel Ad", "Personel Soyad", "Personel Kimlik No", "Personel Doğum Tarih", "Personel Kod", "", "Şube Ad", "", "Unvan Ad", "Personel Telefon", "Personel Mail", "Personel Adres", "Personel Durum" };
                int[] visible = { 0, 6, 8 };
                MyDataGridView.createDataGridView(dataGridView1, headers, visible);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            EmployeeList(_deviceDto.BranchId);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
