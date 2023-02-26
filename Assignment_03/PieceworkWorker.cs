/**
 * Author: Sanya Singhal
 * Date: 04 November, 2022
 * Course: NETD 3202
 * Description: PieceworkWorker Class          
*/

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
#endregion


namespace Assignment_03
{
    using Workers = WorkersDatabase;
    public class PieceworkWorker
    {
        #region "Declarations"
        //Instance variables
        private string workerName = String.Empty;
        private int workerMessage = 0;
        private double workerPay = 0.0;


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
        internal PieceworkWorker(string nameValue, int messageValue)
        {
            //Setting the values of the properties and calculating the total pay and the total workers
            Name = nameValue;
            Message = messageValue;

            /*workerPay = GetPay();
            workerCount += 1;
            totalPay += GetPay();
            totalMessage += Message;
            averagePay = SetAveragePay();*/

            GetPay();
            Workers.Add(this);

        }
        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the name of the worker and sets it after business type vaildation
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
        /// Gets the number of messages and sets it after some business validation
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
                        MinimumMessages + " and " + MaximumMessages + ".");
                }

                else
                {
                    workerMessage = value;
                }
            }
        }


        /// <summary>
        /// Gets the worker Pay
        /// </summary>
        internal double Pay
        {
            get
            {
                return workerPay;
            }
        }

        /// <summary>
        /// Gets the Count of the workers
        /// </summary>
        internal static double WorkerCount
        {
            get
            {
                return Workers.WorkerCounts;
            }

        }

        /// <summary>
        /// Gets the Total pay of the worker
        /// </summary>
        internal static double TotalPay
        {
            get
            {
                return Workers.TotalPays;
            }

        }

        /// <summary>
        /// Gets the total message
        /// </summary>
        internal static double TotalMessage
        {
            get
            {
                return Workers.TotalMessages;
            }

        }

        /// <summary>
        /// Gets the average pay of the workers
        /// </summary>
        internal static double AveragePay
        {
            get
            {
                if (WorkerCount == 0)
                {
                    return 0;
                }
                return TotalPay / WorkerCount;
            }

        }
        /// <summary>
        /// Gets the list of all the workers using the workersDatabase class
        /// </summary>
        internal static List<PieceworkWorker> List
        {
            get
            {
                return Workers.AllWorkers;
            }
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Calculate the total pay of the worker
        /// </summary>
        /// <returns></returns>
        protected internal virtual double GetPay()
        {
            //double total_pay;
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

            //calculating the total pay 
            workerPay = Math.Round(Message * pay, 2);
            //returning the total pay
            return workerPay;
        }
        /// <summary>
        /// Restores the list used by the program from whatever the data source is.
        /// </summary>
        /// <returns>List of workers</returns>
        internal static void Initialize()
        {
            Workers.RefreshList();
        }

        /// <summary>
        /// String to store in the List of workers
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Name: " + Name + "  Message: " + Message + "  Pay: " + Pay.ToString("c");
        }
        #endregion
    }
}


