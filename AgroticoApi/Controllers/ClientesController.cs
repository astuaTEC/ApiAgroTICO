using DBManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgroticoApi.Controllers
{
    public class ClientesController : ApiController
    {

        DBMS dbms = new DBMS();

        /// <summary>
        /// Permite consultar info de un usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            var listado = dbms.SELECT(DBMS.RUTA_CLIENTES, 987654321);
            if (listado == "")
            {
                return NotFound();
            }

            return Ok(JObject.Parse(listado));

        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var listado = dbms.SELECT(DBMS.RUTA_CLIENTES, id);
            if (listado == "")
            {
                return NotFound();
            }

            return Ok(JObject.Parse(listado));

        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] JObject nuevoCliente)
        {
           dbms.INSERT(DBMS.RUTA_CLIENTES, JsonConvert.SerializeObject(nuevoCliente));
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var res = dbms.DELETE(DBMS.RUTA_CLIENTES, id);
            if (res == true)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] JObject o)
        {
            var atributoLlave = o["atributoLlave"];
            var atributoModificar = o["atributoModificar"];
            var nuevoValorTexto = o["nuevoValorTexto"];
            var nuevoValorNumerico = o["nuevoValorNumerico"];
            bool res = dbms.UPDATE(DBMS.RUTA_CLIENTES, (int)atributoLlave, 
                (string)atributoModificar, (string)nuevoValorTexto, (int)nuevoValorNumerico);

            if (res == true)
            {
                return Ok();
            }
            return NotFound();
        }


    }
}
