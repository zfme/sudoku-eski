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
      
        bool sayiUygunmu, sayiUygunmu1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gec = "";
            for (int i = 0; i < 9; i++)
            {
                int tekrarSayisi = 0;
                for (int k = 0; k < 9; k++)
                {
                    do
                    {
                        uretilenSayi = rnd.Next(1, 10);

                        sayiUygunmu = SatirKontrol(i, k, uretilenSayi);
                      
                        if (!sayiUygunmu)
                        {
                        
                            continue;
                        }
             
                        sayiUygunmu= SutunKontrol(i, k, uretilenSayi);
                        if (!sayiUygunmu)
                        {
                            tekrarSayisi = tekrarSayisi + 1;
                            if (tekrarSayisi==9)
                            {

                                Array.Clear(sudokuDizisi, i * 9 + 1, k);
                                k = 0;
                                tekrarSayisi = 0;
                                continue;
                            }
                            continue;
                        }

                        if (sayiUygunmu)
                        {
                           // MessageBox.Show(uretilenSayi.ToString());
                           // listBox1.Items.Add(uretilenSayi);
                            sudokuDizisi[i, k] = uretilenSayi;                            
                            gec = gec + "  " + sudokuDizisi[i, k].ToString();
                        }
                      
                
                    }
                    while (!sayiUygunmu);
                }
                listBox1.Items.Add(gec);
                gec = "";

            }

 
        }

        private bool SatirKontrol(int satir, int sutun, int kontrolEdileccekSayi)
        {
            bool donenDeger=true;
            if (sutun>0)
            {
                for (int k = 0; k < sutun; k++)
                {
                    if (sudokuDizisi[satir, k] == kontrolEdileccekSayi)
                    {
                        donenDeger = false;

                    }

                }
                
            }
                
            return donenDeger;

        }
        private bool SutunKontrol(int satir, int sutun, int kontrolEdileccekSayi)
        {
            bool donenDeger=true;
            if (satir>0)
            {
                for (int k = 0; k < satir; k++)
                {
                    if (sudokuDizisi[k, sutun] == kontrolEdileccekSayi)
                    {
                        donenDeger = false;

                    }

                }  
            }

            return donenDeger;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
