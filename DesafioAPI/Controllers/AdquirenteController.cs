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
        private readonly static IAdquirenteRepository AdquirenteRepository = new AdquirenteRepository();
        private readonly static ITaxaRepository TaxaRepository = new TaxaRepository();

        [Route("/mdr")]
        [HttpGet]
        public ActionResult <IEnumerable<AdquirenteModel>> Get()
        {
            return new ActionResult<IEnumerable<AdquirenteModel>>(AdquirenteRepository.GetAll());
        }

        [Route("/transaction")]
        [HttpPost]
        public ActionResult <object> Post([FromBody] AdquirenteRequest request)
        {
            List<string> listaCriticas = request.ValidarEntrada();

            if (listaCriticas.Count == 0)
            {
                AdquirenteModel adquirente = AdquirenteRepository.Get(request.Adquirente);
                if (adquirente != null)
                {
                    TaxaModel taxa = TaxaRepository.Get(adquirente, request.Bandeira);
                    if (taxa != null)
                    {
                        try
                        {
                            AdquirenteResult result = new AdquirenteResult();
                            result.ValorLiquido = taxa.CalcularValorTotal(request.Valor.Value, request.Tipo);
                            return new ActionResult<object>(result);
                        }
                        catch (Exception ex)
                        {
                            return new ActionResult<object>(new
                            {
                                error = "400",
                                message = "Não foi possível realizar a operação: " + ex.Message
                            });
                        }
                    } else
                    {
                        return new ActionResult<object>(new
                        {
                            error = "400",
                            message = "Bandeira não encontrada"
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