using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuelingFrechilla.Models;

namespace VuelingFrechilla.Servicios.Formato
{
    public class FormatoRatesLista
    {
        public  FormatoRatesLista() { }
      
        public List<Ratee> Convertir(string str)
        {
            List<Ratee> Rates = new List<Ratee>();

            var lista = JsonConvert.DeserializeObject<List<Ratee>>(str);
            foreach (var linea in lista)
            {
                Rates.Add(RateSimpleFactory.CrearTransaccion(linea.From, linea.To, linea.Rate));
            }

        return Rates;

        }
    }//public class FormatoRatesLista
}//namespace VuelingFrechilla.Servicios.Formato