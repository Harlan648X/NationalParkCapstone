using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using Capstone.Web.DAL;
using System.Web.Mvc;
using System.Configuration;


namespace Capstone.Web.Models
{
    public class ParkListSqlDAL : IParkListDAL
    {
        private string connectionString;
        private const string SQL_GetAllParks = @"Select parkCode, parkName, state, parkDescription from park;";
        private const string SQL_GetPark = @"select * from park where parkCode = @parkCode;";

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

        public ParkListModel GetPark(string parkCode, char unit)
        {
            ParkListModel output = new ParkListModel();
            // output = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetPark, connection);

                    cmd.Parameters.AddWithValue("@parkCode", parkCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    { //output = new ParkListModel
                        string pCode = Convert.ToString(reader["parkCode"]);
                        string parkName = Convert.ToString(reader["parkName"]);
                        string state = Convert.ToString(reader["state"]);
                        string parkDescription = Convert.ToString(reader["parkDescription"]);
                        int acreage = Convert.ToInt32(reader["acreage"]);
                        int elevation = Convert.ToInt32(reader["elevationInFeet"]);
                        int milesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        int numberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        int yearFounded = Convert.ToInt32(reader["yearFounded"]);
                        int annualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                        string inspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        string inspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        int entryFee = Convert.ToInt32(reader["entryFee"]);
                        int numberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                        string climate = Convert.ToString(reader["climate"]);

                        output.ParkCode = pCode;
                        output.ParkName = parkName;
                        output.State = state;
                        output.ParkDescription = parkDescription;
                        output.Acreage = acreage;
                        output.Elevation = elevation;
                        output.MilesOfTrail = milesOfTrail;
                        output.NumberOfCampsites = numberOfCampsites;
                        output.YearFounded = yearFounded;
                        output.AnnualVisitorCount = annualVisitorCount;
                        output.InspirationalQuote = inspirationalQuote;
                        output.InspirationalQuoteSource = inspirationalQuoteSource;
                        output.EntryFee = entryFee;
                        output.NumberOfAnimalSpecies = numberOfAnimalSpecies;
                        output.Climate = climate;
                        output.Unit = unit; //assign the unit passed in from Home Controller
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