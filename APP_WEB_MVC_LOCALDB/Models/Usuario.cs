using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_WEB_MVC_LOCALDB.Models
{
    public class Usuario
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string passworkd { get; set; }
        public string email { get; set; }

    }
}