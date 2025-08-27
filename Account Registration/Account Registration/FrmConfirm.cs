using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Account_Registration.StudentInfoClass;

namespace Account_Registration
{
    public partial class FrmConfirm : Form
    {
        private DelegateText DelProgram, DelLastName, DelFirstName, DelMiddleName, DelAddress;

        private void BTNSubmit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private DelegateNumber DelNumAge, DelNumContactNo, DelStudNo;
        public FrmConfirm()
        {
            InitializeComponent();
            DelProgram = new DelegateText(GetProgram);
            DelLastName = new DelegateText(GetLastName);
            DelFirstName = new DelegateText(GetFirstName);
            DelMiddleName = new DelegateText(GetMiddleName);
            DelAddress = new DelegateText(GetAddress);
            DelNumAge = new DelegateNumber(GetAge);
            DelNumContactNo = new DelegateNumber(GetContactNo);
            DelStudNo = new DelegateNumber(GetStudentNo);

            LBLStudentNo.Text = DelStudNo(StudentInfoClass.StudentNo).ToString(); 
            LBLProgram.Text = DelProgram(StudentInfoClass.Program);
            LBLLastName.Text = DelLastName(StudentInfoClass.LastName);
            LBLFirstName.Text = DelFirstName(StudentInfoClass.FirstName);
            LBLMiddleName.Text = DelMiddleName(StudentInfoClass.MiddleName);
            LBLAge.Text = DelNumAge(StudentInfoClass.Age).ToString();
            LBLContactNo.Text = DelNumContactNo(StudentInfoClass.ContactNo).ToString();
            LBLAddress.Text = DelAddress(StudentInfoClass.Address);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void FrmConfirm_Load(object sender, EventArgs e)
        {

        }
    }
}
