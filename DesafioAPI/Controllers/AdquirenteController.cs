using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Model;
using DesafioAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DesafioAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AdquirenteController : ControllerBase
    {
        private readonly IAdquirenteRepository repository = new AdquirenteRepository();

        [Route("/mdr")]
        [HttpGet]
        public ActionResult <IEnumerable<AdquirenteModel>> Get()
        {
            return new ActionResult<IEnumerable<AdquirenteModel>>(repository.GetAll());
        }

        [Route("/transaction")]
        [HttpPost]
        public ActionResult <object> Post([FromBody] AdquirenteRequest request)
        {
            List<string> listaCriticas = request.ValidarEntrada();

            if (listaCriticas.Count == 0)
            {
                AdquirenteModel adquirente = repository.Get(request.Adquirente);
                if (adquirente != null)
                {
                    AdquirenteResult result = new AdquirenteResult();
                    try
                    {
                        TaxaModel taxa = adquirente.GetTaxa(request.Bandeira);
                        result.ValorLiquido = taxa.CalcularValorTotal(request.Valor.Value, request.Tipo);
                        return new ActionResult<object>(result);
                    }
                    catch (Exception ex)
                    {
                        return new ActionResult<object>(new
                        {
                            error = "400",
                            message = "Não foi possível retornar o valor total da operação: " + ex.Message
                        });
                    }
                }
                else
                {
                    return new ActionResult<object>(new
                    {
                        error = "400",
                        message = "Adquirente não encontrado"
                    });
                }
            } else
            {
                return new ActionResult<object>(new
                {
                    error = "400",
                    message = listaCriticas
                });
            }
        }
    }
}