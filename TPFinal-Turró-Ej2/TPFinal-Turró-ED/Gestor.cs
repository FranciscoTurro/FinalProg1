using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TPFinal_Turró_ED
{
    public class Gestor
    {
        string archivo = "pedidos.txt";
        string archivo2 = "stock_de_modelos.txt";
        string archivo3 = "stock_de_piezas.txt";
        string archivo4 = "composicion.txt";
        string archivotarea1 = "tarea1.txt";
        string archivotarea2 = "tarea2.txt";

        public void borrar1()   //simplemente borra el archivo, se repite lo mismo para cada uno de los archivos
        {
            File.Delete(archivo);   
        }
        public void borrar2()
        {
            File.Delete(archivo2);
        }
        public void borrar3()
        {
            File.Delete(archivo3);
        }
        public void borrar4()
        {
            File.Delete(archivo4);
        }
        public void borrar5()
        {
            File.Delete(archivotarea1);
        }
        public void borrar6()
        {
            File.Delete(archivotarea2);
        }
        public void guardar(Archivo1 Neos) //carga de datos en un array, repetido para cada archivo
        {
            FileStream fs = new FileStream(archivo, FileMode.Append, FileAccess.Write);
            using (StreamWriter escritor = new StreamWriter(fs))
            {
                escritor.WriteLine(Neos.Registro());
            }
            fs.Close();
        }
        public List<Archivo1> Lista() //se crea una lista con todos los datos de un archivo para poder mostrarlo en la form (este caso un datagridview). se repite para cada archivo
        {
            List<Archivo1> lista = new List<Archivo1>();
            FileStream fs = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader lector = new StreamReader(fs))
            {
                string linea = lector.ReadLine(); //Se lee una linea, los datos de la linea se separa mediante split (un metodo en la clase en cuestion, en este caso la clase archivo1)
                while (linea != null)
                {
                    Archivo1 Neos = new Archivo1(linea);
                    lista.Add(Neos);//Los datos se agregan a la lista, que es del mismo tipo por lo que quedan los datos guardados y separados
                    linea = lector.ReadLine();
                }
            }
            fs.Close();
            return lista;
        }
        public void guardar(Archivo2 Neos)
        {
            FileStream fs = new FileStream(archivo2, FileMode.Append, FileAccess.Write);
            using (StreamWriter escritor = new StreamWriter(fs))
            {
                escritor.WriteLine(Neos.Registro());
            }
            fs.Close();
        }
        public List<Archivo2> Lista2()
        {
            List<Archivo2> lista = new List<Archivo2>();
            FileStream fs = new FileStream(archivo2, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader lector = new StreamReader(fs))
            {
                string linea = lector.ReadLine();
                while (linea != null)
                {
                    Archivo2 Neos = new Archivo2(linea);
                    lista.Add(Neos);
                    linea = lector.ReadLine();
                }
            }
            fs.Close();
            return lista;
        }
        public void guardar(Archivo3 Neos)
        {
            FileStream fs = new FileStream(archivo3, FileMode.Append, FileAccess.Write);
            using (StreamWriter escritor = new StreamWriter(fs))
            {
                escritor.WriteLine(Neos.Registro());
            }
            fs.Close();
        }
        public List<Archivo3> Lista3()
        {
            List<Archivo3> lista = new List<Archivo3>();
            FileStream fs = new FileStream(archivo3, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader lector = new StreamReader(fs))
            {
                string linea = lector.ReadLine();
                while (linea != null)
                {
                    Archivo3 Neos = new Archivo3(linea);
                    lista.Add(Neos);
                    linea = lector.ReadLine();
                }
            }
            fs.Close();
            return lista;
        }
        public void guardar(Archivo4 Neos)
        {
            FileStream fs = new FileStream(archivo4, FileMode.Append, FileAccess.Write);
            using (StreamWriter escritor = new StreamWriter(fs))
            {
                escritor.WriteLine(Neos.Registro());
            }
            fs.Close();
        }
        public List<Archivo4> Lista4()
        {
            List<Archivo4> lista = new List<Archivo4>();
            FileStream fs = new FileStream(archivo4, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader lector = new StreamReader(fs))
            {
                string linea = lector.ReadLine();
                while (linea != null)
                {
                    Archivo4 Neos = new Archivo4(linea);
                    lista.Add(Neos);
                    linea = lector.ReadLine();
                }
            }
            fs.Close();
            return lista;
        }
        public void tarea1(int modelo, int cantidad)
        {
            int StockInicial = 0;
            int StockFinal = 0;
            int Fabricar = 0;
            int Adeudar = 0;
            int aux = 0;
            int i = 0;
            string[] listita = new string[1];
            FileStream fs = new FileStream(archivo2, FileMode.OpenOrCreate, FileAccess.Read);  //Le paso a la funcion el modelo que se quiere y la cantidad, sacados de las textboxes en la form. Con esto puedo buscar en el archivo 2 cual es el stock actual del modelo pedido.
            using (StreamReader lector = new StreamReader(fs))
             {
                string linea = lector.ReadLine();
                string[] data = linea.Split(',');
                aux = int.Parse(data[0]);
                StockInicial = int.Parse(data[2]);
                while (aux != modelo)
                {
                    linea = lector.ReadLine();
                    string[] data2 = linea.Split(',');
                    aux = int.Parse(data2[0]);
                    StockInicial = int.Parse(data2[2]);
                }
            }
            fs.Close();
            if (cantidad > StockInicial) //Con el stock y la cantidad pedida ya puedo hacer las primeras cuentas que se piden. Si la cantidad pedida es mayor al stock, el stock final es 0 (no puede ser negativo), y ese numero negativo se convierte en autos a fabricar
            {
                StockFinal = 0;
                int total = System.Math.Abs(cantidad - StockInicial);
                Fabricar = total;
                Adeudar = total;
                listita[i] = $"{modelo},{StockInicial},{cantidad},{StockFinal},{Fabricar},{Adeudar}"; //Le doy formato string a los datos pedidos y los paso a un array de strings para poder pasarlo a la lista mas abajo. Se repite en el otro caso del if
                Array.Resize(ref listita, listita.Length + 1);
            }
            else
            {
                StockFinal = StockInicial - cantidad; //En caso de que el stock sea mayor a la cantidad pedida, se muestra el restante.
                Fabricar = 0;
                Adeudar = 0;
                listita[i] = $"{modelo},{StockInicial},{cantidad},{StockFinal},{Fabricar},{Adeudar}";
                Array.Resize(ref listita, listita.Length + 1);
            }
            FileStream fs2 = new FileStream(archivotarea1, FileMode.Append, FileAccess.Write); //Se escriben en un archivo los contenidos del array con los datos pedidos
            using (StreamWriter escritor = new StreamWriter(fs2))
            {
                escritor.WriteLine(listita[i]);
            }
            fs2.Close();
            i++;   
        }
        public List<tarea1> Lista5() //Se repite lo mismo que en los casos anteriores, se crea una lista con los contenidos para poder mostrarlos
        {
            List<tarea1> lista = new List<tarea1>();
            FileStream fs = new FileStream(archivotarea1, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader lector = new StreamReader(fs))
            {
                string linea = lector.ReadLine();
                while (linea != null)
                {
                    tarea1 Neos = new tarea1(linea);
                    lista.Add(Neos);
                    linea = lector.ReadLine();
                }
            }
            fs.Close();
            return lista;
        }
        public void intento2(int modelo, int cantidad) //De nuevo se toma el numero de modelo y cantidad pedida de la textbox
        {
            int AFabricar = 0;
            int StockInicial = 0;
            int CantidadUsar = 0;
            int StockFinal = 0;
            int MinimaCantidad = 0;
            FileStream fs3 = new FileStream(archivotarea1, FileMode.OpenOrCreate, FileAccess.Read); //Empiezo tomando la cantidad a fabricar de la tarea 1 realizada, numero necesario para calcular la cantidad a fabricar de autos
            using (StreamReader lector = new StreamReader(fs3))
            {
                string linea = lector.ReadLine();
                while (linea != null)
                {
                    string[] data = linea.Split(',');
                    int aux = int.Parse(data[0]);
                    if (aux == modelo)
                    {
                        AFabricar = int.Parse(data[4]);
                    }
                    linea = lector.ReadLine();
                }
            }
            fs3.Close();
            Archivo4[] archivo4array = new Archivo4[1];
            FileStream fs = new FileStream(archivo4, FileMode.OpenOrCreate, FileAccess.Read); //Paso todos los contenidos del archivo a un array para poder realizar el apareo de archivos
            using (StreamReader lector = new StreamReader(fs))
            {
                string linea = lector.ReadLine();
                int i = 0;
                while (linea != null)
                {
                    archivo4array[i] = new Archivo4(linea);
                    linea = lector.ReadLine();
                    if (linea != null)
                    {
                        Array.Resize(ref archivo4array, archivo4array.Length + 1);
                    }
                    i++;
                }
                fs.Close();
            }
            Archivo3[] archivo3array = new Archivo3[1];
            FileStream fs2 = new FileStream(archivo3, FileMode.OpenOrCreate, FileAccess.Read); //Paso todos los contenidos del archivo a un array para poder realizar el apareo de archivos
            using (StreamReader lector = new StreamReader(fs2))
            {
                string linea = lector.ReadLine();
                int i = 0;
                while (linea != null)
                {
                    archivo3array[i] = new Archivo3(linea);
                    linea = lector.ReadLine();
                    if (linea != null)
                    {
                        Array.Resize(ref archivo3array, archivo3array.Length + 1);
                    }
                    i++;
                }
                fs2.Close();
            }
            for (int i=0;i<archivo4array.Length;i++)//Apareo de archivos
            {
                string quetermine = null;
                if (archivo4array[i].NumeroModelo == modelo) //Se busca el numero de modelo en el archivo 4
                {
                    for (int j = 0; j <archivo3array.Length;j++)
                    {
                        if (archivo3array[j].NumeroPieza == archivo4array[i].NumeroPieza) //Se busca la misma pieza para los 2 archivos
                        {
                            StockInicial = archivo3array[j].StockActual; //El stock inicial de la pieza en cuestion
                            CantidadUsar = archivo4array[i].CantidadUsar; //Se saca la cantidad a usar de la pieza
                        }
                    }
                    StockFinal = StockInicial - (AFabricar * CantidadUsar);//Error, tendria que agregar una forma de que el stock inicial se actualize cada vez que se usan piezas. No pude encontrar una forma.
                    if (StockFinal > 0)
                    {
                        StockFinal = System.Math.Abs(StockFinal);//Si el stock final es mayor a 0 no hay necesidad de calcular la minima cantidad a comprar para fabricar
                        MinimaCantidad = 0;
                        quetermine = ($"{archivo4array[i].NumeroPieza},{StockInicial},{StockFinal},{MinimaCantidad}");//Se le da formato a los datos pedidos y se escribe en una linea
                    }
                    else
                    {
                        StockFinal = 0; //Si el stock final es menor a 0 se calcula la minima cantidad
                        MinimaCantidad = System.Math.Abs((AFabricar * CantidadUsar) - StockInicial);
                        quetermine = ($"{archivo4array[i].NumeroPieza},{StockInicial},{StockFinal},{MinimaCantidad}");
                    }
                    if (AFabricar == 0) //Si no se necesita fabricar autos
                    {
                        StockFinal = StockInicial;
                        MinimaCantidad = 0;
                        quetermine = ($"{archivo4array[i].NumeroPieza},{StockInicial},{StockFinal},{MinimaCantidad}");
                    }
                    FileStream fs4 = new FileStream(archivotarea2, FileMode.Append, FileAccess.Write);
                    using (StreamWriter escritor = new StreamWriter(fs4))
                    {
                        escritor.WriteLine(quetermine); //Se escribe la linea con los datos
                    }
                    fs4.Close();
                }
            }
        }
        public List<tarea2> Lista6()//De nuevo, se pasa todo a una lista para poder mostrarlo
        {
            List<tarea2> lista = new List<tarea2>();
            FileStream fs = new FileStream(archivotarea2, FileMode.OpenOrCreate, FileAccess.Read);
            using (StreamReader lector = new StreamReader(fs))
            {
                string linea = lector.ReadLine();
                while (linea != null)
                {
                    tarea2 Neos = new tarea2(linea);
                    lista.Add(Neos);
                    linea = lector.ReadLine();
                }
            }
            fs.Close();
            return lista;
        }
        }
    }
