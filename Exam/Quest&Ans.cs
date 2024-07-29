using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }

        public Answer(int answerID, string answerText)
        {
            AnswerID = answerID;
            AnswerText = answerText;

        }
        public override string ToString()
        {
            return $"AnswerID: {AnswerID}, AnswerText: {AnswerText}";
        }

        public abstract class Question
        {
            public string Header { get; set; }
            public string Body { get; set; }
            public int Mark { get; set; }
            public Answer[] answer { get; set; }
            public string RightAnswer { get; set; }


            public Question(string header, string body, int mark, Answer[] answer, string rightAnswer)
            {
                Header = header;
                Body = body;
                Mark = mark;
                this.answer = answer;
                RightAnswer = rightAnswer;
            }
            public abstract void Show();

        }
        public class MCQ : Question
        {
            public MCQ(string header, string body, int mark, Answer[] answer, string rightAnswer, Answer[] choices) : base(header, body, mark, answer, rightAnswer)
            {

            }

            public override void Show()
            {
                Console.WriteLine($"MCQ: {Header}");
                Console.Write(Body);
                Console.WriteLine($"the mark: {Mark}");
                foreach (var ans in answer)
                {
                    Console.WriteLine(ans);
                }
            }
        }
        public class TrueFalse : Question
        {
            public bool IsTrue { get; set; }
            public TrueFalse(string header, string body, int mark, Answer[] answer, string rightAnswer, bool isTrue) : base(header, body, mark, answer, rightAnswer)
            {
                IsTrue = isTrue;
            }

            public override void Show()
            {
                Console.WriteLine($"True/False: {Header}");
                Console.Write(Body);
                Console.WriteLine($"the mark: {Mark}");
                Console.WriteLine(IsTrue ? "True" : "False");

            }
        }
    }
}