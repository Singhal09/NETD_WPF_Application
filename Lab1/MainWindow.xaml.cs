/* Name - Zeel Sutariya
 * This is Lab 1 main .cs file.
 * Student Id - 100846187
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
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
namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Program> program = new List<Program>();
        public MainWindow()
        {
            
            InitializeComponent();
          
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
                else if (inputStatus == "Completed" && c!=0)
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

        // updateProject function to update the list
        public void updateProject(int i, string name, string budget, string spent, string time, string status)
        {
            program.Add(new Program(name, budget, spent, time, status));
        }

        public void updateList()
        {
            Program newProgram = new Program();
            lstProjectList.Items.Add(Program.FindProgram(newProgram.ProjectName));
            
        }
        // Create Project Click Event

      
        private void btnCreateProject_click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            if (ValidateInput(txtProjectName.Text, txtBudget.Text, txtSpent.Text, txtEstTimeRemaining.Text, comboBoxStatus.Text))
            {
                //If passed the validation
                // creating new list of Program and storing the data
                Program newProgram = new Program(
                    txtProjectName.Text,
                    txtBudget.Text,
                    txtSpent.Text,
                    txtEstTimeRemaining.Text,
                    comboBoxStatus.Text
                    );
                Program.programs.Add(newProgram);
                // adding the new list to the listbox
                lstProjectList.Items.Add(newProgram.ProjectName);
                // adding new list to program list created globally
                program.Add(newProgram);
                if (lstProjectList.SelectedIndex >= 0)
                {
                    // updating the list
                    //updateProject(lstProjectList.SelectedIndex, txtProjectName.Text, txtBudget.Text, txtSpent.Text, txtEstTimeRemaining.Text, comboBoxStatus.Text);
                }
                //After the item is added clearing the data using clearData fucntion
                ClearData();

            }
        }

        // ClearData function to clear all the inputs
        public void ClearData()
        {
            // Clearing the data
            txtProjectName.Text = string.Empty;
            txtBudget.Text = string.Empty;
            txtSpent.Text = string.Empty;
            txtEstTimeRemaining.Text = string.Empty;
            comboBoxStatus.SelectedIndex = 0;
            txtProjectName.Focus();
        }

        // double click event on list item
        private void lstItemClicked(object sender, RoutedEventArgs e)
        {
            // retriving the index(on which clicked)
            int listIndex = lstProjectList.SelectedIndex;

            // Created an object of program and assigned the values from the list(program with selected item index)
            Program pro = Program.programs[listIndex];

            // calling parameter raised constructot 
            ProjectDetails window = new ProjectDetails(pro.ProjectName, Convert.ToString(pro.Budget), Convert.ToString(pro.Spent), Convert.ToString(pro.EstTimeRemaining), pro.ProjectStatus);

            // Making the new window as main window
            App.Current.MainWindow = window;

            // new window will show up
            window.Show(); 

            /* Updating the list again
            if (App.Current.MainWindow == this)
            {
                updateProject(listIndex, pro.ProjectName, Convert.ToString(pro.Budget), Convert.ToString(pro.Spent), Convert.ToString(pro.EstTimeRemaining), pro.ProjectStatus);
                // Removing the existing list(whichever was selected)
                lstProjectList.SelectedItems.RemoveAt(listIndex);
                // adding the new list to the listbox
                lstProjectList.Items.Add(pro.ProjectName);
                // adding new list to program list created globally
                program.Add(pro);
                updateProject(listIndex, pro.ProjectName, Convert.ToString(pro.Budget), Convert.ToString(pro.Spent), Convert.ToString(pro.EstTimeRemaining), pro.ProjectStatus);
            }*/
                        
        }
    }
}
