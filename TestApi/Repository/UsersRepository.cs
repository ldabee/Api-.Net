using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestApi.Models;
using System.Data;

namespace TestApi.Repository
{
    public class UsersRepository
    {
        public static List<Users> GetAllUsers()
        {
            List<Users> People = new List<Users>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["testapi"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Users_GetAll", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Users user = new Users()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = reader["LastName"]?.ToString(),
                            FirstName = reader["FirstName"]?.ToString(),
                        };
                        People.Add(user);

                    }
                    connection.Close();
                }
            }

            return People;
        }

        public static List<Users> InsertUser(Users User)
        {
            List<Users> People = new List<Users>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["testapi"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Users_Insert",connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("FirstName", User.FirstName);
                    cmd.Parameters.AddWithValue("LastName", User.LastName);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Users user = new Users()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = reader["LastName"]?.ToString(),
                            FirstName = reader["FirstName"]?.ToString(),
                        };
                        People.Add(user);
                    }
                    connection.Close();
                }
            }
            return People;
        }

        public static List<Users> UpdateUser(Users User)
        {
            List<Users> People = new List<Users>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["testapi"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Users_Update", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("FirstName", User.FirstName);
                    cmd.Parameters.AddWithValue("LastName", User.LastName);
                    cmd.Parameters.AddWithValue("Id", User.Id);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Users user = new Users()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = reader["LastName"]?.ToString(),
                            FirstName = reader["FirstName"]?.ToString(),
                        };
                        People.Add(user);
                    }
                    connection.Close();
                }
            }
            return People;
        }

        public static List<Users> DeleteUser(Users User)
        {
            List<Users> People = new List<Users>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["testapi"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Users_Delete", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id", User.Id);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Users user = new Users()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = reader["LastName"]?.ToString(),
                            FirstName = reader["FirstName"]?.ToString(),
                        };
                        People.Add(user);
                    }
                    connection.Close();
                }
            }
            return People;
        }


    }

}