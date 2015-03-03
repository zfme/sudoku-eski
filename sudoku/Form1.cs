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
        int uretilenSayi;
        int[,] sudokuDizisi = new int[9, 9];
        int tekrarSayisi = 0;
        bool sayiUygunmu;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gec = "";
            for (int i = 0; i < 9; i++)
            {
            
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

                        sayiUygunmu = SutunKontrol(i, k, uretilenSayi);
                        if (!sayiUygunmu)
                        {
                            tekrarSayisi++;
                            if (tekrarSayisi > 100)
                            {
                                for (int t = 0; t < 9; t++)
                                {
                                    sudokuDizisi[i, t] = 0;
                                    gec = null;
                                }
                                tekrarSayisi = 0;
                                k = -1;
                                break;
                            }
                            continue;
                        }
                      
      
                        if (sayiUygunmu)
                        {
                            sudokuDizisi[i, k] = uretilenSayi;
                            gec = gec + "  " + sudokuDizisi[i, k].ToString();
                        }
                     
                
                    }
                    while (!sayiUygunmu);
                }
                //for (int z = 0; z < 9; z++)
                //{
                //    for (int f = 0; f < 9; f++)
                //    {
                //        gec = gec + "  " + sudokuDizisi[z,f].ToString();
                //    }
                //}

                listBox1.Items.Add(gec);
               gec = "";

            }

       
        }

    

  

        private bool SatirKontrol(int satir, int sutun, int kontrolEdileccekSayi)
        {
            bool donenDeger=true;
  
                for (int k = 0; k < sutun; k++)
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
