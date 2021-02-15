using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTree.Business.Models
{
    public class People : Entity
    {
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public IEnumerable<Uri> films { get; set; }

    }
}
