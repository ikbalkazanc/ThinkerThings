using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkerThings.API.Models
{
    public class Command
    {
        public string type { get; set; }
        public int buttonNumber { get; set; }
        public bool value { get; set; }
        public double tempature { get; set; }
        public int speed { get; set; }

    }
}
