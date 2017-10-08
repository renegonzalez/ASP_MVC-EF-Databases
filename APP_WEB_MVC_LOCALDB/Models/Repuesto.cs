using APP_WEB_MVC_LOCALDB.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_WEB_MVC_LOCALDB.Models
{
    public class Repuesto
    {
        public long id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public Money precio { get; set; }
    }
}