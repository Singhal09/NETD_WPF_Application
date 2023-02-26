/**
 * Author: Sanya Singhal
 * Date: 15 December, 2022
 * Course: NETD 3202
 * Description: PieceworkWorkerModel Class : Class representing individual workers object.
 *              
*/

#region Using Statements
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
#endregion

namespace Assignment_05.Models
{

    public class PieceworkWorkerModel
    {
        #region "Declarations"
 
        // Some constants.
        internal const int MaximumMessages = 1000000;
        internal const int MinimumMessages = 0;
        internal const int PayRange01 = 0;
        internal const int PayRange02 = 1250;
        internal const int PayRange03 = 2500;
        internal const int PayRange04 = 3750;
        internal const int PayRange05 = 5000;
        internal const double SeniorFixedPay = 200.0;

        internal const double SeniorPay01 = 0.0;
        internal const double SeniorPay02 = 0.018;
        internal const double SeniorPay03 = 0.021;
        internal const double SeniorPay04 = 0.024;
        internal const double SeniorPay05 = 0.027;
        internal const double SeniorPay06 = 0.03;

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
        public PieceworkWorkerModel(string firstnameValue, string lastnameValue, int messageValue)
        {
            //Setting the values of the properties and calculating the total pay and the total workers
            FirstName = firstnameValue;
            LastName = lastnameValue;
            Message = messageValue;

        }
        #endregion

        #region "Properties"
        /// <summary>
        /// Arbitrary Id for each workers
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Worker's First Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a first name.")]
        [MinLength(2, ErrorMessage = "The entered first name must be at least {1} characters.")]
        [Display(Name = "Worker First Name:")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Worker's Last Name
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a last name.")]
        [MinLength(2, ErrorMessage = "The entered last name must be at least {1} characters.")]
        [Display(Name = "Worker Last Name:")]
        public string? LastName { get; set; }

        /// <summary>
        /// Number of messages sent by workers
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a numeric value.")]
        [Range(MinimumMessages, MaximumMessages, ErrorMessage = "You must enter a rate between {1} and {2}.")]
        [Display(Name = "Number of Messages:")]
        public int Message { get; set; }

        /// <summary>
        /// Is the worker is senior or not
        /// </summary>
        public bool IsSenior { get; set; } = false;

        /// <summary>
        /// Date and time when the worker object is created
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        #endregion

        #region "Methods"
        /// <summary>
        /// Calculate the total pay of the worker
        /// </summary>
        /// <returns></returns>
        public double GetPay()
        {
            //to store calculated pay
            double regularPay = 0;
            double seniorPay = 0;
            double seniorWorkerPay = 0.0;
            double regularWorkerPay = 0.0;


            //calculating the cost of messages according to the range
            if (Message == PayRange01)
            {
                regularPay = Pay01;
                seniorPay = SeniorPay01;
            }
            else if (Message > PayRange01 && Message < PayRange02)
            {
                regularPay = Pay02;
                seniorPay = SeniorPay02;
            }

            else if (Message >= PayRange02 && Message < PayRange03)
            {
                regularPay = Pay03;
                seniorPay = SeniorPay03;
            }

            else if (Message >= PayRange03 && Message < PayRange04)
            {
                regularPay = Pay04;
                seniorPay = SeniorPay04;
            }

            else if (Message >= PayRange04 && Message < PayRange05)
            {
                regularPay = Pay05;
                seniorPay = SeniorPay05;
            }

            else if (Message >= PayRange05)
            {
                regularPay = Pay06;
                seniorPay = SeniorPay06;
            }

            //calculating the total pay according to the worker type
            seniorWorkerPay = Math.Round((Message * seniorPay) + SeniorFixedPay, 2, MidpointRounding.AwayFromZero);
            regularWorkerPay = Math.Round(Message * regularPay, 2, MidpointRounding.AwayFromZero);

            if( seniorWorkerPay < regularWorkerPay)
            {
                seniorWorkerPay = regularWorkerPay;
            }

            if (IsSenior)
            {
                //returning the senior worker pay
                return seniorWorkerPay;
            }
            else
            {
                //calculating the regular worker pay
                return regularWorkerPay;
            }
            
            
        }

        #endregion
    }
}


