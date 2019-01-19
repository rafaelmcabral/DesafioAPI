using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Model;

namespace DesafioAPI.Repository
{
    public class AdquirenteRepository : IAdquirenteRepository
    {
        private List<AdquirenteModel> listaAdquirente = new List<AdquirenteModel>();

        public AdquirenteRepository()
        {
            listaAdquirente.Add(new AdquirenteModel()
            {
                Codigo = "A",
                Adquirente = "Adquirente A",
                Taxas = new TaxaModel[]
                {
                    new TaxaModel()
                    {
                        Bandeira = "Visa",
                        Credito = 2.25,
                        Debito = 2.00
                    },
                    new TaxaModel()
                    {
                        Bandeira = "Master",
                        Credito = 2.35,
                        Debito = 1.98
                    }
                }
            });

            listaAdquirente.Add(new AdquirenteModel()
            {
                Codigo = "B",
                Adquirente = "Adquirente B",
                Taxas = new TaxaModel[]
                {
                    new TaxaModel()
                    {
                        Bandeira = "Visa",
                        Credito = 2.50,
                        Debito = 2.08
                    },
                    new TaxaModel()
                    {
                        Bandeira = "Master",
                        Credito = 2.65,
                        Debito = 1.75
                    }
                }
            });

            listaAdquirente.Add(new AdquirenteModel()
            {
                Codigo = "C",
                Adquirente = "Adquirente C",
                Taxas = new TaxaModel[]
                {
                    new TaxaModel()
                    {
                        Bandeira = "Visa",
                        Credito = 2.75,
                        Debito = 2.16
                    },
                    new TaxaModel()
                    {
                        Bandeira = "Master",
                        Credito = 3.10,
                        Debito = 1.58
                    }
                }
            });
        }

        public AdquirenteModel Get(string codigo)
        {
            return listaAdquirente.Where((x => x.Codigo == codigo)).SingleOrDefault();
        }

        public IEnumerable<AdquirenteModel> GetAll()
        {
            return listaAdquirente;
        }
    }
}
