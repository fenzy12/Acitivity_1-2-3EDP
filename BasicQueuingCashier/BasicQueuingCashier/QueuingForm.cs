﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicQueuingCashier
{
    public partial class QueuingForm : Form{
        private CashierClass cashier = new CashierClass();
        public QueuingForm(){
            InitializeComponent();
        }
        private void btnCashier_Click(object sender, EventArgs e){
            lblQueue.Text = cashier.CashierGeneratedNumber("P - ");
            CashierClass.getNumberInQueue = lblQueue.Text;
            CashierClass.CashierQueue.Enqueue(CashierClass.getNumberInQueue);
        }
        private void QueuingForm_Load(object sender, EventArgs e){
            CashierWindowQueueForm cashierWindow = new CashierWindowQueueForm();
            cashierWindow.Show();
        }

        private void lblQueue_Click(object sender, EventArgs e){
        }
    }
}
