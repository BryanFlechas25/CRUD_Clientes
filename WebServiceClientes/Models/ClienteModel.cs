using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceClientes.Models
{
    public class ClienteModel
    {
        public int Id_cliente { get; set; }
        public string Tipo_de_documento { get; set; }
        public string Documento { get; set; }
        public string Primer_nombre { get; set; }
        public string Segundo_nombre { get; set; }
        public Nullable<int> Celular { get; set; }
        public string Dirección { get; set; }
        public string Correo_electronico { get; set; }
    }
}