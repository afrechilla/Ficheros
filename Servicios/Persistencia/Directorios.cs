using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace VuelingFrechilla.Servicios.Persistencia
{
    public class Directorios
    {
        public Directorios() { }
        string _directorio  = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public string  ObtenerRuta(string nombreFichero)
        {
            string _rutaNombreFichero="";
            try
            {
                if (!Directory.Exists(_directorio))
                {
                    DirectoryInfo di = Directory.CreateDirectory(_directorio);
                }
                _rutaNombreFichero = string.Format("{0}\\{1}", _directorio, nombreFichero);
            }
            catch { }

            return _rutaNombreFichero;
        }
    }
}