using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kviz
{
    public partial class Quiz : Form//hlavní okynko, samotný kvíz
    {
        public static QuestionsList Questions = new QuestionsList();//vytvori seznam otázek
        int buttonClicked = 0;//idnex odpovědi vybrané účastníkуь
        int index = 0;//index pro vypisováni otázek
        public static List<Question> ShuffledQuestions = new List<Question>();//list otázek

        public Quiz()
        {
            InitializeComponent();
            Questions.MyQuestions.Clear();
            Questions.ShuffledQuestions.Clear();//vyčistí použiváne listy
            Questions.LoadQuestions();//načte otázky ze souboru
            ShuffledQuestions = Questions.ShuffleQuestions(Questions.MyQuestions);//naplní list s otázkami
            WriteQuestions();//vypiše otázky
            Questions.score = 0;
            Questions.index = 0;//na začatku káždého pokusu mají být 0
        }


        private void WriteQuestions()//vypisuje otázky
        {
            try
            {
                Question currentQuestion = ShuffledQuestions[index];
                lblQuestionNumber.Text = $"Otázka {index + 1} z {Questions.TotalQuestionsCount}.";
                textBox1.Text = currentQuestion.QuestionText;
                btnAnswer1.Text = currentQuestion.Answers[0];
                btnAnswer2.Text = currentQuestion.Answers[1];
                btnAnswer3.Text = currentQuestion.Answers[2];
                btnAnswer4.Text = currentQuestion.Answers[3];
                index++;
            } catch (System.ArgumentOutOfRangeException)//pokud nejsou dalši otázky, přejde na okynko s vysledkem
            {
                Result result = new Result();
                result.Show();
                this.Close();
            }
        }


        private void btnAnswer1_Click(object sender, EventArgs e)
        {
            buttonClicked = 0;//zapiše index tlacitka
            Questions.ScoreCount(buttonClicked);//přepočitá score jestli odpověd je správná
            WriteQuestions();//vypiše dalši otázku
        }

        private void btnAnswer2_Click(object sender, EventArgs e)
        {
            buttonClicked = 1;
            Questions.ScoreCount(buttonClicked);
            WriteQuestions();
        }

        private void btnAnswer3_Click(object sender, EventArgs e)
        {
            buttonClicked = 2;
            Questions.ScoreCount(buttonClicked);
            WriteQuestions();
        }

        private void btnAnswer4_Click(object sender, EventArgs e)
        {
            buttonClicked = 3;
            Questions.ScoreCount(buttonClicked);
            WriteQuestions();
        }

    }
}
