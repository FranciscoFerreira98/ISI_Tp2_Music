using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ISI_Tp2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ISI_Tp2.Repositories
{
    public class HistoricRepository : IHistoricRepository
    {
        private readonly IConfiguration _configuration;
        public HistoricRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Historic> GetHistoricByIdUser(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MusicDb")))
            {
                using (SqlCommand command = new SqlCommand("dbo.GetHistoricByIdUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Historic> historics = new List<Historic>();
                    while (reader.Read())
                    {
                        historics.Add(new Historic
                        {
                            IdHistoric = reader.GetInt32(0),
                            Date = reader.GetDateTime(1),
                            UserId = reader.GetInt32(2),
                            TrackId = reader.GetInt32(3)

                        });
                    }

                    return historics;
                }
            }
        }
        public bool DeleteHistoricById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MusicDb")))
            {
                using (SqlCommand command = new SqlCommand("dbo.DeleteHistoricById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    return true;
                }
            }
        }
    }
}
