using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using Capstone.Web.DAL;

namespace Capstone.Web.Models
{
    public class ParkListSqlDAL: IParkListDAL
    {
        private string connectionString;
        private const string SQL_GetAllParks = @"Select parkCode, parkName, state, parkDescription from park;";

        public ParkListSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ParkListModel> GetAllParks()
        {
            List<ParkListModel> output = new List<ParkListModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllParks, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string parkCode = Convert.ToString(reader["parkCode"]);
                        string parkName = Convert.ToString(reader["parkName"]);
                        string state = Convert.ToString(reader["state"]);
                        string parkDescription = Convert.ToString(reader["parkDescription"]);

                        ParkListModel park = new ParkListModel();

                        park.ParkCode = parkCode;
                        park.ParkName = parkName;
                        park.State = state;
                        park.ParkDescription = parkDescription;

                        output.Add(park);
                    }
                    return output;
                }
            }

            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}