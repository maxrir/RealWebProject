using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Mvc;

namespace RealWeb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{vTotal}/{vPago}")]
        public ActionResult<string> Get([FromServices]IApp application, string vTotal, string vPago)
        {
            try
            {
                double _total = 0;
                double _pago = 0;

                var isTotalValido = double.TryParse(vTotal.Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out _total);
                var isValorPagoValido = double.TryParse(vPago.Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out _pago);

                if(!isTotalValido || !isValorPagoValido)
                    return "Formato Inválido";

                var ret = application.getTroco(_total, _pago);
                return ret;
            }
            catch (Exception ex)
            {
                return "Formato Inválido";
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
