using System;

namespace CorporateInfoPlatformsLab1
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
        }

        public Person()
            : this("Ivan", "Koval", new DateTime(2004, 6, 15))
        {
        }

        public string Name
        {
            get => _firstName;
            init => _firstName = value;
        }

        public string Surname
        {
            get => _lastName;
            init => _lastName = value;
        }

        public DateTime BirthDate
        {
            get => _dateOfBirth;
            init => _dateOfBirth = value;
        }

        public int BirthYear
        {
            get => _dateOfBirth.Year;
            set
            {
                int validDay = Math.Min(_dateOfBirth.Day, DateTime.DaysInMonth(value, _dateOfBirth.Month));
                _dateOfBirth = new DateTime(value, _dateOfBirth.Month, validDay);
            }
        }

        public override string ToString()
        {
            return $"{_lastName} {_firstName}, date of birth: {_dateOfBirth:dd.MM.yyyy}";
        }

        public virtual string ToShortString()
        {
            return $"{_lastName} {_firstName}";
        }
    }
}