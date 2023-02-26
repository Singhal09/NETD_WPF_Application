/**
 * Author: Sanya Singhal
 * Date: 16 October, 2022
 * Course: NETD 3202
 * Description: Pay Calculator form which calculates the worker pay 
 *              on basis of number of messages and throw exceptions for invalid input
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
using System.Xml.Linq;

namespace Assignment_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PayCalculator : Window
    {
        #region Form Load
        public PayCalculator()
        {
            InitializeComponent();
        }
        #endregion

        #region Click Events
        /// <summary>
        /// Calculates the pay of the worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //validating the name input
                if (ValidateName(txtWorkerName.Text))
                {
                    //validation the number of message input
                    if (ValidateNumberOfMessage(txtWorkerMessage.Text))

                    {
                        //creating an object of worker class
                        var newWorker = new PieceworkWorker(txtWorkerName.Text, int.Parse(txtWorkerMessage.Text));
                        //Displaying the pay of the worker in the ouput textbox
                        txtWorkerPay.Text = newWorker.Pay.ToString("c");

                        //Disenabling the input textboxes
                        txtWorkerMessage.IsEnabled = false;
                        txtWorkerName.IsEnabled = false;
                        btnCalculate.IsEnabled = false;
                        //focus on clear button
                        btnClear.Focus();
                    }
                    
                }
                //Updating the status bar and displaying the message
                UpdateStatus("Worker " + txtWorkerName.Text + " has been entered with " + txtWorkerMessage.Text + " messages and pay of $" + txtWorkerPay);
            }

            catch (ArgumentException error)
            {
                // If the Name is in error then displaying the error in the name error label
                if (error.ParamName == PieceworkWorker.NameParameter)
                {
                    lblNameError.Content = "*" + error.Message;
                    HighlightError(txtWorkerName);   //highlighting the textbox
                }
                // If the Message is in error then displaying the error in the message error label
                else if (error.ParamName == PieceworkWorker.MessageParameter)
                {
                    lblMessageError.Content = "*" + error.Message;
                    HighlightError(txtWorkerMessage);  //Highlighting the textbox
                }
                
                else
                {
                    //Displaying the unknown error
                    MessageBox.Show("Unknown Error");
                }
                //Updating the message in the status bar 
                UpdateStatus("Entry error in " + error.ParamName + ".");
            }
            // Catch any other exceptions.
            catch (Exception error)
            {
                // We have no information about this issue! Provide all possible information.
                MessageBox.Show("Unknown Error!\n" +
                    "An issue has occured related to your input and process cannot continue!.\n" +
                    "\nMessage: " + error.Message +
                    "\n\nStack Trace: " + error.StackTrace,
                    "Unknown Error!");
            }

        }

        /// <summary>
        /// Clear the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //Clearing the form using the setclear function
            SetClear();
            //Updating the message in the status bar
            UpdateStatus("Worker entry cleared");
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
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
            txtWorkerName.IsEnabled = true;
            lblNameError.Content = String.Empty;
            txtWorkerMessage.IsEnabled = true;
            lblMessageError.Content = String.Empty;
            btnCalculate.IsEnabled = true;
            //clearing the textboxes
            txtWorkerMessage.Text = "";
            txtWorkerName.Text = "";
            txtWorkerPay.Text = "";
            //focus on the worker name textbox
            txtWorkerName.Focus();

            
        }

        /// <summary>
        /// Validate the number of messages entered
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidateNumberOfMessage(string message)
        {
            //declaring the boolean and an integer variable
            bool returnValue = false;
            int integerType;

            //checking if message is integer
            if (!(int.TryParse(message, out integerType)))
            {
                //dispalying the message
                throw new ArgumentException("Enter the hours worked as a number between " + PieceworkWorker.MinimumMessages.ToString() +
                    " and " + PieceworkWorker.MaximumMessages.ToString() + ".", PieceworkWorker.MessageParameter);

            }

            else
            {
                //if any of the above statements are not true then setting the boolean variable to true
                returnValue = true;
            }
            //otherwise false
            return returnValue;

        }

        /// <summary>
        /// Validate the worker name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ValidateName(string name)
        {
            bool returnValue = false;
            double doubleType;

            //checking for not a string
            if (double.TryParse(name, out doubleType))
            {
                throw new ArgumentException("Enter the Name of the worker not as a number " + ".", PieceworkWorker.NameParameter);
            }
            else
            {
                returnValue = true;
            }

            return returnValue;
        }

        /// <summary>
        /// Highlights the textbox with invalid input
        /// </summary>
        /// <param name="errorBox"></param>
        private void HighlightError(TextBox errorBox)
        {
            errorBox.BorderBrush = Brushes.Red;
            errorBox.Background = Brushes.Pink;
            errorBox.SelectAll();
            errorBox.Focus();
        }

        /// <summary>
        /// Sets the values of the textboxes of the summary form when summary tab is opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SummaryFocus(object sender, RoutedEventArgs e)
        {

            //setting the textboxes texts using the Pieceworker class
            txtTotalWorkers.Text = PieceworkWorker.WorkerCount.ToString();
            txtTotalPay.Text = PieceworkWorker.TotalPay.ToString("c");
            txtTotalMessages.Text = PieceworkWorker.TotalMessage.ToString();
            txtAveragePay.Text = PieceworkWorker.AveragePay.ToString("c");

            //Updating the status bar
            UpdateStatus("Summary data displayed");

        }

        /// <summary>
        /// Unhighlights the textbox with the error
        /// </summary>
        /// <param name="errorBox"></param>
        private void UnhighlightError(TextBox errorBox)
        {
            errorBox.BorderBrush = SystemColors.InactiveBorderBrush;
            errorBox.Background = SystemColors.ControlBrush;
        }

        /// <summary>
        /// When the user edits the textbox text when there is an error, unhighlights the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxEdited(object sender, TextChangedEventArgs e)
        {
            // Change "sender" into a TextBox object.
            TextBox editedBox = (TextBox)sender;

            //Unhighlighting the textbox
            UnhighlightError(editedBox);

            // If a specific TextBox is edited, clear its corresponding error label.
            if (editedBox == txtWorkerName)
            {
                lblNameError.Content = String.Empty;
            }
            else if (editedBox == txtWorkerMessage)
            {
                lblMessageError.Content = String.Empty;
            }

        }
        /// <summary>
        /// Updates the Status Bar with the specified message
        /// </summary>
        /// <param name="message"></param>
        private void UpdateStatus(string message)
        {
            //setting the time label of the status bar to the current time and date
            lblTime.Content = DateTime.Now.ToString();
            //displaying the message to the status label
            lblStatus.Content = message;
        }
        #endregion
    }
}

