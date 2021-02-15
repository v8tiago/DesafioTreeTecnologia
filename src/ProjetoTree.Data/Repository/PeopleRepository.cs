using ProjetoTree.Business.Interfaces;
using ProjetoTree.Business.Models;
using System.Net.Http;

namespace ProjetoTree.Data.Repository
{
    public class PeopleRepository : Repository<People>, IPeopleRepository
    {
        public PeopleRepository() : base("/people/") { }
    }
}