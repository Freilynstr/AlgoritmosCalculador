using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += TextBox1_KeyPress; 
        }

        // Handle the KeyPress event to print the type of character entered into the control.
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string aceptados = "1234567890,." + Convert.ToChar(8);

            if (aceptados.Contains("" + e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] conjunto = textBox1.Text.Split(',');
            int[] conjuntoNumerico = new int[conjunto.Length];
            if(textBox1.Text != "")
            {
                for (int i = 0; i < conjunto.Length; i++)
                {
                    try
                    {
                        conjuntoNumerico[i] = Int32.Parse(conjunto[i]);
                    }
                    catch (Exception)
                    {
                        textBox2.Text = "El conjunto numérico no puede ser procesado";
                    }
                    
                }
                textBox2.Text = "";
                ProcesarConjunto(conjuntoNumerico);
            }
            else
            {
                textBox2.Text = "El conjunto numérico no puede ser procesado";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void ProcesarConjunto(int[] conjunto)
        {
            if (conjunto.Length % 4 == 0)
            {
                //Se procesará en cuartetos
                //return "Cuartetos";
            }
            else if (conjunto.Length % 3 == 0)
            {
                //Se procesará en ternas
                int[][] ternasDelConjunto = new int[(conjunto.Length / 3)][];
                int contador = 0;
                for (int i = 0; i < conjunto.Length / 3; i++)
                {
                    ternasDelConjunto[i] = new int[2];
                    for (int j = 0; j < 3; j++)
                    {
                        //Se obtienen los pares
                        ternasDelConjunto[i][j] = conjunto[contador];
                        contador++;
                    }
                }

                realizarOperacionConTernas(ternasDelConjunto);
            }
            else if (conjunto.Length % 2 == 0)
            {
                //Se procesará en pares
                int[][] paresDelConjunto = new int[(conjunto.Length / 2)][];
                int contador = 0;
                for (int i = 0; i < conjunto.Length / 2; i++)
                {
                    paresDelConjunto[i] = new int[2];
                    for (int j = 0; j < 2; j++)
                    {
                        //Se obtienen los pares
                        paresDelConjunto[i][j] = conjunto[contador];
                        contador++;
                    }
                }

                realizarOperacionConPares(paresDelConjunto);
            }
        }

        private void realizarOperacionConPares(int[][] paresDelConjunto)
        {
            string figura;
            for (int i = 0; i < paresDelConjunto.Length; i++)
            {
                if(paresDelConjunto[i][0] == paresDelConjunto[i][1])
                {
                    figura = "Esfera";
                    double radio = paresDelConjunto[i][0];
                    double perimetro =   2 * Math.PI * radio;
                    double area = 4 * Math.PI * Math.Pow(radio, 2);
                    textBox2.Text += "La figura es una " + figura + " y su perímetro es " + perimetro + " y su área es " + area + "\n";
                }
                else
                {
                    figura = "Rombo";
                    double lado = paresDelConjunto[i][0];
                    double altura = paresDelConjunto[i][1];
                    double perimetro = 2 * (Math.Sqrt((Math.Pow(lado, 2)) + (Math.Pow(altura, 2))));
                    double area = (lado * altura) / 2;
                    textBox2.Text += "La figura es una " + figura + " y su perímetro es " + perimetro + " y su área es " + area + "\n";
                }
            }
        }

        private void realizarOperacionConTernas(int[][] ternasDelConjunto)
        {
            string figura;
            for (int i = 0; i < ternasDelConjunto.Length; i++)
            {
                if ((ternasDelConjunto[i][0] == ternasDelConjunto[i][1]) && (ternasDelConjunto[i][1] == ternasDelConjunto[i][2]))
                {
                    figura = "Cubo";
                    double lado = ternasDelConjunto[i][0];
                    double perimetro = (4 * lado) + (4 * lado) + (4 * lado);
                    double area = 0;
                    textBox2.Text += "La figura es un " + figura + "su perímetro es " + perimetro + " y su área es " + area + "\n";
                }
                else if((ternasDelConjunto[i][0] == ternasDelConjunto[i][1]) || (ternasDelConjunto[i][0] == ternasDelConjunto[i][2]))
                {
                    //double lado = paresDelConjunto[i][0];
                    //double altura = paresDelConjunto[i][1];
                    figura = "Pirámide";
                    double resultado = 0;//(lado * altura) / 2;
                    textBox2.Text += "La figura es una" + figura + " y el resultado es " + resultado + "\n";
                }
            }
        }
    }
}
