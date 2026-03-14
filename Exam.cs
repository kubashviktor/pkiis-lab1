using System;

namespace CorporateInfoPlatformsLab1
{
    public class Exam
    {
        public string SubjectName { get; set; }
        public int Result { get; set; }
        public DateTime DateOfExam { get; set; }

        public Exam(string subjectName, int result, DateTime dateOfExam)
        {
            SubjectName = subjectName;
            Result = result;
            DateOfExam = dateOfExam;
        }

        public Exam()
            : this("Computer Science", 80, new DateTime(2025, 1, 10))
        {
        }

        public override string ToString()
        {
            return $"Subject: {SubjectName}, Mark: {Result}, Date: {DateOfExam:dd.MM.yyyy}";
        }
    }
}