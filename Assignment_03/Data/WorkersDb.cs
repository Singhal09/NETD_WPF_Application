/**
 * Author: Sanya Singhal
 * Date: 04 November, 2022
 * Course: NETD 3202
 * Description: WorkerDb class to store the workers data in the database
 *             
*/

#region Using Statements
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Assignment_03
{
    //Inheriting the workerList class
    class WorkersDatabase : WorkersList
    {
        /// <summary>
        /// Setting the connection string
        /// </summary>
        /// <returns></returns>
        private static string? GetConnectionString()
        {

            string? returnValue = null;

            
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[1];

            
            if (settings != null)
            {
                returnValue = settings.ConnectionString;
            }

            return returnValue;
        }

        /// <summary>
        /// Extracting the workers detail from the database and storing it in the list.
        /// </summary>
        internal static new List<PieceworkWorker> AllWorkers
        {
            get
            {
                //Creating a pieceworkworker list
                List<PieceworkWorker> workersFromDb = new List<PieceworkWorker>();
                using (var dbConnection = new SqlConnection(GetConnectionString()))
                {
                    //Extracting all the columns and data
                    string query = "SELECT * FROM [WorkersTable]";
                    var command = new SqlCommand(query, dbConnection);
                    command.CommandType = CommandType.Text;
                    dbConnection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //checking if there is any data
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PieceworkWorker newWorker = new PieceworkWorker();
                                //Reading the data of each column
                                newWorker.Name = reader.GetString(1);
                                newWorker.Message = reader.GetInt32(2);
                                newWorker.GetPay();
                                //adding to the list
                                workersFromDb.Add(newWorker);
                            }
                        }
                    }
                }
                //returning the list
                return workersFromDb;
            }
        }

        /// <summary>
        /// Adds a worker object into the list.
        /// </summary>
        /// <param name="worker">A worker</param>
        /// <returns>true if successful, false if not</returns>
        internal static new bool Add(PieceworkWorker worker)
        {
            //Adding the worker object
            listOfWorkers.Add(worker);
            //Inserting the details into the database
            InsertIntoDb(worker);

            return true;
        }

       
        /// <summary>
        /// Refreshing the list of workers
        /// </summary>
        /// <returns>List of workers</returns>
        internal static new List<PieceworkWorker> RefreshList()
        {
            listOfWorkers = AllWorkers;
            return listOfWorkers;
        }

        /// <summary>
        /// Function to add a new worker to the worker database
        /// </summary>
        /// <param name="insertWorker">a worker object to be inserted</param>
        /// <returns>true if successful</returns>
        private static bool InsertIntoDb(PieceworkWorker insertWorker)
        {
            bool returnValue = false;

            //declaring the sql connection
            SqlConnection dbConnection = new SqlConnection(GetConnectionString());

            // Create new SQL command and assign it paramaters
            SqlCommand command = new SqlCommand("INSERT INTO [WorkersTable] VALUES(@name, @messages, @pay)", dbConnection);

            // Set the values for the parameters in the query above.
            command.Parameters.AddWithValue("@name", insertWorker.Name);
            command.Parameters.AddWithValue("@messages", insertWorker.Message);
            command.Parameters.AddWithValue("@pay", insertWorker.Pay);
            // TO DO This line assumes the worker class has no Date property. Careful!
            //command.Parameters.AddWithValue("@entryDate", DateTime.Now);

            // Try to insert the new record, return result
            try
            {
                dbConnection.Open();
                returnValue = command.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }

            // Return the true if this worked, false if it failed
            return returnValue;
        }
    }
}
