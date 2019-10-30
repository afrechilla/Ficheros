using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace VuelingFrechilla.Servicios.Persistencia
{
    public class LeerFicheroDeWeb
    {
        log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LeerFicheroDeWeb() { }
        /// <summary>
        /// Baja un fichero de la red y lo guarda en
        /// </summary>
        /// <param name="rutaNombreFichero"></param>
        /// <returns></returns>
        public bool Bajar(string rutaNombreFichero)
        {    
             WebClient web = new WebClient();
            
           // string directorio = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // string nombreFichero = "rates.json";

            string nombreFichero = Path.GetFileName(rutaNombreFichero) ;
           
            //string rutaNombreFichero = string.Format("{0}\\{1}", directorio, nombreFichero);
            //string direccionWeb = "http://quiet-stone-2094.herokuapp.com/rates.json";
            string rutaWeb = Properties.Resources.rutaWeb;
          
            string direccionWeb = rutaWeb + "/" + nombreFichero;
            //web.DownloadFile("http://quiet-stone-2094.herokuapp.com/rates.json", fileName);
            try
            {
                 web.DownloadFile(direccionWeb, rutaNombreFichero);
                //var strJson = JsonConvert.SerializeObject(contenidoFichero);
                log.Info("Fichero descargado: " + rutaNombreFichero);
                return true;
            }
            catch (Exception exc)
            {
                File.Delete(rutaNombreFichero);
                File.Copy(rutaNombreFichero + ".bak", rutaNombreFichero);
                log.Info("No se ha podido leer el fichero de la red " + exc.Message);
                return false;
            }
     
        } //public bool Bajar()
    }// public class LeerFicheroDeWeb
} //namespace VuelingFrechilla.Servicios.Persistencia

