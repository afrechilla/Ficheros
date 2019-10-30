using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingFrechilla.Servicios.Persistencia
{
    public interface IGuardarFichero
    {
         string GuardarFicheroEnDisco(string nombreFichero, string datos);
    }
}
