using System.Threading.Tasks;
using ProjetoTree.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProjetoTree.Business.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;

namespace ProjetoTree.Api.Controllers
{
    [Route("api/travels")]
    public class TravelController : MainController
    {
        private readonly ITravelService _travelService;
        public TravelController(ITravelService travelService, INotificador notificador) : base(notificador)
        {
            _travelService = travelService;
        }

        [HttpGet]
        [Route("number-stops/{distance:double}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Travel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<Travel> NumberOfStops(double distance)
        {
            return _travelService.NumberOfStops(distance);
        }

        [HttpGet]
        [Route("best-starship")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(double))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Travel BetterStarship([BindRequired] double passengersQuantity,
                                                 [BindRequired] double distance)
        {
            return _travelService.FindStarship_StopsPriority(passengersQuantity, distance);
        }
    }
}