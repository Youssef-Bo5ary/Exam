using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    internal class Subject
    {
        public int SubID {  get; set; }
        public string SubName {  get; set; }
        public Exam Exam {  get; set; }

        public Subject(int subID, string subName)
        {
            SubID = subID;
            SubName = subName;
        }

        public void createExam(Exam exam)
        {
            Exam = exam;
        }
        public override string ToString()
        {
            return $"SubjectID: {SubID}, SubName: {SubName}";
        }
    }
}
