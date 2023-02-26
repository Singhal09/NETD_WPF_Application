/**
 * Author: Sanya Singhal
 * Date: 21 November, 2022
 * Course: NETD 3202
 * Description: SeniorWorkerModel Class
 *              
*/

#region Using Statements
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Assignment_04.Models
{
    public class SeniorWorkerModel : PieceworkWorkerModel
    {
        #region Declarations
        // Declaring Some constants.
        internal new const int MaximumMessages = 1000000;
        internal new const int MinimumMessages = 0;
        internal new const int PayRange01 = 0;
        internal new const int PayRange02 = 1250;
        internal new const int PayRange03 = 2500;
        internal new const int PayRange04 = 3750;
        internal new const int PayRange05 = 5000;
        internal new const double Pay01 = 0.0;
        internal new const double Pay02 = 0.018;
        internal new const double Pay03 = 0.021;
        internal new const double Pay04 = 0.024;
        internal new const double Pay05 = 0.027;
        internal new const double Pay06 = 0.03;
        internal const double SeniorPay = 200.0;
        #endregion

        #region Constructor
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="workerName"></param>
        /// <param name="workerMessage"></param>
        public SeniorWorkerModel(string workerName, int workerMessage)
        {
            //assigning values to the Name and Message properties
            Name = workerName;
            Message = workerMessage;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Is the worker is senior or not
        /// </summary>
        public new bool IsSenior { get; set; } = true;
        #endregion

        #region Methods
        /// <summary>
        /// Calculate the Pay of the senior worker
        /// </summary>
        /// <returns></returns>
        protected internal override double GetPay()
        {
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
            Pay = Math.Round(Message * pay, 2, MidpointRounding.AwayFromZero) + SeniorPay;
            PieceworkWorkerModel model = new PieceworkWorkerModel(Name, Message);
            //checking if the senior pay is less than regular pieceworkworker pay
            if (Pay < model.GetPay())
            {
                //if it is less then equating the senior pay to the regular worker
                Pay = model.Pay;
            }
            else
            {
                workerCount += 1;
            }
            //calculating the total number of workers and their total messages and pay
            totalPay = totalPay + Pay;
            totalMessage += Message;
           
            //returning the pay of the senior worker
            return Pay;
        }

        /// <summary>
        /// String to display senior worker's details
        /// </summary>
        /// <returns></returns>
        protected internal override string ToString()
        {
            return Name + " - " + Message + " Messages " + " - " + Pay.ToString("c") + " - Regular Worker";
        }
        #endregion
    }
}
