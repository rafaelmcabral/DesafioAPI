using DesafioAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAPI.Repository
{
    interface ITaxaRepository
    {
        TaxaModel Get(AdquirenteModel adquirente, string bandeira);
    }
}
