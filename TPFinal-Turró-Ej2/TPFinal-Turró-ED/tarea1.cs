using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal_Turró_ED
{
    public class tarea1
    {
        public int Modelo { get; set; }
        public int StockInicial { get; set; }
        public int CantidadPedida { get; set; }
        public int StockFinal { get; set; }
        public int AFabricar { get; set; }
        public int SeAdeudan { get; set; }
        public tarea1(string linea)
        {
            string[] data = linea.Split(',');
            this.Modelo = int.Parse(data[0]);
            this.StockInicial = int.Parse(data[1]);
            this.CantidadPedida = int.Parse(data[2]);
            this.StockFinal = int.Parse(data[3]);
            this.AFabricar = int.Parse(data[4]);
            this.SeAdeudan = int.Parse(data[5]);
        }
    }
}
