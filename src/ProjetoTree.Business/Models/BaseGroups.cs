using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTree.Business.Models
{
    public class BaseGroups<T>
    {
        public int count { get; set; }
        public Uri next { get; set; }
        public Uri previous { get; set; }
        public List<T> results { get; set; }
    }
}
