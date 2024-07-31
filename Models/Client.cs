using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GullemDapperAPI.Models
{
    public class Client
    {
        public int ID {get; set;}
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}