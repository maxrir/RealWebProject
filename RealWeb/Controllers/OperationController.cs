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
        // GET api/values/5
        [HttpGet("{valorPago}/{valorTotal}")]
        public ActionResult<string> Get([FromServices]IApp application, string valorPago, string valorTotal)
        {
            try
            {
                double _total = 0;
                double _pago = 0;

                var isTotalValido = double.TryParse(valorTotal.Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out _total);
                var isValorPagoValido = double.TryParse(valorPago.Trim().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out _pago);

                if(!isValorPagoValido)
                    return "Valor Pago Inválido";
                if (!isTotalValido)
                    return "Valor Total Inválido";

                var ret = application.getTroco(_total, _pago);
                return ret;
            }
            catch (Exception ex)
            {
                return "Erro ao Processar a Operação de troco!";
            }
        }
    }
}
