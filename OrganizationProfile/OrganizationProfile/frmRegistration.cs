using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private static string _FullName;
        private static int _Age;
        private static long _ContactNo, _StudentNo;
        public long StudentNumber(string studNum){
            try{
                _StudentNo = long.Parse(studNum);
            }
            catch(FormatException ex) {
                MessageBox.Show("Invalid Input: " + ex.Message);
                txtStudentNo.Clear();
            }
            return _StudentNo;
        }
        public long ContactNo(string Contact) {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException ex){
                MessageBox.Show("Invalid Input: " + ex.Message);
                txtContactNo.Clear();
            }
            return _ContactNo;
        }               
        public string FullName(string LastName, string FirstName, string MiddleInitial){
            try{
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") ||
                    Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") ||
                    Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$")){
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
                }
                else{
                    throw new FormatException();
                }
            }
            catch (FormatException ex){
                MessageBox.Show("Invalid Input: " + ex.Message);
                txtLastName.Clear();
                txtFirstName.Clear();
                txtMiddleInitial.Clear();
            }
            return _FullName;
        }
        public int Age(string age){
            try{
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$")){
                    _Age = Int32.Parse(age);
                }
                else{
                    throw new FormatException();
                }
            }
            catch (FormatException ex){
                MessageBox.Show("Invalid Input: " + ex.Message);
                txtAge.Clear();
            }
            return _Age;
        }
        public frmRegistration(){
            InitializeComponent();
            ArrayList gender = new ArrayList();
            gender.Add("Male");
            gender.Add("Female");

            foreach (string igender in gender){
                cbGender.Items.Add(igender);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try{
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirtday.Value.ToString("yyyy-MM-dd");

                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            }
            catch (IndexOutOfRangeException ex){
                MessageBox.Show("Invalid Input: " + ex.Message);
                txtContactNo.Clear();
            }
            catch (FormatException ex){
                MessageBox.Show("Invalid Input: " + ex.Message);
                txtStudentNo.Clear();
            }
            catch (ArgumentException ex){
                MessageBox.Show("Invalid Input: " + ex.Message);
            }
            catch (OverflowException ex){
                MessageBox.Show("Invalid Input: " + ex.Message);
            }
            finally{
                MessageBox.Show("Program Finish Executing");
                this.Close();
            }
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
               "BS Information Technology",
               "BS Computer Science",
               "BS Information Systems",
               "BS in Accountancy",
               "BS in Hospitality Management",
               "BS in Tourism Management"
            };
            for (int i = 0; i < 6; i++){
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
        }
    }
}
