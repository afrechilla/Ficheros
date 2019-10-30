using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace VuelingFrechilla.Servicios.Persistencia
{
    public class LeerFichero
    {
        public string _directorio;
        public string _rutaNombreFichero = "";
        log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string LeerFicheroDeDisco(string nombreFichero)
        {
            Directorios directorio = new Directorios();
            _rutaNombreFichero = directorio.ObtenerRuta(nombreFichero);

            string _datos = "";
            if (_rutaNombreFichero != "")
            {
                // se ha comentado para no hacer pruebas con el de real
                if (Properties.Resources.entorno.ToUpper() == "PRODUCCION" )
                { 
                    LeerFicheroDeWeb leerFicheroWeb = new LeerFicheroDeWeb();
                    bool datos = leerFicheroWeb.Bajar(_rutaNombreFichero);
                }
                // log.Info("Fichero descargado: " + _rutaNombreFichero);
                try
                {
                    using (StreamReader sr = new StreamReader(_rutaNombreFichero))
                    {
                        // Read the stream to a string, and write the string to the console.
                        _datos = sr.ReadToEnd();
                        sr.Close();
                    }
                }
                catch (Exception exc)
                {
                    string tipoExcepcion = exc.InnerException.GetType().ToString();
                    log.Error("No se ha podido leer el archivo " + _rutaNombreFichero + "  " + exc.Message);
                }   
              
            }//if (ObtenerCarpeta(nombreFichero))
            return _datos;
        }// public string LeerFichero(string nombreFichero)
    }
}