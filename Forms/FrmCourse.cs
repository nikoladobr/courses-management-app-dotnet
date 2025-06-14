using ControllerAP;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class FrmCourse : Form
    {
        private ExamPeriod ep;
       

            public FrmCourse(ExamPeriod ep)
            {
            InitializeComponent();
            this.ep = ep;
            txtExamPeriodName.Text = ep.Name.ToString();
            txtStartDate.Text = ep.StartDate.ToString();
            txtEndDate.Text = ep.EndDate.ToString();
            dgvCourses.DataSource = Controller.Instance.ReturnCourses(ep.Id);
            dgvCourses.Columns[0].Visible = false;
            }

        private void FrmCourse_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you sure that you want to add this course?", "Confirm", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (string.IsNullOrWhiteSpace(txtCourseName.Text) || string.IsNullOrWhiteSpace(txtEcts.Text))
                    {
                        MessageBox.Show("All fields are required.");
                        return;
                    }

                    if (!int.TryParse(txtEcts.Text, out int ects) || ects < 2 || ects > 10)
                    {
                        MessageBox.Show("ECTS must be a number between 2 and 10.");
                        return;
                    }

                    Course c = new Course
                    {
                        Name = txtCourseName.Text.Trim(),
                        Ects = ects
                    };

                    DateTime examDate = dtpExamDate.Value;

                    Controller.Instance.AddCourseToExamPeriod(c, ep, examDate);

                    MessageBox.Show("Course successfully added.");
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message);
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
