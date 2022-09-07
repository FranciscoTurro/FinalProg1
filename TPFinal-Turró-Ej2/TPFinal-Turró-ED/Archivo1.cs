using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal_Turró_ED
{
    public class Archivo1
    {
        public int NumeroModelo { get; set; }
        public int Conces { get; set; }
        public int CantidadPedida { get; set; }

        public Archivo1(string linea)
        {
            string[] data = linea.Split(',');
            this.NumeroModelo = int.Parse(data[0]);
            this.Conces = int.Parse(data[1]);
            this.CantidadPedida = int.Parse(data[2]);
        }
        public Archivo1(int num)
        {
            this.NumeroModelo = num;
        }
        public string Registro()
        {
            return $"{NumeroModelo},{Conces},{CantidadPedida}";
        }
    }
}
