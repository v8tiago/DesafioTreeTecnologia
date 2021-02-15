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
    [Route("api/planets")]
    public class PlanetController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IPlanetRepository _planetaRepository;
        public PlanetController(IMapper mapper, IPlanetRepository planetaRepository, INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _planetaRepository = planetaRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PlanetDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PlanetDTO>> ObterTodos()
        {
            var list =  _mapper.Map<List<PlanetDTO>>( _planetaRepository.GetAllData());

            if (!list.Any()) return NotFound();

            return list;
        }
    }
}