using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exam.Answer;

namespace Exam
{
    internal abstract class Exam
    {
        public int Time { get; set; }
        public int NumOfQuestion { get; set; }
        public Question[] question { get; set; }

        protected Exam(int time, int numOfQuestion, Question[] questions)
        {
            Time = time;
            NumOfQuestion = numOfQuestion;
            question = questions;
        }
        public Exam() { }
        public abstract void ShowExam();
    }

    internal class FinalExam : Exam
    {
        public FinalExam(int time, int numOfQuestion, Question[] questions) : base(time, numOfQuestion, questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("Final Exam");
            Console.WriteLine("MCQ & TRUE|FALSE Questions");
            foreach (var ques in question)
            {
                ques.Show();
            }
        }
    }
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time, int numOfQuestion, Question[] questions) : base(time, numOfQuestion, questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("practical exam");
            Console.WriteLine("MCQ Questions");
            foreach (var ques in question)
            { 
                ques.Show();
                Console.WriteLine($"correct answer :{ques.RightAnswer}");
            }

        }
    }
}
