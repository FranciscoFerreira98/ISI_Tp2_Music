/// MusicRepository
/// Métedos
/// Francisco Ferreira

using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ISI_Tp2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ISI_Tp2.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient httpClient;

        public MusicRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["SpotifyToken"]);
        }

        public List<Track> GetTracksByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MusicDb")))
            {
                using (SqlCommand command = new SqlCommand("dbo.SearchTrackByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", name);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Track> tracks = new List<Track>();
                    while (reader.Read())
                    {
                        tracks.Add(new Track
                        {
                            Album = reader.GetString(0),
                            //se for null retorna null se não for null retorna appleURL
                            AppleUrl = reader.IsDBNull(1) ? null : reader.GetString(1),
                            SpotifyUrl = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Artist = reader.GetString(3),
                            Image = reader.GetString(4),
                            Name = reader.GetString(5),

                        });
                    }

                    return tracks;
                }
            }
        }
        public List<Track> GetTracksById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MusicDb")))
            {
                using (SqlCommand command = new SqlCommand("dbo.SearchTrackById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Track> tracks = new List<Track>();
                    while (reader.Read())
                    {
                        tracks.Add(new Track
                        {
                            IdTrack = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Image = reader.GetString(2),
                            Artist = reader.GetString(3),
                            Album = reader.GetString(4),
                            //se for null retorna null se não for null retorna appleURL
                            SpotifyId = reader.IsDBNull(5) ? null : reader.GetString(5),
                            SpotifyUrl = reader.IsDBNull(6) ? null : reader.GetString(6),
                            AppleId = reader.IsDBNull(7) ? null : reader.GetString(7),
                            AppleUrl = reader.IsDBNull(8) ? null : reader.GetString(8)

                        });
                    }

                    return tracks;
                }
            }
        }

        public Track GetFromSpotify(string name)
        {
            var response = httpClient.GetAsync("https://api.spotify.com/v1/search?type=track&q=" + name).Result;
            string res = "";
            using (HttpContent content = response.Content)
            {
                Task<string> resulTask = content.ReadAsStringAsync();
                res = resulTask.Result;
            }
            SpotifyMusic spotifyMusic = JsonConvert.DeserializeObject<SpotifyMusic>(res);

            Track track = new Track
            {
                Album = spotifyMusic.tracks.items[0].album.name,
                SpotifyUrl = spotifyMusic.tracks.items[0].external_urls.spotify,
                Artist = spotifyMusic.tracks.items[0].album.artists[0].name,
                Image = spotifyMusic.tracks.items[0].album.images[0].url,
                Name = spotifyMusic.tracks.items[0].name,
                SpotifyId = spotifyMusic.tracks.items[0].album.id
            };

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MusicDb")))
            {
                using (SqlCommand command = new SqlCommand("dbo.InsertTrack", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Album", track.Album);
                    command.Parameters.AddWithValue("@SpotifyUrl", track.SpotifyUrl);
                    command.Parameters.AddWithValue("@Artist", track.Artist);
                    command.Parameters.AddWithValue("@Image", track.Image);
                    command.Parameters.AddWithValue("@Name", track.Name);
                    command.Parameters.AddWithValue("@SpotifyId", track.SpotifyId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return track;
        }

        public bool DeleteTrackById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MusicDb")))
            {
                using (SqlCommand command = new SqlCommand("dbo.DeleteTrackById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    return true;
                }
            }
        }
        public List<Track> GetAllTracks()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MusicDb")))
            {
                using (SqlCommand command = new SqlCommand("dbo.GetAllTracks", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<Track> tracks = new List<Track>();
                    while (reader.Read())
                    {
                        tracks.Add(new Track
                        {
                            IdTrack = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Image = reader.GetString(2),
                            Artist = reader.GetString(3),
                            Album = reader.GetString(4),
                            //se for null retorna null se não for null retorna appleURL
                            SpotifyId = reader.IsDBNull(5) ? null : reader.GetString(5),
                            SpotifyUrl = reader.IsDBNull(6) ? null : reader.GetString(6),
                            AppleId = reader.IsDBNull(7) ? null : reader.GetString(7),
                            AppleUrl = reader.IsDBNull(8) ? null : reader.GetString(8)
                            
                        });
                    }
                    return tracks;
                }
            }
        }
        public bool UpdateTrackById(int id, string name, string image, string artist, string album, string spotifyId, string spotifyUrl)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("MusicDb")))
            {
                using (SqlCommand command = new SqlCommand("dbo.UpdateTrackById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Image", image);
                    command.Parameters.AddWithValue("@Artist", artist);
                    command.Parameters.AddWithValue("@Album", album);
                    command.Parameters.AddWithValue("@SpotifyId", spotifyId);
                    command.Parameters.AddWithValue("@SpotifyUrl", spotifyUrl);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    return true;
                }
            }
        }

    }
}
