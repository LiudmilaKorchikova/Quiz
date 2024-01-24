using System;
using System.Collections.Generic;
using System.IO;

namespace Kviz
{
    public class QuestionsList
    {
        public int TotalQuestionsCount {  get; set; }

        public List<Question> MyQuestions {  get; set; }

        public List<Question> ShuffledQuestions {  get; set; }

        public QuestionsList()
        {
            MyQuestions = new List<Question>();
            ShuffledQuestions = new List<Question>();
            LoadQuestions();
            ShuffledQuestions = ShuffleQuestions(MyQuestions);
            TotalQuestionsCount = MyQuestions.Count;
        }


        public void LoadQuestions()//Načitá otázky z textového souboury
        {
            string[] Lines = File.ReadAllLines("Questions.txt");
            for (int i = 0; i < Lines.Length; i += 6)
            {
                Question question = new Question
                {
                    QuestionText = Lines[i],
                    Answers = new List<string> { Lines[i + 1], Lines[i + 2], Lines[i + 3], Lines[i + 4], },
                    CorrectAnswer = Lines[i + 5]
                };
                MyQuestions.Add(question);
            }
            TotalQuestionsCount = MyQuestions.Count;
        }


        public int index = 0;
        public int score = 0;

        public void ScoreCount(int clicked)//spočitává správné odpovědi
        {
            Question currentQuestion = ShuffledQuestions[index];
            if (currentQuestion.Answers[clicked] == currentQuestion.CorrectAnswer)
            {
                score++;
            }
            index++;
        }



        public List<Question> ShuffleQuestions(List<Question> list)//namichá otázky
        {
            ShuffledQuestions = new List<Question>(list);
            Random rng = new Random();
            int n = ShuffledQuestions.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Question value = ShuffledQuestions[k];
                ShuffledQuestions[k] = ShuffledQuestions[n];
                ShuffledQuestions[n] = value;
            }
            return ShuffledQuestions;
        }

    }
}
