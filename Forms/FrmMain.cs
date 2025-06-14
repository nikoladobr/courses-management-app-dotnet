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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            dgvExamPeriod.DataSource = Controller.Instance.ReturnExamPeriods();
            dgvExamPeriod.Columns[0].Visible = false;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if(dgvExamPeriod.SelectedRows.Count == 1)
            {
                ExamPeriod ep = (ExamPeriod)dgvExamPeriod.SelectedRows[0].DataBoundItem;
                FrmCourse fc = new(ep);
                fc.ShowDialog();
            }
        }
    }
}
