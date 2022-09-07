using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TPFinal_Turró_Ej1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime fecha = DateTime.Now;
            string strDate = fecha.ToString("MM-dd-yyyy-h-mm-ss");  //La fecha actual se pasa a un string con formato que despues va a agregarse al nombre de un  archivo
            string archivo = "archivo.txt";
            string archivo2 = "notas." + strDate + ".bak";
            Console.WriteLine("Ingrese el texto que va a agregar al final del archivo");
            string Neos = Console.ReadLine(); //ingreso y leida de datos
            primero(Neos, archivo);
            backup(archivo2, aarray(archivo));
            Console.ReadLine();
        }
        public static void primero(string Neos, string archivo) //escribe lo que el usuario ingresa en un archivo
        {
            FileStream fs = new FileStream(archivo, FileMode.Append, FileAccess.Write);
            using (StreamWriter escritor = new StreamWriter(fs))
            {
                escritor.WriteLine(Neos);
            }
            fs.Close();
        }
        public static string[] aarray(string archivo) //crea un array que va a tener todos los contenidos de un archivo para poder copiarlos mas facil
        {
            string[] array = new string[1];
            FileStream fs = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader lector = new StreamReader(fs))
            {
                string linea = lector.ReadLine();
                int i = 0;
                while(linea != null)
                {
                    array[i] = linea;
                    linea = lector.ReadLine();
                    if (linea != null)
                    {
                        Array.Resize(ref array, array.Length + 1);
                    }
                    i++;
                }
                fs.Close();
            }
            return array;
        }
        public static void backup(string archivo, Array array) //crea un nuevo archivo con todos los contenidos del array (que a su vez tiene todos los contenidos del archivo 1)
        {
            FileStream fs = new FileStream(archivo, FileMode.Append, FileAccess.Write);
            using (StreamWriter escritor = new StreamWriter(fs))
            {
                foreach (string item in array)
                {
                    escritor.WriteLine(item);
                }
            }
            fs.Close();
        }
    }
}
