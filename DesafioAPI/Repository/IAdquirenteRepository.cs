using DesafioAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAPI.Repository
{
    public interface IAdquirenteRepository
    {
        IEnumerable<AdquirenteModel> GetAll();
        AdquirenteModel Get(string codigo);
    }
}
