/**
 * Author: Sanya Singhal
 * Date: 16 October, 2022
 * Course: NETD 3202
 * Description: PieceworkWorker Class
 *              
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment_02
{
   
    internal class PieceworkWorker
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
        

        // Some constants.
        internal const int MaximumMessages = 1000000;
        internal const int MinimumMessages = 0;
        internal const int PayRange01 = 0;
        internal const int PayRange02 = 1250;
        internal const int PayRange03 = 2500;
        internal const int PayRange04 = 3750;
        internal const int PayRange05 = 5000;
        internal const double Pay01 = 0.0;
        internal const double Pay02 = 0.02;
        internal const double Pay03 = 0.024;
        internal const double Pay04 = 0.028;
        internal const double Pay05 = 0.034;
        internal const double Pay06 = 0.04;


        internal const string MessageParameter = "Message";
        internal const string NameParameter = "Name";

        #endregion

        #region "Constructors"

        
        /// <summary>
        /// Default Constructor
        /// </summary>
        internal PieceworkWorker()
        {

        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="workerName"></param>
        /// <param name="workerMessage"></param>
        internal PieceworkWorker(string workerName, int workerMessage)
        {
            //Setting the values of the properties and calculating the total pay and the total workers
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

        /// <summary>
        /// Accessing and mutating the Name property
        /// </summary>
        internal string Name
        {
            get
            {
                return workerName;
            }
            set
            {
                //Business type Validation of the Name
                if (value.Trim() == string.Empty)
                {
                    throw new ArgumentNullException(NameParameter, "The name cannot be left blank.");
                }

                else
                {
                    workerName = value;
                }
            }
        }
        /// <summary>
        /// Accessing and mutating the message property
        /// </summary>
        internal int Message
        {
            get
            {
                return workerMessage;
            }
            set
            {
                //Business type validation for Message
                if (Convert.ToString(value) == "")
                {
                    //Throwing null argument exception
                    throw new ArgumentNullException(MessageParameter, "The message cannot be left blank.");

                }

                else if (value < MinimumMessages || value > MaximumMessages)
                {
                    //throwing out of range exception
                    throw new ArgumentOutOfRangeException(MessageParameter, "Please enter the number of messages sent between " + 
                        MinimumMessages.ToString("c") + " and " + MaximumMessages.ToString("c") + ".");
                }

                else
                {
                    workerMessage = value;
                }
            }
        }
        
        /// <summary>
        /// Accessing the worker Pay
        /// </summary>
        internal double Pay
        {
            get
            {
                return workerPay;
            }
        }

        /// <summary>
        /// Accessing the Count of the workers
        /// </summary>
        internal static double WorkerCount
        {
            get
            {
                return workerCount;
            }

        }

        /// <summary>
        /// Accessing the Total pay of the worker
        /// </summary>
        internal static double TotalPay
        {
            get
            {
                return totalPay;
            }

        }

        /// <summary>
        /// Accessing the total message
        /// </summary>
        internal static double TotalMessage
        {
            get
            {
                return totalMessage;
            }

        }

        /// <summary>
        /// Accessing the average pay of the workers
        /// </summary>
        internal static double AveragePay
        {
            get
            {
                return averagePay;
            }

        }
        /// <summary>
        /// Calculating the average pay of the workers
        /// </summary>
        /// <returns></returns>
        public static double SetAveragePay()
        {
            if (workerCount == 0)
            {
                averagePay = 0;
            }
            //Calculating the average pay
            averagePay = totalPay / workerCount;
            //returning the calculated averagePay
            return averagePay;

        }

        #endregion

        #region "Methods"
        /// <summary>
        /// Calculate the total pay of the worker
        /// </summary>
        /// <returns></returns>
        protected virtual double GetPay()  
        {
            double total_pay;
            double pay = 0;

            //calculating the cost of messages according to the range
            if (Message == PayRange01)
            {
                pay = Pay01;
            }
            else if (Message > PayRange01 && Message < PayRange02)
            {
                pay = Pay02;
            }

            else if (Message >= PayRange02 && Message < PayRange03)
            {
                pay = Pay03;
            }

            else if (Message >= PayRange03 && Message < PayRange04)
            {
                pay = Pay04;
            }

            else if (Message >= PayRange04 && Message < PayRange05)
            {
                pay = Pay05;
            }

            else if (Message >= PayRange05)
            {
                pay = Pay06;
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

