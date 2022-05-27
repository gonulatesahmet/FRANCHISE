using Core.Entities;
using Core.Utilites.Results;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Core.Tools.DataGrivView
{
    public static class MyDataGridView
    {
        public static DataGridView createDataGridView(DataGridView dataGridView, string[] headers, int[] VisibleColumn)
        {
            
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.BackgroundColor = Color.FromArgb(244,255,248);                                                            //Arka Plan Rengini Degistirir
            dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(139,170,173);                                                 //Satir Arka Plan Rengini Degistirir
            dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(28,55,56);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77,72,71);                                        //Secili Satirin Arka Plan Rengini Degistirir
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(244,255,248);
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(48, 48, 48);                           //Baslik Rengi Degistirir
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 255, 255);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(48, 48, 48);                                    //Baslik Rengini Degistirir
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                                   //Satiri Tamamen Secer
            dataGridView.RowHeadersVisible = false;                                                                 //Ilk Sutunu Gizler
            dataGridView.AlternatingRowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;     //Satirlari Ortalar
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;       //Basliklari Ortalar
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;     //Baslik Yuksekligi Modu
            dataGridView.ColumnHeadersHeight = 50;                                                                  //Baslik Yuksekligini Ayarlar

            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dataGridView.RowTemplate.Resizable = DataGridViewTriState.True;

            dataGridView.RowTemplate.Height = 50;
            dataGridView.RowTemplate.MinimumHeight = 50;
            dataGridView.ReadOnly = true;

            for (int i = 0; i < headers.Length; i++)
            {
                dataGridView.Columns[i].HeaderText = headers[i];
            }
            for (int i = 0; i < VisibleColumn.Length; i++)
            {
                dataGridView.Columns[VisibleColumn[i]].Visible = false;
            }

            return dataGridView;
        }
    }
}
