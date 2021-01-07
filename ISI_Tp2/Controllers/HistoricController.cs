using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ISI_Tp2.Models;
using ISI_Tp2.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ISI_Tp2.Controllers
{
    [Route("api/[controller]")]
    public class HistoricController : ControllerBase
    {
        public HistoricController(IHistoricRepository repository)
        {
            _repo = repository;
        }

        private readonly IHistoricRepository _repo;


        [Authorize(Roles = "admin,user")]
        [HttpGet("{id}")]
        public List<Historic> GetTracksById(int id)
        {
            List<Historic> historics = _repo.GetHistoricByIdUser(id);
            return historics;
        }
        [Authorize(Roles = "admin,user")]
        [HttpDelete("{id}")]
        public bool DeleteTrackById(int id)
        {
            _repo.DeleteHistoricById(id);
            return true;
        }
    }
}
