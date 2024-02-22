using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectABM.DAL
{
    public class Cliente
    {
        public int cliente_id { get; set; } // Primary Key
        public string cliente_nom { get; set; }
        public string cliente_apellido { get; set; }
    }
}
