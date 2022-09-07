using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinal_Turró_ED
{
    public partial class Form1 : Form
    {
        public Gestor gestor = new Gestor();
        public Form1()
        {
            InitializeComponent();
            gestor.borrar1();
            gestor.borrar5();
            gestor.borrar6();
            LlenarGrilla(); //Al iniciar se borran los datos de los archivos que se espera complete el usuario
        }
        private void LlenarGrilla() //Se refrescan todas las listas en pantalla
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = gestor.Lista();
            this.dataGridView2.DataSource = gestor.Lista2();
            this.dataGridView3.DataSource = gestor.Lista3();
            this.dataGridView4.DataSource = gestor.Lista4();
            this.dataGridView5.DataSource = gestor.Lista5();
            this.dataGridView6.DataSource = gestor.Lista6();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Archivo1 modelo = new Archivo1((int)(numericUpDown1.Value)); //Carga de datos, saca la informacion de los respectivos numericupdowns y textboxes. Se repite para cada archivo
            {
                modelo.Conces = ((int)(numericUpDown2.Value));
                modelo.CantidadPedida = ((int)(numericUpDown3.Value));
            }
            gestor.guardar(modelo);
            LlenarGrilla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Archivo2 modelo = new Archivo2((int)(numericUpDown6.Value));
            {
                modelo.Descrip = textBox1.Text;
                modelo.StockActual = ((int)(numericUpDown4.Value));
            }
            gestor.guardar(modelo);
            LlenarGrilla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Archivo3 modelo = new Archivo3((int)(numericUpDown7.Value));
            {
                modelo.Descrip = textBox2.Text;
                modelo.StockActual = ((int)(numericUpDown5.Value));
            }
            gestor.guardar(modelo);
            LlenarGrilla();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Archivo4 modelo = new Archivo4((int)(numericUpDown9.Value));
            {
                modelo.NumeroPieza = ((int)(numericUpDown10.Value));
                modelo.CantidadUsar = ((int)(numericUpDown8.Value));
            }
            gestor.guardar(modelo);
            LlenarGrilla();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gestor.borrar1(); //Borra el archivo, se repite para todos los demas
            LlenarGrilla();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            gestor.borrar2();
            LlenarGrilla();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gestor.borrar3();
            LlenarGrilla();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            gestor.borrar4();
            LlenarGrilla();
        }

        private void button5_Click(object sender, EventArgs e)//Se realiza el ejercicio con esto, se envia el numero de modelo y la cantidad pedida
        {
            gestor.tarea1((int)(numericUpDown1.Value), (int)(numericUpDown3.Value));
            gestor.intento2((int)(numericUpDown1.Value), (int)(numericUpDown3.Value));
            gestor.borrar1();
            LlenarGrilla();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            gestor.borrar5();
            LlenarGrilla();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            gestor.borrar6();
            LlenarGrilla();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
