using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuelingFrechilla.Models;
using VuelingFrechilla.Servicios.Formato;
using VuelingFrechilla.Servicios.Persistencia;

namespace VuelingFrechilla.Servicios.Procesamiento
{
    public class ListaRatesMarca
    {

        public ListaRatesMarca() { }

        public List<RatesMarca> Lista()
        {
            List<RatesMarca> li = new List<RatesMarca>();
            //if (Properties.Resources.entorno.ToUpper() == "PRODUCCION")
            string entorno = Properties.Resources.entorno.ToUpper();
            entorno = "PRODUCCION";
            if (entorno == "PRODUCCION")
            {
                LeerFichero claseLeerFichero = new LeerFichero();
                string json = claseLeerFichero.LeerFicheroDeDisco("rates.json");
                FormatoRatesLista clsFormatoRatesLista = new FormatoRatesLista();
                List<Ratee> liRates = clsFormatoRatesLista.Convertir(json);
                RateeARatesMarca clsRateeARatesMarca = new RateeARatesMarca();
                li = clsRateeARatesMarca.Convertir(liRates);

            } else

            if (entorno == "PRUEBAS")
            {
                li.Add(new RatesMarca { From = "EUR", To = "USD", Rate = 1.25m, Marcado = "N" });
                li.Add(new RatesMarca { From = "USD", To = "EUR", Rate = 0.8m, Marcado = "N" });
                li.Add(new RatesMarca { From = "EUR", To = "CAD", Rate = 0.5m, Marcado = "N" });
                li.Add(new RatesMarca { From = "CAD", To = "EUR", Rate = 2.0m, Marcado = "N" });
                li.Add(new RatesMarca { From = "USD", To = "AUD", Rate = 1.44m, Marcado = "N" });
                li.Add(new RatesMarca { From = "AUD", To = "USD", Rate = 0.69m, Marcado = "N" });
            }
            
           


                return li;
        }
    }
}