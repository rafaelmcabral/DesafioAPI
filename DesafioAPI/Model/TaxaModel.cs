using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAPI.Model
{
    public class TaxaModel
    {
        [JsonProperty("Bandeira")]
        public string Bandeira { get; set; }
        [JsonProperty("Credito")]
        public double Credito { get; set; }
        [JsonProperty("Debito")]
        public double Debito { get; set; }

        public double CalcularValorTotal(double valor, string tipo)
        {
            if (valor != 0)
            {
                switch (tipo)
                {
                    case "Credito":
                        return valor - (valor * this.Credito / 100);
                    case "Debito":
                        return valor - (valor * this.Debito / 100);
                    default:
                        throw new Exception("Tipo não suportado");
                }
            } else
            {
                throw new Exception("Valor não pode ser zero");
            }
        }
    }
}
