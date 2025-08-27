using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account_Registration
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
            ArrayList Programs = new ArrayList();
            Programs.Add("BS in Information Technology");
            Programs.Add("BS in Computer Science");
            Programs.Add("BS in Information Systems");
            Programs.Add("BS in Computer Engineering");
            Programs.Add("BS in Mechanical Engineering");
            foreach (string stdProgram in Programs) { 
                CBProgram.Items.Add(stdProgram);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentInfoClass.FirstName = TBFirstName.Text.ToString();
            StudentInfoClass.LastName = TBLastName.Text.ToString();
            StudentInfoClass.MiddleName = TBMiddleName.Text.ToString();
            StudentInfoClass.Address = TBAddress.Text.ToString();
            StudentInfoClass.Program = CBProgram.Text.ToString();

            StudentInfoClass.Age = Convert.ToInt64(TBAge.Text);
            StudentInfoClass.ContactNo = Convert.ToInt64(TBCOntactNo.Text);
            StudentInfoClass.StudentNo = Convert.ToInt64(TBStudentNo.Text);

            FrmConfirm frmConfirm = new FrmConfirm();
            DialogResult output = frmConfirm.ShowDialog();
            if (output == DialogResult.OK)
            {
                TBFirstName.Clear();
                TBLastName.Clear();
                TBMiddleName.Clear();
                TBAddress.Clear();
                TBAge.Clear();
                TBCOntactNo.Clear();
                TBStudentNo.Clear();
                CBProgram.SelectedIndex = -1;
            }
        }

        private void CBProgram_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
