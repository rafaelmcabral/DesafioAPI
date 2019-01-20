using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Model;

namespace DesafioAPI.Repository
{
    public class TaxaRepository : ITaxaRepository
    {
        public TaxaModel Get(AdquirenteModel adquirente, string bandeira)
        {
            return adquirente.Taxas.Where((x => x.Bandeira.ToLower() == bandeira.ToLower())).SingleOrDefault();
        }
    }
}
