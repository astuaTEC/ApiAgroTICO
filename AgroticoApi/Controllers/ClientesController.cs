using DBManager;
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

        /*[HttpPost]
        public IHttpActionResult Post([FromBody] JObject o)
        {

        }*/

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


    }
}
