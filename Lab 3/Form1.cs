using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3
{
    public partial class Form1 : Form
    {
        List<Student> students;

        public Form1()
        {
            InitializeComponent();
            students = new List<Student>();
        }

        private void showGroupListButton_Click(object sender, EventArgs e)
        {
            StudentsForm studentsForm = new StudentsForm(students);
            studentsForm.ShowDialog();
        }

        private void workingButton_Click(object sender, EventArgs e)
        {
            PaidForm paidForm = new PaidForm();
            paidForm.ShowDialog();
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            // TODO: Обработка ошибок
            // TODO: Обнуление после добавления
            // TODO: Проверка уникальности по StudentsID
            students.Add(new Student
            {
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                MiddleName = middleNameTextBox.Text,
                BirthDay = birthDateDateTimePicker.Value.Day,
                BirthMonth = birthDateDateTimePicker.Value.Month,
                BirthYear = birthDateDateTimePicker.Value.Year,
                Gender = genderComboBox.Text,
                StudentsID = int.Parse(studentsIDTextBox.Text),
                Foundation = foundationComboBox.Text,
                Debts = int.Parse(debtsTextBox.Text),
                Note = noteTextBox.Text
            });

            studentsCountLabel.Text = $"Количество записей: {students.Count.ToString()}";
        }
    }
}
