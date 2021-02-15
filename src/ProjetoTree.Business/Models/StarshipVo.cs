using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTree.Business.Models
{
    public class StarshipVo : Entity
	{
        public string model { get; set; }
        public string manufacturer { get; set; }
        public string cost_in_credits { get; set; }
        public string length { get; set; }
        public string max_atmosphering_speed { get; set; }
        public string crew { get; set; }
		public string passengers { get; set; }
        public string cargo_capacity { get; set; }
        public string consumables { get; set; }
        public string hyperdrive_rating { get; set; }
        public string MGLT { get; set; }
        public string starship_class { get; set; }
        public IEnumerable<Uri> pilots { get; set; }
        public IEnumerable<Uri> films { get; set; }
    }
}
