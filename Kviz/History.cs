using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kviz
{
    public partial class History : Form//okynko pro zobrazeni historie
    {
        public List<HistoryElement> historyList { get; set; }

        public History()
        {
            InitializeComponent();
            historyList = HistoryList.deserialize();//naplni historyList data
            dgvHistory.AutoGenerateColumns = true;
            dgvHistory.ColumnHeadersVisible = false;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.Width = 240;
            dgvHistory.DataBindingComplete += (sender, e) =>
            {
                dgvHistory.Columns["UserName"].Width = 90;
                dgvHistory.Columns["DateAndTime"].Width = 100;
                dgvHistory.Columns["Score"].Width = 40;
            };//urči jak bude vypadat tabulka
            dgvHistory.DataSource = historyList;//priradí data do dgv
        }

        private void btnStartPage_Click(object sender, EventArgs e)//tlačitko pro přechod na hlávní stránku
        {
            Start start = new Start();
            start.Show();
            this.Hide();
        }

    }
}

