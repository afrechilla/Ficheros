using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuelingFrechilla.Models;
using VuelingFrechilla.Servicios.Formato;
using VuelingFrechilla.Servicios.Persistencia;

namespace VuelingFrechilla.Servicios.Procesamiento
{/// <summary>
/// Recibe un SKU, 
/// Lee todas las transacciones y filtra las que son de ese sku
/// Devueleve un string con las transacciones
/// </summary>
    public class ListarTransaccionesSku : IListarTransaccionesSku<string>
    {
        public string ListaTransaccionesSku(string codigo)
        {
            //string trans = "ListaTransaccionesSku";
            // Leer todo el fichero de transacciones
            
            IServicioPersistencia serv = new ServicioPersistencia();
            string contenidoFichero = serv.LeerFicheroDeDisco("transactions" + ".json");
           


            // Meterlo en una lista
            FormatoTransaccionesLista listaTransacciones = new FormatoTransaccionesLista();
            var Transacciones = listaTransacciones.ConvertirLista(contenidoFichero);

            // Filtrar (mediante JQuery) los del codigo pasado
            PasarAEuros clasePasarAEuros = new PasarAEuros();

            decimal suma = 0;

            List<Transacion> listaTransSku = new List<Transacion>();
            foreach (Transacion tr in Transacciones)
            {
                if (tr.Sku == codigo) {
                    Transacion nueva = new Transacion();
                    // Calcular valor en euros de una transaccion+
                    decimal cambio = clasePasarAEuros.calcularCambio(tr.Currency);
                    //tr.Amount = tr.Amount * cambio;
                    nueva.Sku = tr.Sku;
                    nueva.Currency = "EUR";
                    nueva.Amount = cambio * tr.Amount;
                    suma += nueva.Amount;
                    listaTransSku.Add(nueva);
                }
            }

            ConvertirListaAJson convertir = new ConvertirListaAJson();
            string strListaTransSku = convertir.Convertir(listaTransSku);
            strListaTransSku += "\n Total sku:" + codigo + " = " + suma;
            return strListaTransSku;
        }
    }
}