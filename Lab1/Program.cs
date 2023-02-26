/* Name - Zeel Sutariya
 * This is Lab 1 program.cs file.
 * Student Id - 100846187
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        public static List<Program> programs = new List<Program>();
        private int Id;
        private string projectName;
        private double budget;
        private double spent;
        private double estTimeRemaining;
        private string projectStatus;

        public Program()
        {

        }
        public Program(string projectName1, string budget1, string spent1, string estTimeRemaining1, string projectStatus1)
        {
            this.projectName = projectName1;
            this.budget = Convert.ToDouble(budget1);
            this.spent = Convert.ToDouble(spent1);
            this.estTimeRemaining = Convert.ToDouble(estTimeRemaining1);
            this.projectStatus = projectStatus1;
        }

        internal string ProjectName
        {
            get { return projectName; }
            set { this.projectName = value; }
        }


        public double Budget
        {
            get { return budget; }
            set { this.budget = value; }
        }

        public double Spent
        {
            get { return spent; }
            set { this.spent = value; }
        }

        public double EstTimeRemaining
        {
            get { return estTimeRemaining; }
            set { estTimeRemaining = value; }
        }

        public string ProjectStatus
        {
            get
            { return projectStatus; }
            set { this.projectStatus = value; }
        }

        public static Program FindProgram(string name)
        {
            return programs.Find(t => t.ProjectName == name);
        }
    }
}
