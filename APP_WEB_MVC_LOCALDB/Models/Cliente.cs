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
    }
}