using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApplication
{
    internal class CalculatorClass{
        public delegate T Formula<T>(T input1, T input2);
        public Formula <double> formula;
        public double GetSum(double input1, double input2){
            return input1 + input2;
        }
        public double GetProduct(double input1, double input2){
            return input1 * input2;
        }
        public double GetDiffernce(double input1, double input2){
            return input1 - input2;
        }
        public double GetQuotient(double input1, double input2){
            return input1 / input2;
        }

        private Formula<double> calculateEvent;

        public event Formula<double> CalculateEvent{
            add{
                calculateEvent += value;
                Console.WriteLine("Added the Delegate");
            }
            remove{
                calculateEvent -= value;
                Console.WriteLine("Removed the Delegate");
            }
        }
    }
}
