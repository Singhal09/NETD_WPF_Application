/**
 * Author: Sanya Singhal
 * Date: 04 November, 2022
 * Course: NETD 3202
 * Description: WorkerList class to store the workers data in a list.
*/

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Assignment_03
{
    class WorkersList
    {
        #region Declaration
        //creating a pieceworkWorker list
        protected static List<PieceworkWorker> listOfWorkers = new List<PieceworkWorker>();
        #endregion

        #region Properties
        /// <summary>
        /// Returns the list of workers
        /// </summary>
        protected internal static List<PieceworkWorker> AllWorkers
        {
            get
            {
                return listOfWorkers;
            }
        }

        
        /// <summary>
        /// Gets the total number of workers
        /// </summary>
        protected internal static int WorkerCounts
        {
            get
            {
                return AllWorkers.Count;
            }
        }

        
        /// <summary>
        /// Gets the total mesages of all the workers
        /// </summary>
        protected internal static double TotalMessages
        {
            get
            {
                double totalMessages = 0;

                foreach (PieceworkWorker worker in AllWorkers)
                {
                    totalMessages += worker.Message;
                }

                return totalMessages;
            }
        }

        /// <summary>
        /// Gets the total pay of all the workers from the list
        /// </summary>
        protected internal static double TotalPays
        {
            get
            {
                double overallPay = 0;

                foreach (PieceworkWorker worker in AllWorkers)
                {
                    overallPay += worker.Pay;
                }

                return overallPay;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Adds a worker object to the lis of workers list
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        protected internal static bool Add(PieceworkWorker worker)
        {
            listOfWorkers.Add(worker);

            return true;
        }

        
        /// <summary>
        /// Refreshes the list of all the workers
        /// </summary>
        /// <returns>List of workers</returns>
        protected internal static List<PieceworkWorker> RefreshList()
        {
            return listOfWorkers;
        }
        #endregion
    }
}
