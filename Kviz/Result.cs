using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Windows.Forms;

namespace Kviz
{
    public partial class Result : Form//okynko s vysledkem pokusu
    {
        public static string result;
        public Result()
        {
            InitializeComponent();
            result = $"{Quiz.Questions.score}/{Quiz.Questions.TotalQuestionsCount}";
            txtResult.Text = $"Počet správných odpovědi je: {result}";//napiše pro uživatele jeho výsledek
            HistoryList.addHistoryElemnts();//přidá výsledek do historie
        }
        



        private void btnNewGame_Click(object sender, EventArgs e)//tlačitko pro přechod na startovou stránku
        {
            Start start = new Start();
            start.Show();
            this.Hide();
        }

        private void btnHistory_Click(object sender, EventArgs e)//tlačitko pro přechod na stránku historie
        {
            History history = new History();
            history.Show();
            this.Hide();
        }
    }
}
