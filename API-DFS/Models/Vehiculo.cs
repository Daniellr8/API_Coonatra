using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DFS.Models
{
    public class Vehiculo
    {
        public string Cod_Ruta { get; set; }
        public string Id_vehiculo { get; set; }
        public string Cod_vehiculo { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string HORA_INICIO { get; set; }
        public string HORA_FINAL { get; set; }
        public string Minutos { get; set; }
        public string Pasajeros { get; set; }
        public string Marcas_descontadas { get; set; }
        public string Kilometros { get; set; }
        public string Vueltas_manuales { get; set; }



    }
}