using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal_Turró_ED
{
    public class Archivo2
    {
        public int NumeroModelo { get; set; }
        public string Descrip { get; set; }
        public int StockActual { get; set; }

        public Archivo2(string linea)
        {
            string[] data = linea.Split(',');
            this.NumeroModelo = int.Parse(data[0]);
            this.Descrip = data[1];
            this.StockActual = int.Parse(data[2]);
        }
        public Archivo2(int num)
        {
            this.NumeroModelo = num;
        }
        public string Registro()
        {
            return $"{NumeroModelo},{Descrip},{StockActual}";
        }
    }
}
