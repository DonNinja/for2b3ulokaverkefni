using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOR2B3U_Lokaverkefni
{
    public partial class Form1 : Form
    {
        int teljariSpil = 0;
        Random rand1 = new Random();
        List<int> spilari = new List<int>();
        List<int> tolva = new List<int>();
        List<int> stokkur = new List<int>();
        Gagnagrunnur Gagnagrunnur = new Gagnagrunnur();
        public Form1()
        {
            InitializeComponent();
            try
            {
                Gagnagrunnur.TengingVidGagnagrunn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 52; i++)
            {
                stokkur.Add(i);
            }

            while (stokkur.Count > 0)
            {
                int randTala = rand1.Next(0, stokkur.Count);
                if (teljariSpil % 2 == 0)
                {
                    spilari.Add(stokkur[randTala]);
                }
                else
                {
                    tolva.Add(stokkur[randTala]);
                }
                teljariSpil++;
                stokkur.Remove(stokkur[randTala]);
            }
        }
        int tel = 0;
        private void btDraga_Click(object sender, EventArgs e)
        {
            if (tel == spilari.Count)
            {
                btDraga.Visible = false;
            }
            panel2.BackgroundImage = imageList1.Images[spilari[tel]];
            string myndspilara = imageList1.Images.Keys[spilari[tel]].ToString();
            panel1.BackgroundImage = imageList1.Images[tolva[tel]];
            string myndtolvu = imageList1.Images.Keys[tolva[tel]].ToString();
            tel++;
            myndspilara = myndspilara.Substring(0, (myndspilara.Length - 4));
            myndtolvu = myndtolvu.Substring(0, (myndtolvu.Length - 4));
           // string nafnmyndar = imageList1.Images.Keys(spilari[tel]).ToString();
            rtbVann.Text = myndspilara + "\n";
            rtbVann.Text += myndtolvu;
        }

        private void btKilo_Click(object sender, EventArgs e)
        {

        }
    }
}