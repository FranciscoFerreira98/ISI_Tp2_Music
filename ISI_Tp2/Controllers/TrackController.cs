using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ISI_Tp2.Models;
using ISI_Tp2.Repositories;
using Microsoft.AspNetCore.Authorization;


namespace ISI_Tp2.Controllers
{

    /* ################ Métodos ######################
     * Controller para as músicas 
     * GET -> Retornar todas as musicas da base de dados
     * GET -> Procurar musica pelo nome
     * GET -> Procurar pelo id da música
     * POST -> Insere música manualmente
     * PUT -> Editar música já criada 
     * DELETE -> Apagar musica
     */


    [Route("api/[controller]")]
    public class TrackController : ControllerBase
    {
        public TrackController(IMusicRepository repository)
        {
            _repo = repository;
        }

        private readonly IMusicRepository _repo;


        //Devolve todas as musicas
        [Authorize(Roles = "admin,user")]
        [HttpGet]
        public List<Track> GetAllTracks()
        {
            List<Track> tracks = _repo.GetAllTracks();
            return tracks;
        }

        //pesquisar musica caso não exista na nossa bd vai procurar ao spotify a musica e insera na nossa bd
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

        //Procurar musica pelo ID
        [Authorize(Roles = "admin,user")]
        [HttpGet("id/{id}")]
        public List<Track> GetTracksById(int id)
        {
            List<Track> tracks = _repo.GetTracksById(id);
            return tracks;
        }


        //Inserir musica
        [Authorize(Roles = "admin")]
        [HttpPost]
        public bool InsertTrack([FromBody] InputTrack input)
        {
            _repo.InsertTrack(input.Name, input.Image, input.Artist, input.Album, input.SpotifyId, input.SpotifyUrl, input.YoutubeId, input.YoutubeUrl);
            return true;
        }

        //Atualizar Musica
        [Authorize(Roles = "admin")]
        [HttpPut]
        public bool UpdateTrackById([FromBody] InputTrack input)
        {
            _repo.UpdateTrackById(input.IdTrack, input.Name, input.Image, input.Artist, input.Album, input.SpotifyId, input.SpotifyUrl, input.YoutubeId, input.YoutubeUrl);
            return true;
        }

        //Apagar musica
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public bool DeleteTrackById(int id)
        {   
            _repo.DeleteTrackById(id);
            return true;
        }

    }
}
