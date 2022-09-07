using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal_Turró_ED
{
    public class Archivo4
    {
        public int NumeroModelo { get; set; }
        public int NumeroPieza { get; set; }
        public int CantidadUsar { get; set; }

        public Archivo4(string linea)
        {
            string[] data = linea.Split(',');
            this.NumeroModelo = int.Parse(data[0]);
            this.NumeroPieza = int.Parse(data[1]);
            this.CantidadUsar = int.Parse(data[2]);
        }
        public Archivo4(int num)
        {
            this.NumeroModelo = num;
        }
        public string Registro()
        {
            return $"{NumeroModelo},{NumeroPieza},{CantidadUsar}";
        }
    }
}
