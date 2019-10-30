using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VuelingFrechilla.Models;
using VuelingFrechilla.Servicios.Formato;
using VuelingFrechilla.Servicios.Persistencia;

namespace VuelingFrechilla.Servicios.Procesamiento
{
    public class PasarAEuros
    {
        public  decimal valor = 1;
        public  string from = "";
        public  bool encontrado = false;
        public  RatesMarca devolver;

        public  decimal  calcularCambio(string  moneda)
        {
            // leemos los rates en una cadena
            //LeerFichero clsLeerFicheroDeDisco = new LeerFichero();
            //string datos = clsLeerFicheroDeDisco.LeerFicheroDeDisco("rates.json");

            // los metemos en Lista de ratees
            // FormatoRatesLista clsFormatoRates = new FormatoRatesLista();
            //List<Ratee> ListaRates =  clsFormatoRates.Convertir(datos);
           
            //FormatoRatesLista clsFormatoRatesLista = new FormatoRatesLista();
            //List<Ratee> ratios = clsFormatoRatesLista.Convertir(datos);

            // Los convertimos en  ListaRatesMarca
            ListaRatesMarca claseListaRatesMarca = new ListaRatesMarca();
            List<RatesMarca> RatesMarca = claseListaRatesMarca.Lista();
            valor = 1;
            decimal cambio  = buscarCambio(RatesMarca, moneda);
            return cambio;

        }

        public  decimal buscarCambio(List<RatesMarca> lista, string from)
        {

            // Buscamos en la lista si está el elemento con una conversion directa To="E"
            RatesMarca buscar = buscarEUR(lista, from);
            if (from == "EUR")
            {
                Console.WriteLine("Valor buscado no puede ser E");
                return valor;
            }
            if (encontrado)
            {
                // valor = valor * buscar.Rate;
                //Console.WriteLine("Hay busqueda directa");
                //Console.WriteLine(string.Format("{0} {1} {2} {3}", buscar.From, buscar.To, buscar.Rate, valor));
                //Console.ReadLine();
            }
            else
            {
                Console.WriteLine("NO hay busqueda directa de: " + from);
                buscarNoEUR(lista, from);
                if (encontrado) { return valor; }
                else { buscarCambio(lista, devolver.To); }
                //Console.ReadLine();
            }
            return valor;
        }

        public  RatesMarca buscarNoEUR(List<RatesMarca> lista, string from)
        {
            devolver = new RatesMarca { From = from, To = "EUR", Rate = -1, Marcado = "N" };
            //bool Encontrado = false;
            foreach (RatesMarca ratio in lista)
            {
                if (ratio.From == from && ratio.Marcado != "S")
                {
                    lista = marcar(lista, ratio.From, ratio.To); // marcar el mismo para no volver a pasar
                    lista = marcar(lista, ratio.To, ratio.From); // marcar contrario para la vez siguiente
                    valor = valor * ratio.Rate;
                    devolver = ratio;
                    return ratio;
                }
            }
            return devolver;
        }

        public  List<RatesMarca> marcar(List<RatesMarca> lista, string from, string to)
        {

            foreach (RatesMarca ratio in lista)
            {   // si coincide que es el contrario lo marcamos
                if (ratio.From == to && ratio.To == from)
                { ratio.Marcado = "S"; }
            }
            return lista;
        }

        public  RatesMarca buscarEUR(List<RatesMarca> lista, string from)
        {
            RatesMarca devolver = new RatesMarca { From = "EUR", To = "EUR", Rate = -1, Marcado = "N" };
            //bool Encontrado = false;
            foreach (RatesMarca ratio in lista)
            {
                if (ratio.From == from && ratio.To.ToUpper() == "EUR")
                {
                    valor = valor * ratio.Rate;
                    encontrado = true;
                    devolver = ratio;
                    return ratio;
                }
            }
            return devolver;
        }
    }
}