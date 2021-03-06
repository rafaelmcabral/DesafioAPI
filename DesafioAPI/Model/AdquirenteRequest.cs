﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAPI.Model
{
    public class AdquirenteRequest
    {
        [JsonProperty("Valor")]
        public double? Valor { get; set; }
        [JsonProperty("Adquirente")]
        public string Adquirente { get; set; }
        [JsonProperty("Bandeira")]
        public string Bandeira { get; set; }
        [JsonProperty("Tipo")]
        public string Tipo { get; set; }

        public List<string> ValidarEntrada()
        {
            List<string> listaCriticas = new List<string>();
            if (!Valor.HasValue)
            {
                listaCriticas.Add("Valor não informado");
            } else if (Valor.Value == 0)
            {
                listaCriticas.Add("Valor não pode ser zero");
            }

            if (string.IsNullOrEmpty(Adquirente))
            {
                listaCriticas.Add("Adquirente não informado");
            }

            if (string.IsNullOrEmpty(Bandeira))
            {
                listaCriticas.Add("Bandeira não informada");
            }

            if (string.IsNullOrEmpty(Tipo))
            {
                listaCriticas.Add("Tipo não informado");
            }

            return listaCriticas;
        }
    }
}
