using APP_WEB_MVC_LOCALDB.Models.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_WEB_MVC_LOCALDB.Models
{
    public abstract class MedioPago
    {
        public Money acumulado { get; set; }
    }
}