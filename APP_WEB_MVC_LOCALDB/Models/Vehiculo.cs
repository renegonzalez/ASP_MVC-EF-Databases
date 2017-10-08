using APP_WEB_MVC_LOCALDB.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_WEB_MVC_LOCALDB.Models
{
    public class Vehiculo
    {
        public long id { get; set; }
        public string matricula { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string numBastidor { get; set; }

        //Tipo Vehiculo
        public long tipoVehiculoID { get; set; }
        public virtual TipoVehiculo tipo { get; set; }

        //Cliente
        public long clienteID { get; set; }
        public virtual Cliente cliente { get; set; }
    }

    public class TipoVehiculo
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public Money precioHora { get; set; }

        //Vehiculos del tipo
        public virtual List<Vehiculo> vehiculos { get; set; }
    }

    
}