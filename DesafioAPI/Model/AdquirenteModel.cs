using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAPI.Model
{
    public class AdquirenteModel
    {
        [JsonIgnore]
        public string Codigo { get; set; }
        [JsonProperty("Adquirente")]
        public string Adquirente { get; set; }
        [JsonProperty("Taxas")]
        public TaxaModel[] Taxas { get; set; }

        public TaxaModel GetTaxa(string bandeira)
        {
            TaxaModel taxa = this.Taxas.Where((x => x.Bandeira.ToLower() == bandeira.ToLower())).SingleOrDefault();
            if (taxa != null)
            {
                return taxa;
            } else
            {
                throw new Exception("Bandeira não localizada");
            }
        }
    }
}
