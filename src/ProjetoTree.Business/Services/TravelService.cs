using AutoMapper;
using ProjetoTree.Business.Converters;
using ProjetoTree.Business.Interfaces;
using ProjetoTree.Business.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTree.Business.Services
{
    public class TravelService : ITravelService
    {
        private readonly IStarshipRepository _starshipRepository;

        public TravelService(IStarshipRepository starshipRepository)
        {
            _starshipRepository = starshipRepository;
        }

        public async Task<List<Starship>> GetStarships()
        {
            var starships = new List<Starship>();

            _starshipRepository.GetAllData().ForEach(s =>starships.Add(new StarshipConverter(s).ConvertToStarship()));

            return starships;
        }

        public Travel FindStops(double distance, Starship starship)
        {
            if (distance <= 0) return null;

            return new Travel(distance, starship);
        }

        public List<Travel> NumberOfStops(double distance)
        {
            var listStops = new List<Travel>();
            GetStarships().Result.ForEach(s => listStops.Add(FindStops(distance, s)));

            return listStops;
        }


        public Travel FindStarship_StopsPriority(double passengers, double distance)
        {
            return (from s in NumberOfStops(distance)
                    where s.starship.passengers >= passengers && s.starship.MGLT != 0
                    orderby s.starship.passengers
                    select s)
                    .First();

        }

    }
}
