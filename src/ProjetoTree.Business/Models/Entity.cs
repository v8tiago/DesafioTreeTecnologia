using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProjetoTree.Business.Models
{
    public abstract class Entity
    {
        public string name { get; set; }
        public string edited { get; set; }
        public string url { get; set; }
    }
}