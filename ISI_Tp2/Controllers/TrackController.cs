using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using ISI_Tp2.Models;
using ISI_Tp2.Repositories;
using Microsoft.AspNetCore.Authorization;


namespace ISI_Tp2.Controllers
{
    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {
        public TrackController(IMusicRepository repository)
        {
            _repo = repository;
        }

        private readonly IMusicRepository _repo;

        [Authorize(Roles = "admin,user")]
        [HttpGet]
        public List<Track> GetAllTracks()
        {
            List<Track> tracks = _repo.GetAllTracks();
            return tracks;
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet("{name}/{idUser}")]
        public List<Track> SearchTracks(string name,int idUser)
        {
            List<Track> tracks = _repo.GetTracksByName(name, idUser);
            if (tracks.Count == 0)
            {
                tracks.Add(_repo.GetFromSpotify(name, idUser));
                Track trackYoutube = _repo.GetFromYoutube(tracks[0].IdTrack, name);
                tracks[0].YoutubeUrl = trackYoutube.YoutubeUrl;
                tracks[0].YoutubeId = trackYoutube.YoutubeId;
            }
            return tracks;
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet("id/{id}")]
        public List<Track> GetTracksById(int id)
        {
            List<Track> tracks = _repo.GetTracksById(id);
            return tracks;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public bool InsertTrack([FromBody] InputTrack input)
        {
            _repo.InsertTrack(input.Name, input.Image, input.Artist, input.Album, input.SpotifyId, input.SpotifyUrl, input.YoutubeId, input.YoutubeUrl);
            return true;
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public bool UpdateTrackById([FromBody] InputTrack input)
        {
            _repo.UpdateTrackById(input.IdTrack, input.Name, input.Image, input.Artist, input.Album, input.SpotifyId, input.SpotifyUrl, input.YoutubeId, input.YoutubeUrl);
            return true;
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public bool DeleteTrackById(int id)
        {
            _repo.DeleteTrackById(id);
            return true;
        }





    }
}
