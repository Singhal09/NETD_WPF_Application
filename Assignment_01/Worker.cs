/**
 * Author: Sanya Singhal
 * Date: 29 September, 2022
 * Course: NETD 3202
 * Description: Worker class having objects and methods to create payroll
*/

#region USING Statements
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
#endregion

namespace PayrollCalculator
{
    internal class Worker
    {
        #region "Declarations"
        //Instance variables
        private string workerName = String.Empty;
        private int workerMessage = 0;
        private double workerPay = 0.0;

        //static variables for summary data
        private static int workerCount = 0;
        private static int totalMessage = 0;
        private static double totalPay = 0.0;
        private static double averagePay = 0.0;
        #endregion

        #region "Constructors"

        internal Worker()
        {

        }

        internal Worker(string workerName, int workerMessage)
        {
            Name = workerName;
            Message = workerMessage;

            workerPay = GetPay();
            workerCount += 1;
            totalPay += GetPay();
            totalMessage += Message;
            averagePay = SetAveragePay();

        }
        #endregion

        #region "Properties"

        internal string Name
        {
            get
            {
                return workerName;
            }
            set
            {
                double num;

                if (value.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter Worker's Name");
                }

                else if (double.TryParse(value, out num))
                {
                    MessageBox.Show("Worker's Name cannot not be numeric");
                }
                else
                {
                    workerName = value;
                }
            }
        }
        internal int Message
        {
            get
            {
                return workerMessage;
            }
            set
            {

                if (value == 0)
                {
                    MessageBox.Show("Please enter number of messages");

                }

                else if (value < 0)
                {
                    MessageBox.Show("Number of messages should be a positive whole number");


                }

                else
                {
                    workerMessage = value;
                }
            }
        }
        internal double Pay
        {
            get
            {
                return workerPay;
            }
        }

        internal static double WorkerCount
        {
            get
            {
                return workerCount;
            }

        }

        internal static double TotalPay
        {
            get
            {
                return totalPay;
            }

        }

        internal static double TotalMessage
        {
            get
            {
                return totalMessage;
            }

        }

        internal static double AveragePay
        {
            get
            {
                return averagePay;
            }

        }
        public static double SetAveragePay()  
        {
            if(workerCount == 0)
            {
                averagePay = 0;
            }
            averagePay = totalPay / workerCount;
            return averagePay;

        }

        #endregion

        #region "Methods"

        protected virtual double GetPay()  //method to calculate the total pay of the worker
        {
            double total_pay;
            double pay = 0;
            //calculating the cost of messages according to the range
            if (Message == 0)
            {
                pay = 0;
            }
            else if (Message >= 1 && Message <= 1249)
            {
                pay = 0.02;
            }

            else if (Message >= 1250 && Message <= 2499)
            {
                pay = 0.024;
            }

            else if (Message >= 2500 && Message <= 3749)
            {
                pay = 0.028;
            }

            else if (Message >= 3750 && Message <= 4999)
            {
                pay = 0.034;
            }

            else if (Message >= 5000)
            {
                pay = 0.04;
            }

            else
            {
                MessageBox.Show("Number of Messages sent should be a positive whole number ");
            }
            //calculating the total pay 
            total_pay = Math.Round(Message * pay, 2);
            //returning the total pay
            return total_pay;
        }
        #endregion

    }
}
