using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingFrechilla.Models;

namespace VuelingFrechilla.Servicios.Procesamiento
{
    interface IListarTransaccionesSku<T>
    {
        string ListaTransaccionesSku(string T);
    }
}
