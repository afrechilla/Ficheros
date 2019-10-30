using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuelingFrechilla.Models;

namespace VuelingFrechilla.Servicios.Formato
{
    public class ConvertirListaAJson
    {
        public ConvertirListaAJson() { }
        public string   Convertir(List<Transacion> Transacciones)
        {
            var strJson = JsonConvert.SerializeObject(Transacciones); 
            return strJson;
        }
    }
}