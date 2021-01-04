using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISI_Tp2.Models;
using ISI_Tp2.Repositories;

namespace ISI_Tp2.Controllers
{
    public class TrackController : ControllerBase
    {
        public TrackController(IMusicRepository repository)
        {
            _repo = repository;
        }

        private readonly IMusicRepository _repo;

        

        [HttpGet("searchTracks/{name}")]
        public List<Track> SearchTracks(string name)
        {
            List<Track> tracks = _repo.GetTracksByName(name);
            if (tracks.Count == 0)
            {
                tracks.Add(_repo.GetFromSpotify(name));
            }
            return tracks;
        }

        [HttpDelete("deleteTrack/{id}")]
        public bool DeleteTrackById(int id)
        {
            _repo.DeleteTrackById(id);
            return true;
        }

        [HttpGet("searchTracks")]
        public List<Track> GetAllTracks()
        {
            List<Track> tracks = _repo.GetAllTracks();
            return tracks;
        }

        [HttpPost("searchTracks")]
        public bool InsertTrack(string name, string image, string artist, string album, string spoty_id, string spoty_url, string apple_id, string apple_url)
        {
            _repo.InsertTrack(name, image, artist, album, spoty_id, spoty_url, apple_id, apple_url);
            return true;
        }
    }
}
