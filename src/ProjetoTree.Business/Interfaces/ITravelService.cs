using ProjetoTree.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoTree.Business.Interfaces
{
    public interface ITravelService
    {
        List<Travel> NumberOfStops(double distance);
        Travel FindStarship_StopsPriority(double passengers, double distance);
    }
}
