using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudoku
{
    public partial class Form1 : Form
    {

        Random rnd = new Random();
        int uretilenSayi = 100;
        int[,] sudokuDizisi = new int[9, 9];
        bool donenDeger;
        bool deger, t;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 9; i++)
            {
                for (int k = 0; k < 9; k++)
                {
                    while (deger == false)
                    {
                        uretilenSayi = rnd.Next(1, 10);
                        MessageBox.Show(uretilenSayi.ToString());
                        SatirKontrol(i, k, uretilenSayi);
                        t = SatirKontrol(i, k, uretilenSayi);
                        MessageBox.Show(t.ToString() + " satir");
                        t = SutunKontrol(i, k, uretilenSayi);
                        MessageBox.Show(t.ToString() + " sütün");
                        if (t == true)
                        {
                            listBox1.Items.Add(uretilenSayi);
                            sudokuDizisi[i, k] = uretilenSayi;
                            MessageBox.Show("diziye eklenen" + uretilenSayi.ToString());
                        }
                    }
                }


            }
        }

        private bool SatirKontrol(int satir, int sutun, int kontrolEdileccekSayi)
        {
            for (int i = 0; i < sutun; i++)
            {
                for (int k = 0; k < satir; k++)
                {
                    if (sudokuDizisi[i, k] != kontrolEdileccekSayi)
                    {
                        donenDeger = true;

                    }

                }

            }
            return donenDeger;

        }
        private bool SutunKontrol(int satir, int sutun, int kontrolEdileccekSayi)
        {
            for (int i = 0; i < satir; i++)
            {
                for (int k = 0; k < sutun; k++)
                {
                    if (sudokuDizisi[i, k] != kontrolEdileccekSayi)
                    {
                        donenDeger = true;

                    }


                }
            }

            return donenDeger;
        }
    }
}
