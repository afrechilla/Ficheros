using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace VuelingFrechilla.Servicios.Persistencia
{
    public class GuardarFichero
    {
        log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string GuardarFicheroEnDisco(string nombreFichero, string datos)
        {
            
            Directorios directorio = new Directorios();
            string _rutaNombreFichero = directorio.ObtenerRuta(nombreFichero);
            try
            {

                if (directorio.ObtenerRuta(nombreFichero) !="")
                {
                    //_rutaNombreFichero = string.Format("{0}\\{1}", _directorio, nombreFichero);
                    try
                    {                     // Delete the file if it exists.
                        if (File.Exists(_rutaNombreFichero))
                        {
                            File.Copy(_rutaNombreFichero, _rutaNombreFichero + ".bak");
                            File.Delete(_rutaNombreFichero);
                        }
                        using (FileStream fs = File.Create(_rutaNombreFichero))
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes(datos);
                            fs.Write(info, 0, info.Length);
                            fs.Close();
                            log.Info("Fichero guardado en disco: " + _rutaNombreFichero);

                        }
                    }
                    catch (Exception exc)
                    {
                        File.Delete(_rutaNombreFichero);
                        File.Copy(_rutaNombreFichero+".bak", _rutaNombreFichero);
                        log.Info("Fichero recuperado de version anterior. "+ exc.Message);
                    }
                }
            }
            catch (Exception exc ) { 
                log.Error("Excepcion al guardar fichero en disco: " + _rutaNombreFichero+ ". " + exc.Message);
            }
            return "OK";
        }
    }
}