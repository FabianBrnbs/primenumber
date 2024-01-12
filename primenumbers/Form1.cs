using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace primenumbers
{
    public partial class Form1 : Form
    {
        List<int> PrimLista = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ElsoFeltoltes();
            int szam = 0;
            MilyenVizsgalatKell(24989);
            
        }

        void MilyenVizsgalatKell(int n)
        {
            int gyok = (int)Math.Sqrt(n);
            /*if (gyok <= PrimLista.Max())
            {

            }
            else
            {
                Prim_e_Alap(PrimLista.Max() + 2, gyok);
            }*/
        if (gyok > PrimLista.Max())
            {
                Prim_e_Alap(PrimLista.Max() + 2, gyok);
            }
            Text = Prim_e(n, gyok).ToString();
        }

        bool Prim_e(int szam, int gyok)
        {
            for (int i = 1; i < PrimLista.Count && PrimLista[i] <= gyok; i++)
            {
                if (szam % PrimLista[i] == 0) return false;
            }

            return true;
        }


        void ElsoFeltoltes()
        {
            if (!File.Exists("primek.txt") || File.ReadAllLines("primek.txt").Length == 0)
            {
                Prim_e_Alap();
                File.WriteAllLines("primek.txt", PrimLista.ConvertAll(Convert.ToString));
            }
            else {
                PrimLista.AddRange(File.ReadAllLines("primek.txt").ToList().ConvertAll(Convert.ToInt32));
            }
            Text = "anyu";
        }

        void Prim_e_Alap(int also = 3, int felso = 98)
        {
            //int gyok = (int)Math.Truncate(Math.Sqrt(n));
            if (!File.Exists("primek.txt")) {

                File.WriteAllLines("primek.txt", "2"\n);
            } 
            var sw = new StreamWriter("primek.txt", true);
            for (int n = also; n < felso; n++)
            {
                int gyok = (int)Math.Sqrt(n);
                bool Prim = true;
                for (int i = 2; i <= gyok && Prim; i++)
                {
                    if (n % i == 0) Prim = false;
                }
                if (Prim)
                {
                    PrimLista.Add(n);
                    // var f = File.OpenWrite("primek.txt");
                    // f.wri
                    sw.WriteLine(PrimLista.Last().ToString());
                }
            }
            sw.Close();

        }
    }
}
