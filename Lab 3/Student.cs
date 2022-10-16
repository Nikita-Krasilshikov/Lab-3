using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string middleName;
        private int birthDay;
        private int birthMonth;
        private int birthYear;
        private string gender;
        private int studentsID;
        private string foundation;
        private int debts;
        private string note;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public int BirthDay { get => birthDay; set => birthDay = value; }
        public int BirthMonth { get => birthMonth; set => birthMonth = value; }
        public int BirthYear { get => birthYear; set => birthYear = value; }
        public string Gender { get => gender; set => gender = value; }
        public int StudentsID { get => studentsID; set => studentsID = value; }
        public string Foundation { get => foundation; set => foundation = value; }
        public int Debts { get => debts; set => debts = value; }
        public string Note { get => note; set => note = value; }
        public string FullName { get => $"{firstName} {lastName} {middleName}"; }
        public string BirthDate { get => $"{birthDay}.{birthMonth}.{birthYear}"; }
    }
}
