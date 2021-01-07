using System.Collections.Generic;
using ISI_Tp2.Models;

namespace ISI_Tp2.Repositories
{
    public interface IMusicRepository
    {
        List<Track> GetTracksByName(string name, int userId);
        Track GetFromSpotify(string name,int idUser);
        bool DeleteTrackById(int id);
        List<Track> GetAllTracks();
        bool InsertTrack(string name, string image, string artist, string album, string spoty_id, string spoty_url, string apple_id, string apple_url);
        List<Track> GetTracksById(int id);

        bool UpdateTrackById(int id, string name, string image, string artist, string album, string spotifyId,
            string spotifyUrl);

        Track GetFromYoutube(int id, string name);
    }
}
