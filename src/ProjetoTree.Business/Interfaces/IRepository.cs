using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ProjetoTree.Business.Models;

namespace ProjetoTree.Business.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        List<T> GetAllData();
        HttpResponseMessage GetAsyncRequestSWAPI();
    }



}