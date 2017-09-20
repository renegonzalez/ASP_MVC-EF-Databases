using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APP_WEB_MVC_LOCALDB.Models
{
    
    public class Cliente
    {
        
        public long id { get; set; }
        
        public string nombre { get; set; }

        public string nif { get; set; }

        //Objeto dirección
        public virtual Direccion direcciones { get; set; }

        //Objeto contacto
        public virtual Contacto contactos { get; set; }

        //Objeto datos bancarios
        public virtual DatosBancarios datosBancos { get; set; }
    }

    public partial class Direccion {
        public long id { get; set; }
        public string direccion { get; set; }
        public int? cp { get; set; }
        public string provincia { get; set; }
        public virtual Cliente  cliente { get; set; }
    }

    public partial class Contacto {
        public long id { get; set; }
        public long? telefono { get; set; }
        public long? fax { get; set; }
        public long? movil { get; set; }
        public virtual Cliente cliente { get; set; }
    }

    public partial class DatosBancarios {
        public long id { get; set; }
        public int banco { get; set; }
        public int sucursal { get; set; }
        public long num_cuenta { get; set; }
        public virtual Cliente cliente { get; set; }
    }
}