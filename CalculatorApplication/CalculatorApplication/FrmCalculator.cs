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

namespace CalculatorApplication
{
    public partial class FrmCalculator : Form
    {
        CalculatorClass cal = new CalculatorClass();
        double num1;
        double num2;
        public FrmCalculator()
        {
            InitializeComponent();
            ArrayList opt = new ArrayList();
            opt.Add("+");
            opt.Add("-");
            opt.Add("*");
            opt.Add("/");
            foreach (string operators in opt){
                cbOperator.Items.Add(operators);
            } 
        }
        private void FrmCalculator_Load(object sender, EventArgs e){
        }
        private void btnEqual_Click(object sender, EventArgs e){
            double num1 = double.Parse(txtBoxInput1.Text);
            double num2 = double.Parse(txtBoxInput2.Text);
            switch (cbOperator.SelectedIndex){
                case 0:
                    cal.CalculateEvent += new CalculatorClass.Formula<double>(cal.GetSum);
                    lblDisplayTotal.Text = cal.GetSum(num1, num2).ToString();
                    break;
                case 1:
                    cal.CalculateEvent -= new CalculatorClass.Formula<double>(cal.GetDiffernce);
                    lblDisplayTotal.Text = cal.GetDiffernce(num1, num2).ToString();
                    break;
                case 2: 
                    cal.CalculateEvent += new CalculatorClass.Formula<double>(cal.GetProduct);
                    lblDisplayTotal.Text = cal.GetProduct(num1, num2).ToString();
                    break;
                case 3: 
                    if (num2 != 0){ 
                        cal.CalculateEvent += new CalculatorClass.Formula<double>(cal.GetQuotient);
                        lblDisplayTotal.Text = cal.GetQuotient(num1, num2).ToString();
                    }
                    else{
                        MessageBox.Show("Zero cannot be used as devisor");
                    }
                    break;
            }
        }
    }
}
