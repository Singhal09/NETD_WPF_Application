/**
 * Author: Sanya Singhal
 * Date: 29 September, 2022
 * Course: NETD 3202
 * Description: Pay Calculator form which calculates the worker pay 
 *              on basis of number of messages sent
*/

#region USING Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
#endregion

namespace PayrollCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PayCalculator : Window
    {
        public PayCalculator()
        {
            InitializeComponent();
        }

        #region Click Events
        /// <summary>
        /// Opens the summary form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSummary_Click(object sender, RoutedEventArgs e)
        {
            Summary summary = new Summary();  //creating an instance of the summary form
            summary.ShowDialog();  //displaying the instance
        }

        /// <summary>
        /// Calculates the pay of the worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {

           //validating the name input
            if (ValidateName(textBoxWorkerName.Text))
            {
                //validation the number of message input
                if (ValidateNumberOfMessage(textBoxWorkerMessage.Text))

                {
                    //creating an object of worker class
                    var newWorker = new Worker(textBoxWorkerName.Text, int.Parse(textBoxWorkerMessage.Text));

                    if (newWorker.Pay >= 0)
                    {
                        //Displaying the pay of the worker in the ouput textbox
                        textBoxWorkerPay.Text = newWorker.Pay.ToString();

                        //Disenabling the input textboxes
                        textBoxWorkerMessage.IsEnabled = false;
                        textBoxWorkerName.IsEnabled = false;
                        ButtonCalculate.IsEnabled = false;
                        //focus on clear button
                        ButtonClear.Focus();
                    }
                }
                else
                {
                    //Clearing the textbox if wrong input is entered
                    textBoxWorkerMessage.Clear();
                    textBoxWorkerMessage.Focus();
                }
             }
            else
            {
                //Clearing the textbox if wrong input is entered
                textBoxWorkerName.Clear();
                textBoxWorkerName.Focus();
            }

        }

        /// <summary>
        /// Clear the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            //Clearing the form using the setclear function
            SetClear();
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            //Closes the form
            Close();
        }
        #endregion

        #region Custom Methods
        /// <summary>
        /// Set the form to its default values and put the focus on the name textbox
        /// </summary>
        public void SetClear()
        {
            //enabling back the input textboxes and calculate button
            textBoxWorkerName.IsEnabled = true; 
            textBoxWorkerMessage.IsEnabled = true;
            ButtonCalculate.IsEnabled = true;
            //clearing the textboxes
            textBoxWorkerMessage.Text = "";
            textBoxWorkerName.Text = "";
            textBoxWorkerPay.Text = "";
            //focus on the worker name textbox
            textBoxWorkerName.Focus();
        }

        /// <summary>
        /// Validate the number of messages entered
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidateNumberOfMessage(string message)
        {
            //declaring the boolean and an integer variable
            bool retval = false;
            int num;
            //checking if the number of message is empty
            if (message == "")
            {
                //displaying the message
                MessageBox.Show("Please enter number of messages");
                
            }
            //checking if the given number of messages is integer and smaller than zero
            else if((int.TryParse(message, out num) && num < 0 ))
            {
                //dispalying the message
                MessageBox.Show("Number of messages should be a positive whole number");
                

            }
            //checking if message is integer
            else if(!(int.TryParse(message, out num)))
            {
                //dispalying the message
                MessageBox.Show("Number of messages should be an integer");
               
            }

            else
            {
                //if any of the above statements are not true then setting the boolean variable to true
                retval = true;
            }
            //otherwise false
            return retval;
            
        }

        /// <summary>
        /// Validate the worker name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ValidateName(string name)
        {
            bool retval = false;
            double num;

            //checking for empty name
            if(name == "")
            {
                MessageBox.Show("Please enter Worker's Name");
            }
            //checking for not a string
            else if(double.TryParse(name, out num))
            {
                MessageBox.Show("Worker's Name cannot not be numeric");
            }
            else
            {
                retval = true;
            }

            return retval;
        }
        #endregion
    }
}
