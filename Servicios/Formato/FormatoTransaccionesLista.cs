using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuelingFrechilla.Models;

namespace VuelingFrechilla.Servicios.Formato
{
    public class FormatoTransaccionesLista
    {
        public FormatoTransaccionesLista() { }
        public List<Transacion> ConvertirLista(string str)
        {
            List<Transacion> Transacciones = new List<Transacion>();
            var lista = JsonConvert.DeserializeObject<List<Transacion>>(str);

          
            string entorno = Properties.Resources.entorno.ToUpper();
            foreach (var linea in lista)
            {
                Transacion _Transaccion = new Transacion();
                if (entorno == "PRODUCCION") {
                    // con DTO de datos
                    Transacciones.Add(TransaccionSimpleFactory.CrearTransaccion(linea.Sku, linea.Amount, linea.Currency));
                } else
                { 
                    _Transaccion.Sku = linea.Sku;
                    _Transaccion.Amount = linea.Amount;
                    _Transaccion.Currency = linea.Currency;
                    Transacciones.Add(_Transaccion);
                }

            }
            return Transacciones;
        }
    }
}