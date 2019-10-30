using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuelingFrechilla.Models;
using VuelingFrechilla.Servicios.Procesamiento;

namespace VuelingFrechilla.Servicios.Formato
{
    public class RateeARatesMarca
    {
        public RateeARatesMarca() { }

        public List<RatesMarca> Convertir(List<Ratee> listaRatee)
        {
            List<RatesMarca> liMarca = new List<RatesMarca>();
           
            foreach (Ratee ele in listaRatee)
            {
                RatesMarca eleM = new RatesMarca();
                eleM.From = ele.From;
                eleM.To = ele.To;
                eleM.Rate = ele.Rate;
                eleM.Marcado ="N";
                liMarca.Add(eleM);
            }
            return liMarca;

        }
    }
}