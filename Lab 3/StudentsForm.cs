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
    public partial class StudentsForm : Form
    {
        private List<Student> students;
        public StudentsForm(List<Student> students)
        {
            InitializeComponent();
            studentsDataGridView.AutoGenerateColumns = false;
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
    }
}
