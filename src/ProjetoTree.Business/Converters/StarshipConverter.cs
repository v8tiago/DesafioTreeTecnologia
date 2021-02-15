using ProjetoTree.Business.Models;
using System.Runtime.Serialization;

namespace ProjetoTree.Business.Converters
{
    public class StarshipConverter
    {
        public StarshipVo _starshipVo;
        public StarshipConverter(StarshipVo starshipVo)
        {
            _starshipVo = starshipVo;
        }

        public Starship ConvertToStarship()
        {
            var starship = new Starship();
            starship.MGLT = ConverToDouble( _starshipVo.MGLT);
            starship.model = _starshipVo.model;
            starship.name = _starshipVo.name;
            starship.passengers = ConverToDouble(_starshipVo.passengers);
            return starship;
        }

        public double ConverToDouble(string value)
        {
            double number;

            var result = double.TryParse(value, out number);

            if (result) return number;

            return 0;

        }
    }
}
