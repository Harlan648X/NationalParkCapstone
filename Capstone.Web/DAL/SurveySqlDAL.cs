using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        private string connectionString;
        private const string SQL_SaveSurvey = "Insert into survey_result Values (@parkCode, @emailAddress, @state, @activityLevel);";

        private const string SQL_GetSurvey = @"select top 1 parkName, park.parkCode from park
                                                join survey_result on park.parkCode=survey_result.parkCode
                                                group by parkname, park.parkCode
                                                order by count(parkname) desc;";

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool SaveSurvey(SurveyModel newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SaveSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", newSurvey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", newSurvey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", newSurvey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newSurvey.ActivityLevel);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public SurveyModel GetSurvey()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetSurvey, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    SurveyModel surveyResult = new SurveyModel();


                    while (reader.Read())
                    {
                        string parkName = Convert.ToString(reader["parkName"]);
                        string parkCode = Convert.ToString(reader["parkCode"]);


                        surveyResult.ParkName = parkName;
                        surveyResult.ParkCode = parkCode;
                    }
                    return surveyResult;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }


    }
}