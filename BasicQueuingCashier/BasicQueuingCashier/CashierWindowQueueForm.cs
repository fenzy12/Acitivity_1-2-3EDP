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

namespace BasicQueuingCashier{
    public partial class CashierWindowQueueForm : Form{
        public void DisplayCashierQueue(IEnumerable CashierList){
            listCashierQueue.Items.Clear();
            listCashierQueue.View = View.List;
            foreach (Object obj in CashierList){
                listCashierQueue.Items.Add(obj.ToString());
            }
        }
        public CashierWindowQueueForm(){
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e){
            DisplayCashierQueue(CashierClass.CashierQueue);
            Timer timer = new Timer();
            timer.Interval = (1 * 1000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        public void timer_Tick(object sender, EventArgs e){
        }

        private void btnNext_Click(object sender, EventArgs e){
            if (CashierClass.CashierQueue.Count > 0){
                string nextList = CashierClass.CashierQueue.Dequeue();
                DisplayCashierQueue(CashierClass.CashierQueue);
            }
            else{
                MessageBox.Show("No customers is in queue.");
            }
        }
        private void listCashierQueue_SelectedIndexChanged(object sender, EventArgs e){
        }
        private void CashierWindowQueueForm_Load(object sender, EventArgs e){

        }
    }
}
