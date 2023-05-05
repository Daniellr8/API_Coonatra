using API_DFS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API_DFS.Controllers
{
    public class VehiculosController : ApiController
    {
        static Dictionary<int, Vehiculo> Vehiculos = new Dictionary<int, Vehiculo>();
        ConsultaDFS.ConsultaDFS oConsulta = new ConsultaDFS.ConsultaDFS();
        string respuesta = "";
        string JSON;   
        
        
           
        //GET
        public IEnumerable<Vehiculo> Get()
        {
            //oConsulta.Consultar("select v.cod_vehiculo, CONVERT(VARCHAR(MAX), DECRYPTBYKEY(LATITUD)) as latitud, " +
            //     "CONVERT(VARCHAR(MAX), DECRYPTBYKEY(LONGITUD)) as longitud from registro_tiempo_real rtr, vehiculo v where " +
            //     "(rtr.ID_VEHICULO = v.ID_VEHICULO)", ref JSON, "192.168.2.51\\optocontrol");

            //oConsulta.Consultar("SELECT TOP 10 ID_VEHICULO, FECHA_HORA_INICIO FROM HISTORICO_RECAUDACION", ref JSON, "192.168.2.51\\optocontrol");

            oConsulta.Consultar("SELECT [R].COD_RUTA, [V].COD_VEHICULO, [V].ID_VEHICULO, CONVERT(date, FECHA) AS FECHA, CONVERT(VARCHAR, FECHA_HORA_INICIO, 108) AS HORA_INICIO , CONVERT(VARCHAR, FECHA_HORA_FIN, 108) AS HORA_FINAL, [MINUTOS], [PASAJEROS], [MARCAS_DESCONTADAS], [H].[KILOMETROS], [VUELTAS_MANUALES] FROM [HISTORICO_RECAUDACION] H JOIN VEHICULO V ON V.ID_VEHICULO = CONVERT(VARCHAR(MAX), DECRYPTBYKEY(H.ID_VEHICULO)) JOIN RUTA R ON R.ID_RUTA = H.ID_RUTA JOIN SECTOR S ON S.ID_SECTOR = H.ID_SECTOR WHERE CONVERT(VARCHAR, FECHA, 103) = '15/04/2023' AND S.COD_SECTOR = 'CIRCULAR COONATRA' ORDER BY [V].COD_VEHICULO, CONVERT(time, H.FECHA_HORA_INICIO) ASC", ref JSON, "192.168.2.51\\optocontrol");

            //oConsulta.Consultar(" SELECT* FROM VEHICULO", ref JSON, "192.168.2.51\\optocontrol");

            List<Vehiculo> vehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(JSON);
            return new List<Vehiculo>(vehiculos);
        }
    }
}
    