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
    [Route("api/people")]
    public class PeopleController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IPeopleRepository _peopleRepository;
        public PeopleController(IMapper mapper, IPeopleRepository peopleRepository, INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _peopleRepository = peopleRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PeopleDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PeopleDTO>> ObterTodos()
        {
            var list =  _mapper.Map<List<PeopleDTO>>(_peopleRepository.GetAllData());

            if (!list.Any()) return NotFound();

            return list;
        }
    }
}