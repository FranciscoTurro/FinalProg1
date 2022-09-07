using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal_Turró_ED
{
    public class tarea2
    {
        public int Pieza { get; set; }
        public int StockInicial { get; set; }
        public int StockFinal { get; set; }
        public int MinimaCantidadAComprar { get; set; }
        public tarea2(string linea)
        {
            string[] data = linea.Split(',');
            this.Pieza = int.Parse(data[0]);
            this.StockInicial = int.Parse(data[1]);
            this.StockFinal = int.Parse(data[2]);
            this.MinimaCantidadAComprar = int.Parse(data[3]);
        }
    }
}
