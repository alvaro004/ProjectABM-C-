using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectABM.DAL
{
    public class ArticuloHasVenta
    {
        public int articulo_articulo_id { get; set; } // Foreign Key
        public int venta_venta_id { get; set; } // Foreign Key

        // Navigation properties (optional but recommended)
        public Articulo Articulo { get; set; }
        public Venta Venta { get; set; }
    }
}
