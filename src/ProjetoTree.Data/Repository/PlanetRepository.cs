using ProjetoTree.Business.Interfaces;
using ProjetoTree.Business.Models;
using System.Net.Http;

namespace ProjetoTree.Data.Repository
{
    public class PlanetRepository : Repository<Planet>, IPlanetRepository
    {
        public PlanetRepository() : base("/planets/") { }
    }
}