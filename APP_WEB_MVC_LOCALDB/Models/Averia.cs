using APP_WEB_MVC_LOCALDB.Models.Enum;
using APP_WEB_MVC_LOCALDB.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_WEB_MVC_LOCALDB.Models
{
    public class Averia
    {
        public long id { get; set; }
        public string descripcion { get; set; }
        public DateTime? fecha { get; set; }
        public Money importe { get; set; }
        public AveriaStatus estado { get; set; }
    }
}