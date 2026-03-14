using System;
using System.Text;

namespace CorporateInfoPlatformsLab1
{
    public class Student
    {
        private Person _personInfo;
        private Education _educationForm;
        private int _groupNumber;
        private Exam[] _examCollection;

        public Student(Person personInfo, Education educationForm, int groupNumber)
        {
            _personInfo = personInfo;
            _educationForm = educationForm;
            _groupNumber = groupNumber;
            _examCollection = Array.Empty<Exam>();
        }

        public Student()
            : this(new Person(), Education.Bachelor, 121)
        {
        }

        public Person PersonInfo
        {
            get => _personInfo;
            init => _personInfo = value;
        }

        public Education EducationForm
        {
            get => _educationForm;
            init => _educationForm = value;
        }

        public int GroupNumber
        {
            get => _groupNumber;
            init => _groupNumber = value;
        }

        public Exam[] Exams
        {
            get => _examCollection;
            init => _examCollection = value ?? Array.Empty<Exam>();
        }

        public double AverageMark
        {
            get
            {
                if (_examCollection.Length == 0)
                    return 0;

                int total = 0;
                foreach (Exam exam in _examCollection)
                {
                    total += exam.Result;
                }

                return (double)total / _examCollection.Length;
            }
        }

        public bool this[Education form]
        {
            get => _educationForm == form;
        }

        public void AddExams(params Exam[] newItems)
        {
            if (newItems == null || newItems.Length == 0)
                return;

            int oldLength = _examCollection.Length;
            Array.Resize(ref _examCollection, oldLength + newItems.Length);

            for (int i = 0; i < newItems.Length; i++)
            {
                _examCollection[oldLength + i] = newItems[i];
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Student: {_personInfo}");
            sb.AppendLine($"Education: {_educationForm}");
            sb.AppendLine($"Group: {_groupNumber}");
            sb.AppendLine("Exams:");

            if (_examCollection.Length == 0)
            {
                sb.AppendLine("  no exams");
            }
            else
            {
                for (int i = 0; i < _examCollection.Length; i++)
                {
                    sb.AppendLine($"  {i + 1}) {_examCollection[i]}");
                }
            }

            sb.Append($"Average mark: {AverageMark:F2}");

            return sb.ToString();
        }

        public virtual string ToShortString()
        {
            return $"{_personInfo.ToShortString()}, {_educationForm}, group {_groupNumber}, average = {AverageMark:F2}";
        }
    }
}