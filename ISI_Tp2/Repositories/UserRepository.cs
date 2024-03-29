﻿using System.Collections.Generic;
using System.Data;
using ISI_Tp2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ISI_Tp2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public List<User> InsertUser(string name,  string password, string email)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MusicDb")))
            {
                using (SqlCommand command = new SqlCommand("dbo.InsertUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", name.ToLower());
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Email", email.ToLower());

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<User> users = new List<User>();
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Name = reader.GetString(0),
                            Email = reader.GetString(1),
                            Password = reader.GetString(2),
                            Role = reader.GetString(3),
                        });
                    }

                    return users;
                }
            }
        }

        //GetUser para efetuar o login
        public User GetUser(string email)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MusicDb")))
            {
                using (SqlCommand command = new SqlCommand("dbo.GetUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email.ToLower());

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    User user = new User();
                    while (reader.Read())
                    {
                        user = new User
                        {
                            Email = reader.GetString(0),
                            Password = reader.GetString(1),
                            Role = reader.GetString(2),
                            IdUser = reader.GetInt32(3)
                        };
                    }

                    return user;
                }
            }
        }
    }
}
