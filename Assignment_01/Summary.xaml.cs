/**
 * Author: Sanya Singhal
 * Date: 29 September, 2022
 * Course: NETD 3202
 * Description: Summary of the pay of the workers
*/

#region USING Statements
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
#endregion

namespace PayrollCalculator
{
    /// <summary>
    /// Interaction logic for Summary.xaml
    /// </summary>
    public partial class Summary : Window
    {
        public Summary()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCloseSummary_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Sets the values of the textboxes when loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //putting focus on close button
            ButtonCloseSummary.Focus();
            //setting the textboxes texts using the worker class
            textBoxTotalWorker.Text = Worker.WorkerCount.ToString();
            textBoxTotalPay.Text = Worker.TotalPay.ToString("c");
            textBoxTotalMessage.Text = Worker.TotalMessage.ToString();
            textBoxAveragePay.Text = Worker.AveragePay.ToString("c");

        }
    }
}
