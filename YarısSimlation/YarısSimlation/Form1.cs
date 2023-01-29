using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace YarisSimlation
{
    
    public partial  class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Yarisma yaris1 = new Yarisma("yarismacilar.txt", 45);
            yaris1.sifirla();
            int max1 = yaris1.yarismaPisti.PistUzunlugu-1;
            int max2 = yaris1.maxKonum();
            richTextBox1.Clear();
            richTextBox1.Text = richTextBox1.Text + yaris1.yarismacilar[1].Isim.ToString() + " : ";
            richTextBox1.Text = richTextBox1.Text + yaris1.yarismacilar[2].Isim.ToString() + " : ";
            richTextBox1.Text = richTextBox1.Text + yaris1.yarismacilar[3].Isim.ToString() + " : ";
            richTextBox1.Text = richTextBox1.Text + yaris1.yarismacilar[0].Isim.ToString() + " : ";
            richTextBox1.Text = richTextBox1.Text + "\n";


            while (max2 < max1 )
            {
                try { 
                yaris1.Baslat();
                }catch{ MessageBox.Show("hata var"); }
                pictureBox1.Left =(yaris1.yarismacilar[1].Konum*((panel1.Width-2)/max1));
                pictureBox2.Left = (yaris1.yarismacilar[2].Konum*((panel1.Width-2) / max1));
                pictureBox3.Left =(yaris1.yarismacilar[3].Konum*((panel1.Width-2) / max1));
                pictureBox4.Left =(yaris1.yarismacilar[0].Konum*((panel1.Width-2) / max1));
                
                max1 = yaris1.yarismaPisti.PistUzunlugu;
                max2 = yaris1.maxKonum();
                richTextBox1.Text= richTextBox1.Text+ "    :       " + yaris1.yarismacilar[1].Konum.ToString()+"      :       ";
                richTextBox1.Text = richTextBox1.Text + yaris1.yarismacilar[2].Konum.ToString()+"       :       ";
                richTextBox1.Text = richTextBox1.Text + yaris1.yarismacilar[3].Konum.ToString()+"       :       ";
                richTextBox1.Text = richTextBox1.Text + yaris1.yarismacilar[0].Konum.ToString();
                richTextBox1.Text = richTextBox1.Text + "\n";
                if(yaris1.p==0)
                {
                    pictureBox9.Location = new System.Drawing.Point(pictureBox3.Location.X, pictureBox3.Location.Y);
                    
                    label8.Text = "Devekuşu "+yaris1.avlayan+" tarafından avlanıldı!!!";
                }
            }
            label1.Text = yaris1.yarismacilar[3].Konum.ToString();
            label2.Text = yaris1.yarismacilar[0].Konum.ToString();
            label3.Text = yaris1.yarismacilar[2].Konum.ToString();
            label4.Text = yaris1.yarismacilar[1].Konum.ToString();
            label7.Text= yaris1.yarismacilar[2].Konum.ToString();
            foreach (var eleman in yaris1.yarismacilar)
                if(eleman.Konum==max2)
                {
                    MessageBox.Show("KAZANAN "+ eleman.Isim,"TEBRİKLER" , MessageBoxButtons.OK);  
                }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            pictureBox1.Location = new System.Drawing.Point(25, 3);
            pictureBox2.Location = new System.Drawing.Point(25, 120);
            pictureBox3.Location = new System.Drawing.Point(25, 243);
            pictureBox4.Location = new System.Drawing.Point(25, 369);
            pictureBox9.Location = new System.Drawing.Point(1128, 516);
            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "0";
            label4.Text = "0";
            label7.Text = "0";
            label8.Text = ":";

        }
    }
}
