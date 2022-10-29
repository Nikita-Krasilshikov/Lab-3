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
        List<Student> students = new List<Student>() {
            new Student("Пупкин", "Василий", "Петрович", 10, 2, 1999, "Мужской", 1201, "Платная", 0, "Староста"),
            new Student("Пупкин", "Василий", "Петрович", 10, 2, 1999, "Мужской", 1002, "Бюджетная", 2, ""),
            new Student("Пупкин", "Василий", "Петрович", 10, 2, 1999, "Женский", 1103, "Платная", 3, ""),
            new Student("Пупкин", "Василий", "Петрович", 10, 2, 1999, "Мужской", 1004, "Платная", 0, ""),
            new Student("Пупкин", "Василий", "Петрович", 10, 2, 1999, "Мужской", 1005, "Бюджетная", 4, ""),
            new Student("Пупкин", "Василий", "Петрович", 10, 2, 1999, "Женский", 1006, "Платная", 1, ""),
            new Student("Пупкин", "Василий", "Петрович", 10, 2, 1999, "Мужской", 1008, "Платная", 2, ""),
            new Student("Пупкин", "Василий", "Петрович", 10, 2, 1999, "Женский", 1011, "Бюджетная", 0, ""),
            new Student("Пупкин", "Василий", "Петрович", 10, 2, 1999, "Женский", 13, "Платная", 1, ""),
            new Student("Пупкин", "Василий", "Петрович", 10, 2, 1999, "Мужской", 1045, "Бюджетная", 0, "")
        };

        public Form1()
        {
            InitializeComponent();
            studentsCountLabel.Text = $"Количество записей: {students.Count.ToString()}";
            genderComboBox.SelectedIndex = 0;
            foundationComboBox.SelectedIndex = 0;
        }

        private void showGroupListButton_Click(object sender, EventArgs e)
        {
            StudentsForm studentsForm = new StudentsForm(students);
            studentsForm.ShowDialog();
        }

        private void workingButton_Click(object sender, EventArgs e)
        {
            PaidForm paidForm = new PaidForm(students.Where(o => o.Foundation == "Платная").ToList());
            paidForm.ShowDialog();
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            int studentID;
            try
            {
                studentID = int.Parse(studentsIDTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Поле ID студента должно быть числом!", "Ошибка ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string firstName, lastName;
            int debts = 0;
            if (students.Count(o => o.StudentID == studentID) > 0)
            {
                MessageBox.Show("Студент с таким ID уже существует!", "Ошибка уникальности", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (debtsTextBox.Text.Trim().Length == 0)
            {
                try
                {
                    debts = int.Parse(debtsTextBox.Text.Trim());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Поле Кол-во долгов должно быть числом!", "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            firstName = firstNameTextBox.Text;
            if (firstName.Trim().Length == 0)
            {
                MessageBox.Show("Поле Имя студента не может быть пустым", "Ошибка Имени", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lastName = lastNameTextBox.Text;
            if (lastName.Trim().Length == 0)
            {
                MessageBox.Show("Поле Фамилия студента не может быть пустым", "Ошибка Фамилии", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            students.Add(new Student
            (
                firstName,
                lastName,
                middleNameTextBox.Text,
                birthDateDateTimePicker.Value.Day,
                birthDateDateTimePicker.Value.Month,
                birthDateDateTimePicker.Value.Year,
                genderComboBox.Text,
                studentID,
                foundationComboBox.Text,
                debts,
                noteTextBox.Text
            ));

            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            middleNameTextBox.Text = "";
            genderComboBox.Text = "";
            studentsIDTextBox.Text = "";
            foundationComboBox.Text = "";
            debtsTextBox.Text = "";
            noteTextBox.Text = "";

            studentsCountLabel.Text = $"Количество записей: {students.Count.ToString()}";
        }
    }
}
