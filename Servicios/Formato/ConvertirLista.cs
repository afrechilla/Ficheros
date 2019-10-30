using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuelingFrechilla.Models;
using VuelingFrechilla.Servicios.Procesamiento;

namespace VuelingFrechilla.Servicios.Formato
{
    public class ConvertirLista
    {
        public List<RatesMarca> convertir(List<Ratee> ListaRates)
        {
            List<RatesMarca> ListaRM = new List<RatesMarca>();
            RatesMarca elementoNuevo = new RatesMarca();

            foreach (var eleListaRM in ListaRates)
            {
                elementoNuevo.From = eleListaRM.From;
                elementoNuevo.To = eleListaRM.To;
                elementoNuevo.Rate = eleListaRM.Rate;
                elementoNuevo.Marcado = "N";
            }
            return ListaRM;
        }
    }
}