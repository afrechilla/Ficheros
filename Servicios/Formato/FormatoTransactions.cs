using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuelingFrechilla.Models;

namespace VuelingFrechilla.Servicios.Formato
{
    public class FormatoTransactions
    {

        public FormatoTransactions() { }
        //public List<Transacion> Convertir(string str)
        public string Convertir(string str)
        {
            //List<Transacion> Transacciones = new List<Transacion>();

            //var lista = JsonConvert.DeserializeObject<List<Transacion>>(str);
            //foreach (var linea in lista)
            //{
            //    Transacciones.Add(TransaccionSimpleFactory.CrearTransaccion(linea.Sku, linea.Amount, linea.Currency));
            //}
            FormatoTransaccionesLista listaTransacciones = new FormatoTransaccionesLista();
            var Transacciones = listaTransacciones.ConvertirLista(str);

            //return lista;
            var json = JsonConvert.SerializeObject(Transacciones);
            return json;
        }
       
    }//   public class FormatoTransactions
}//namespace VuelingFrechilla.Servicios.Formato