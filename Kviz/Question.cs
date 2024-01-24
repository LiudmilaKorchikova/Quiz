using System.Collections.Generic;

namespace Kviz
{
    public class Question//jednotna otázka, použivá se v QuestionsList
    {
        public string QuestionText { get; set; }
        public List<string> Answers { get; set; }
        public string CorrectAnswer { get; set; }

    }
}
