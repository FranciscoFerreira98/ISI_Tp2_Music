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
    }
}
