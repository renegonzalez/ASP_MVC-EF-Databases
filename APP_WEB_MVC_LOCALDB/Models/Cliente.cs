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

        //Lista direcciones
        public virtual List<DatosDireccion> direcciones { get; set; }

        //Lista contactos
        public virtual List<DatosContacto> contactos { get; set; }

        //Lista datos bancarios
        public virtual List<DatosBancarios> datosBancos { get; set; }

        //Lista Vehiculos
        public virtual List<Vehiculo> vehiculos { get; set; }

    }

    public class DatosDireccion {
        public long id { get; set; }
        public string direccion { get; set; }
        public int? cp { get; set; }
        public string provincia { get; set; }
        public bool prioritario { get; set; }
        public long clienteID { get; set; }
        public virtual Cliente  cliente { get; set; }
    }

    public class DatosContacto {
        public long id { get; set; }
        public long? telefono { get; set; }
        public long? fax { get; set; }
        public long? movil { get; set; }
        public string email { get; set; }
        public bool prioritario { get; set; }
        public long clienteID { get; set; }
        public virtual Cliente cliente { get; set; }
    }

    public class DatosBancarios {
        public long id { get; set; }
        public int banco { get; set; }
        public int sucursal { get; set; }
        public long num_cuenta { get; set; }
        public bool prioritario { get; set; }
        public long clienteID { get; set; }
        public virtual Cliente cliente { get; set; }
    }
}