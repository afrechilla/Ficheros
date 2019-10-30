using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingFrechilla.Servicios.Persistencia
{
    public interface IServicioPersistencia   
    { 
        //Task<string> LeeFichero(string directorio, string nombreFichero);
        string LeerFicheroDeDisco(string nombreFichero);
        //Task<bool> GuardaFichero(string nombreFichero, string datos);
        string GuardarFicheroEnDisco(string nombreFichero, string datos);
    }
}
