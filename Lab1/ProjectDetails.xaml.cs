/* Name - Zeel Sutariya
 * This is Lab 1 ProjectDetails File(new window .cs file) and not included the community acticity(alter button in progress).
 * Student Id - 100846187
 * 
 */
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

namespace Lab1
{
    /// <summary>
    /// Interaction logic for ProjectDetails.xaml
    /// </summary>
    public partial class ProjectDetails : Window
    {
        public ProjectDetails()
        {
            InitializeComponent();
        }

        //Below is the Parameter raised constructor
        public ProjectDetails(string projectName, string budget, string spent, string estTimeRemaining, string projectStatus)
        {
            // initializing the components
            InitializeComponent();
            // proving values to the textboxes and comboBox
            txtProjectName.Text = projectName;
            txtBudget.Text = budget;
            txtSpent.Text = spent;
            txtEstTimeRemaining.Text = estTimeRemaining;
            comboBoxStatus.SelectedItem = projectStatus;
        }

        // Validate function to vaildate the inputs in textboxes and comboBox
        public bool ValidateInput(string inputName, string inputBudget, string inputSpent, string inputTimeReamining, string inputStatus)
        {
            string errorMessage = "";
            string errorTtile = "";
            if (inputName == "")
            {
                errorMessage = "Please enter something in the Project Name field";
                errorTtile = "Invalid Project Name";
                // select all the text
                txtProjectName.SelectAll();
                // focus the cursor to textbox mentioned below(projectname textbox)
                txtProjectName.Focus();
            }
            else if (!double.TryParse(inputBudget, out double a))
            {
                errorMessage = "Please enter a number!!";
                errorTtile = "Invalid Budget Amount";
                txtBudget.SelectAll();
                txtBudget.Focus();
            }
            else if (!double.TryParse(inputSpent, out double b))
            {
                errorMessage = "Please enter a number!!";
                errorTtile = "Invalid Spent Amount";
                txtSpent.SelectAll();
                txtSpent.Focus();
            }
            else if (!Int32.TryParse(inputTimeReamining, out Int32 c1))
            {
                // If the input isnt a number
                errorMessage = "Please enter a number!!";
                errorTtile = "Invalid Est. Time Reamining";
                txtEstTimeRemaining.SelectAll();
                txtEstTimeRemaining.Focus();

            }
            else if (Int32.TryParse(inputTimeReamining, out Int32 c))
            {
                // if the input is number
                if (c < 0)
                {
                    // if the input is negative
                    errorMessage = "Please enter a whole number!!";
                    errorTtile = "Invalid Est. Time Reamining";
                    txtEstTimeRemaining.SelectAll();
                    txtEstTimeRemaining.Focus();
                }
                else if (inputStatus == "Completed" && c != 0)
                {
                    // if the input is not zero but the status is completed
                    errorMessage = "Status is completed, Time Remaining must be 0!!";
                    errorTtile = "Invalid Est. Time Reamining";
                    txtEstTimeRemaining.SelectAll();
                    txtEstTimeRemaining.Focus();
                }
            }

            if (errorMessage != "")
            {
                // Validation failed - Display an message box (consists errors)
                MessageBox.Show(errorMessage, errorTtile);
                return false;
            }
            else
            {
                // Validation passed - proceed to next step
                return true;
            }
        }


        // Below is the close button click event
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            // close the current window
            this.Close();
        }

        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput(txtProjectName.Text, txtBudget.Text, txtSpent.Text, txtEstTimeRemaining.Text, comboBoxStatus.Text))
            {
                
                Program pro = new Program(txtProjectName.Text, txtBudget.Text, txtSpent.Text, txtEstTimeRemaining.Text, comboBoxStatus.Text);
                Program.programs.Remove(Program.FindProgram(pro.ProjectName));
                Program.programs.Add(pro);
                MainWindow mw = new MainWindow();
                mw.updateList();
                mw.ShowDialog();
                this.Close();

     
                //Program.programs[] = 
                //new MainWindow(txtProjectName.Text, txtBudget.Text, txtSpent.Text, txtEstTimeRemaining.Text, comboBoxStatus.Text);

                //Program alter = new Program(txtProjectName.Text, txtBudget.Text, txtSpent.Text, txtEstTimeRemaining.Text, comboBoxStatus.Text);
                //btnClose_Click(sender, e);
            }
            
        }
    }
}
