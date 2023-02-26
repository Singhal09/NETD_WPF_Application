/**
 * Author: Sanya Singhal
 * Date: 21 November, 2022
 * Course: NETD 3202
 * Description: PieceworkWorkerModel Class
 *              
*/

#region Using Statements
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Assignment_04.Models
{
   
    public class PieceworkWorkerModel
    {
        #region "Declarations"
        //Instance variables
        private string workerName = String.Empty;
        //private int workerMessage = 0;
        private double workerPay = 0.0;

        //static variables for summary data
        protected static int workerCount = 0;
        protected static int totalMessage = 0;
        protected static double totalPay = 0.0;
        protected static double averagePay = 0.0;
        

        // Some constants.
        internal const int MaximumMessages = 1000000;
        internal const int MinimumMessages = 0;
        internal const int PayRange01 = 0;
        internal const int PayRange02 = 1250;
        internal const int PayRange03 = 2500;
        internal const int PayRange04 = 3750;
        internal const int PayRange05 = 5000;
        internal const double Pay01 = 0.0;
        internal const double Pay02 = 0.025;
        internal const double Pay03 = 0.03;
        internal const double Pay04 = 0.035;
        internal const double Pay05 = 0.040;
        internal const double Pay06 = 0.046;


        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public PieceworkWorkerModel()
        {

        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="nameValue"></param>
        /// <param name="messageValue"></param>
        internal PieceworkWorkerModel(string nameValue, int messageValue)
        {
            //Setting the values of the properties and calculating the total pay and the total workers
            Name = nameValue;
            Message = messageValue;

        }
        #endregion

        #region "Properties"
        /// <summary>
        /// Worker's Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a name.")]
        [MinLength(2, ErrorMessage = "The entered name must be at least {1} characters.")]
        [Display(Name = "Worker Name:")]
        public string? Name { get; set; }

        /// <summary>
        /// Number of messages sent by workers
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a numeric value.")]
        [Range(MinimumMessages, MaximumMessages, ErrorMessage = "You must enter a rate between {1} and {2}.")]
        [Display(Name = "Number of Messages:")]
        public int Message { get; set; }

      
        /// <summary>
        /// Worker's Pay
        /// </summary>
        [Display(Name = "Calculated Pay:")]
        [DisplayFormat(DataFormatString = "c")]
        public double Pay { get; protected set; }

        
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
        internal static int TotalMessage
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
                if (WorkerCount == 0)
                {
                    return 0;
                }
                return TotalPay / WorkerCount;
            }
        }


        /// <summary>
        /// Is the worker is senior or not
        /// </summary>
        public bool IsSenior { get; set; } = false;

        #endregion

        #region "Methods"
        /// <summary>
        /// Calculate the total pay of the worker
        /// </summary>
        /// <returns></returns>
        protected internal virtual double GetPay()  
        {
            //double totalPay;
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
            Pay = Math.Round(Message * pay, 2, MidpointRounding.AwayFromZero);


            //Calculating the worker count and the total messages and pay
            workerCount += 1;
            totalPay += Pay;
            totalMessage += Message;
            //returning the pay of the worker
            return Pay; 
        }

        /// <summary>
        /// String to display regular worker's details
        /// </summary>
        /// <returns></returns>
        protected internal virtual string ToString()
        {
            return Name + " - " + Message + " Messages " + " - " + Pay.ToString("c") + " - Regular Worker";
        }
        #endregion
    }
}

