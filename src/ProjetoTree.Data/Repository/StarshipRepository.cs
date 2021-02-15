using ProjetoTree.Business.Interfaces;
using ProjetoTree.Business.Models;
using System.Net.Http;

namespace ProjetoTree.Data.Repository
{
    public class StarshipRepository : Repository<StarshipVo>, IStarshipRepository
    {
        public StarshipRepository() : base("/starships/") 
        {
        }

    }
}