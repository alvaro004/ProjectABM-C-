using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectABM.DAL
{
    public class Venta
    {
        public int venta_id { get; set; } // Primary Key
        public DateTime venta_fecha { get; set; }
        public int cliente_cliente_id { get; set; } // Foreign Key

        // Navigation property (optional but recommended)
        public Cliente Cliente { get; set; }
    }

}
