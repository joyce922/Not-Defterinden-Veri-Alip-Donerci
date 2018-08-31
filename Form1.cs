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
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private List<int> fiyat = new List<int>();
        private List<string> yemek = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        public void boyutfiyat(decimal boyut,string boyut2)
        {
            decimal ucret = 0;                          
            ucret = fiyat[listBoxSİPARİŞ.SelectedIndex] * boyut;
            listBoxSONDURUM.Items.Add(boyut2 + " " + yemek[listBoxSİPARİŞ.SelectedIndex]);
            listBoxHESAP.Items.Add(ucret + " TL");            
        }

        private void buttonEKLE_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Yazı dosyaları (*txt)|*.txt";
            openFileDialog1.ShowDialog();
            StreamReader oku = new StreamReader(openFileDialog1.FileName);
            string sipariş = oku.ReadLine();
            while (sipariş != null)
            {
                string[] tmp = sipariş.Split(';');
                listBoxSİPARİŞ.Items.Add(tmp[0]);
                string sipariş2 = Convert.ToString(sipariş.Split(';'));
                sipariş = oku.ReadLine();
                fiyat.Add(Convert.ToInt32(tmp[1]));
                yemek.Add(tmp[0]);
            }
        }

        private void buttonTEK_Click(object sender, EventArgs e)
        {
            boyutfiyat(1, "Tek");
        }

        private void buttonBUÇUK_Click(object sender, EventArgs e)
        {
            boyutfiyat(1.5m, "Buçuk");
        }

        private void buttonDUBLE_Click(object sender, EventArgs e)
        {
            boyutfiyat(2, "Duble");
        }

        private void buttonKALDIR_Click(object sender, EventArgs e)
        {
            fiyat.RemoveAt(listBoxSİPARİŞ.SelectedIndex);
            yemek.RemoveAt(listBoxSİPARİŞ.SelectedIndex);
            listBoxSİPARİŞ.Items.Remove(listBoxSİPARİŞ.SelectedItem);
        }
    }
}
