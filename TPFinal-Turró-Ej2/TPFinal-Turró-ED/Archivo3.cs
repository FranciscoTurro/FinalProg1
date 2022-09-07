using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal_Turró_ED
{
    public class Archivo3
    {
        public int NumeroPieza { get; set; }
        public string Descrip { get; set; }
        public int StockActual { get; set; }

        public Archivo3(string linea)
        {
            string[] data = linea.Split(',');
            this.NumeroPieza = int.Parse(data[0]);
            this.Descrip = data[1];
            this.StockActual = int.Parse(data[2]);
        }
        public Archivo3(int num)
        {
            this.NumeroPieza = num;
        }
        public string Registro()
        {
            return $"{NumeroPieza},{Descrip},{StockActual}";
        }
    }
}
