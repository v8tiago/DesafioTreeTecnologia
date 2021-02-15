using System;
using System.Collections.Generic;

namespace ProjetoTree.Api.DTOs
{
    public class PlanetDTO
    {
        public string name { get; set; }
        public string Rotation_period { get; set; }
        public string Orbital_period { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string Surface_water { get; set; }
        public string Population { get; set; }
        public IEnumerable<Uri> Residents { get; set; }
        public IEnumerable<Uri> films { get; set; }
    }
}
