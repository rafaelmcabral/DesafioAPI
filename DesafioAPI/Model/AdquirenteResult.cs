using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAPI.Model
{
    public class AdquirenteResult
    {
        [JsonProperty("ValorLiquido")]
        public double ValorLiquido { get; set; }
    }
}
