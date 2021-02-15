using ProjetoTree.Business.Interfaces;
using ProjetoTree.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoTree.Business.Services
{
    public class StarshipService : BaseService
    {
        private readonly IStarshipRepository _starshipRepository;

        public StarshipService(IStarshipRepository starshipRepository, INotificador notificador) : base(notificador)
        {
            _starshipRepository = starshipRepository;
        }

        public IEnumerable<StarshipVo> ObterTodos()
        {
             return  _starshipRepository.GetAllData();
        }
    }
}
