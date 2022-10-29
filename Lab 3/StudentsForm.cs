﻿using System;
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
    public partial class StudentsForm : Form
    {
        public List<Student> students;
        public StudentsForm(List<Student> students)
        {
            InitializeComponent();
            studentsDataGridView.AutoGenerateColumns = false;
            students = students.OrderByDescending(o => o.StudentID).ToList();
            this.students = students;
            studentsDataGridView.DataSource = students;
        }
        public StudentsForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (studentsDataGridView.RowCount > 0)
            {
                Student student = (Student)studentsDataGridView.CurrentRow.DataBoundItem;
                students.Remove(student);
                studentsDataGridView.DataSource = null;
                studentsDataGridView.DataSource = students;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (studentsDataGridView.RowCount > 0)
            {
                Student student = (Student)studentsDataGridView.CurrentRow.DataBoundItem;
                EditForm ef = new EditForm(student);
                ef.Owner = this;
                if (ef.ShowDialog() == DialogResult.OK)
                {
                    studentsDataGridView.DataSource = null;
                    studentsDataGridView.DataSource = students;
                }
            }
        }
    }
}
