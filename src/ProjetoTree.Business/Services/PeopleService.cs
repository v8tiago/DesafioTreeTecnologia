using ProjetoTree.Business.Interfaces;
using ProjetoTree.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoTree.Business.Services
{
    public class PeopleService : BaseService
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleService(IPeopleRepository peopleRepository, INotificador notificador) : base(notificador)
        {
            _peopleRepository = peopleRepository;
        }

        public IEnumerable<People> ObterTodos()
        {
            return _peopleRepository.GetAllData();
        }
    }
}
