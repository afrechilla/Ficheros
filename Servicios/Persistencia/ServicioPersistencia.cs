using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VuelingFrechilla.Servicios.Persistencia
{
    public class ServicioPersistencia  : IServicioPersistencia
    {
      // private  IsolatedStorageFile area = IsolatedStorageFile.GetUserStoreForApplication();
        public string _directorio;
        public string _rutaNombreFichero = "";
      
     
        public string GuardarFicheroEnDisco(string nombreFichero, string datos)
        {
            GuardarFichero claseGuardarFichero = new GuardarFichero();
            string rdo = claseGuardarFichero.GuardarFicheroEnDisco(nombreFichero, datos);
            return rdo;
        }



        public string LeerFicheroDeDisco(string nombreFichero)
        {
            LeerFichero claseLeerFichero = new LeerFichero();
            string datos = claseLeerFichero.LeerFicheroDeDisco(nombreFichero);
            return datos;
        }


        //public ServicioPersistencia()
        //{
        //    _directorio  = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        //}


        //public string LeerFichero(string nombreFichero)
        //{
        //    Directorios directorio = new Directorios();
        //    _rutaNombreFichero =  directorio.ObtenerRuta(nombreFichero);

        //    string _datos = "";
        //    if (_rutaNombreFichero!= "")
        //    {
        //        LeerFicheroDeWeb leerFicheroWeb = new LeerFicheroDeWeb();
        //        if (leerFicheroWeb.Bajar(_rutaNombreFichero))
        //        {
        //            log.Info("Fichero descargado: " + _rutaNombreFichero);
        //        }
        //        try
        //        {
        //            using (StreamReader sr = new StreamReader(_rutaNombreFichero))
        //            {

        //                // Read the stream to a string, and write the string to the console.
        //                _datos = sr.ReadToEnd();

        //            }
        //        }
        //       catch ( Exception exc)
        //        {
        //            string tipoExcepcion = exc.InnerException.GetType().ToString();
        //            log.Error("No se ha podido leer el archivo " + _rutaNombreFichero + "  " + exc.Message);
        //        }

        //    }//if (ObtenerCarpeta(nombreFichero))
        //    return _datos;
        //}// public string LeerFichero(string nombreFichero)







        //public bool   GuardaFichero(string nombreFichero,string datos)
        //{
        //    string directorio = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        //    bool exito = true;

        //    try
        //    {
        //        if (!area.DirectoryExists(directorio))
        //        {
        //            area.CreateDirectory(nombreFichero);
        //        }
        //        var isoFileStream = new System.IO.IsolatedStorage.IsolatedStorageFileStream(
        //                    RutaNombreFichero(directorio, nombreFichero), System.IO.FileMode.Create, System.IO.FileAccess.Write,
        //                    System.IO.FileShare.None, area);

        //        using (var isoFileWriter = new System.IO.StreamWriter(isoFileStream))

        //        {
        //             isoFileWriter.Write(datos);
        //        }
        //    }

        //    catch (Exception ex)

        //    {
        //        //log.GrabaLog($"se ha lanzado una excepción del tipo Application Exception en el nombre de fichero {nombreFichero} ");
        //        // throw new ServiceExceptionPersistenceException($"Error en la grabación del fichero: {nombreFichero}", ex);
        //        throw new Exception(ex.Message);
        //    }
        //    return exito;

        //}


        ////public async Task<string> LeeFichero(string directorio, string nombreFichero)
        //public string LeeFichero(string directorio, string nombreFichero)
        //{
        //    var isoFileStream = new System.IO.IsolatedStorage.IsolatedStorageFileStream
        //                (RutaNombreFichero(directorio, nombreFichero),
        //                System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None, area);

        //    using (var isoFileReader = new System.IO.StreamReader(isoFileStream))
        //    {
        //        return isoFileReader.ToString();
        //    }
        //}
    }
}