using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTree.Business.Models
{
    public class Travel
    {
        public Starship starship { get; }
        public double distance { get; }
        public double stops { get; private set; }


        public Travel(double distance, Starship starship)
        {
            this.starship = starship;
            this.distance = distance;

            GetNumberOfStops();
        }

        public void GetNumberOfStops()
        {
            if (starship.MGLT == 0) stops = 0;
            else
                stops = Math.Floor(distance / starship.MGLT);
        }
    }
}
