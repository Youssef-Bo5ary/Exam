using static Exam.Answer;

namespace Exam
{
    internal class Program
    {

       
        static void Main(string[] args)
        {
            //int T; int N;
            //Console.WriteLine("Enter type of Exam 1 for practical | 2 for Final");
            //int x = int .Parse(Console.ReadLine());
            //if(x==1) 
            //{
            //    PracticalExam practicalExam = new PracticalExam(T, N);

            Console.WriteLine("Enter Subject ID:");
            int subjectId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Subject Name:");
            string subjectName = Console.ReadLine();

            Subject subject = new Subject(subjectId, subjectName);

            Console.WriteLine("Choose Exam Type (1: Final, 2: Practical):");
            int examType = int.Parse(Console.ReadLine());

            List<Question> questions = new List<Question>();
            Console.WriteLine("Enter Number of Questions:");
            int numberOfQuestions = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"Enter details for Question {i + 1}:");

                Console.WriteLine("Enter Question Header:");
                string header = Console.ReadLine();

                Console.WriteLine("Enter Question Body:");
                string body = Console.ReadLine();

                Console.WriteLine("Enter Question Mark:");
                int mark = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Number of Answers:");
                int numberOfAnswers = int.Parse(Console.ReadLine());

                List<Answer> answerList = new List<Answer>();
                for (int j = 0; j < numberOfAnswers; j++)
                {
                    Console.WriteLine($"Enter details for Answer {j + 1}:");

                    Console.WriteLine("Enter Answer ID:");
                    int answerId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Answer Text:");
                    string answerText = Console.ReadLine();

                    answerList.Add(new Answer(answerId, answerText));
                }

                Console.WriteLine("Enter Right Answer ID:");
                int rightAnswerId = int.Parse(Console.ReadLine());

                Answer rightAnswer = answerList.Find(a => a.AnswerId == rightAnswerId);

                Question question;
                if (examType == 1)
                {
                    Console.WriteLine("Choose Question Type (1: True/False, 2: MCQ):");
                    int questionType = int.Parse(Console.ReadLine());

                    if (questionType == 1)
                    {
                        question = new TrueFalse(header, body, mark, answerList, rightAnswer);
                    }
                    else
                    {
                        question = new MCQ(header, body, mark, answerList, rightAnswer);
                    }
                }
                else
                {
                    question = new MCQ(header, body, mark, answerList, rightAnswer);
                }

                questions.Add(question);
            }

            Console.WriteLine("Enter Exam Time (in minutes):");
            int examTime = int.Parse(Console.ReadLine());

            Exam exam;
            if (examType == 1)
            {
                exam = new FinalExam(examTime, numberOfQuestions, questions);
            }
            else
            {
                exam = new PracticalExam(examTime, numberOfQuestions, questions);
            }

            subject.createExam(exam);

            // Display the exam
            subject.Exam.ShowExam();
        }
    }
}
