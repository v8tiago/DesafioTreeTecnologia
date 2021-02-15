using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProjetoTree.Api.DTOs;
using ProjetoTree.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ProjetoTree.Api.Controllers
{
    [Route("api/starship")]
    public class StarshipController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IStarshipRepository _starshipRepository;
        public StarshipController(IMapper mapper, IStarshipRepository starshipRepository, INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _starshipRepository = starshipRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StarshipDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<StarshipDTO>>> ObterTodos()
        {
            var list = _mapper.Map<List<StarshipDTO>>(_starshipRepository.GetAllData());

            if (!list.Any()) return NotFound();

            return list;
        }
    }
}