using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using Capstone.Web.DAL;

namespace Capstone.Web.Models
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        private string connectionString;
        private const string SQL_GetWeather = @"select * from weather where parkCode = @parkCode;";

        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<WeatherDayModel> GetWeather(string id, char unit)
        {
            List<WeatherDayModel> output = new List<WeatherDayModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetWeather, connection);
                    cmd.Parameters.AddWithValue("@parkCode", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string parkCode = Convert.ToString(reader["parkCode"]);
                        string day = DateTime.Today.AddDays(Convert.ToDouble(reader["fiveDayForecastValue"])-1).DayOfWeek.ToString();
                        int low = Convert.ToInt32(reader["low"]);
                        int high = Convert.ToInt32(reader["high"]);
                        string forecast = Convert.ToString(reader["forecast"]);

                        WeatherDayModel dayModel = new WeatherDayModel();

                        dayModel.ParkCode = parkCode;
                        dayModel.Day = day;
                        dayModel.Low = low;
                        dayModel.High = high;
                        dayModel.Forecast = forecast;
                        dayModel.Unit = unit;

                        output.Add(dayModel);
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