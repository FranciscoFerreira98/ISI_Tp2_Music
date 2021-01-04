using System.Collections.Generic;
using ISI_Tp2.Models;

namespace ISI_Tp2.Repositories
{
    public interface IMusicRepository
    {
        List<Track> GetTracksByName(string name);
        Track GetFromSpotify(string name);
        bool DeleteTrackById(int id);
        List<Track> GetAllTracks();
        bool InsertTrack(string name, string image, string artist, string album, string spoty_id, string spoty_url, string apple_id, string apple_url);
    }
}
