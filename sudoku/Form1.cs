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
     
        bool sayiUygunmu, t;
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
                    do
                    {
                        uretilenSayi = rnd.Next(1, 10);
                        //MessageBox.Show(uretilenSayi.ToString());
                        sayiUygunmu = SatirKontrol(i, k, uretilenSayi);
                        if (!sayiUygunmu)
                        {
                            continue;
                        }
                       
                        sayiUygunmu = SutunKontrol(i, k, uretilenSayi);
                        if (!sayiUygunmu)
                        {
                            continue;
                        }
                       
                        if (sayiUygunmu)
                        {
                            listBox1.Items.Add(uretilenSayi);
                            sudokuDizisi[i, k] = uretilenSayi;
                            //MessageBox.Show("diziye eklenen" + uretilenSayi.ToString());
                        }
                    } while (!sayiUygunmu);
                }


            }
            MessageBox.Show("Bitti");
        }

        private bool SatirKontrol(int satir, int sutun, int kontrolEdileccekSayi)
        {
            bool donenDeger=true;
                for (int k = 0; k <= sutun; k++)
                {
                    if (sudokuDizisi[satir, k] == kontrolEdileccekSayi)
                    {
                        donenDeger = false;

                    }

                }
            return donenDeger;

        }
        private bool SutunKontrol(int satir, int sutun, int kontrolEdileccekSayi)
        {
            bool donenDeger=true;
                for (int k = 0; k <= satir; k++)
                {
                    if (sudokuDizisi[k, sutun] == kontrolEdileccekSayi)
                    {
                        donenDeger = true;

                    }


                }        

            return donenDeger;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
