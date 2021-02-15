namespace ProjetoTree.Business.Models
{
    public class Starship
    {
        public string name { get; set; }
        public string model { get; set; }
        public double passengers { get; set; }
        public double MGLT { get; set; }

        public double NumeroParadas(double distancia)
        {
            return distancia/MGLT;
        }
    }
}
