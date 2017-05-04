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
        List<int> aukastokkur = new List<int>();
        Gagnagrunnur Gagnagrunnur = new Gagnagrunnur();
        int tel = 0;
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
        int tel2 = 0;
        private void btDraga_Click(object sender, EventArgs e)
        {
            rtbVann.Clear();
            if (tel >= spilari.Count)
            {
                tel = 0;
            }
            else if (tel2 >= tolva.Count)
            {
                tel2 = 0;
            }
            
                 if (spilari.Count - 1 !=0 && tolva.Count - 1 != 0)

            {
                if (tel == spilari.Count - 1 && tel2 == tolva.Count - 1)
                {
                    btDraga.Visible = false;
                }
                panel2.BackgroundImage = imageList1.Images[spilari[tel]];
                string myndspilara = imageList1.Images.Keys[spilari[tel]].ToString();
                panel1.BackgroundImage = imageList1.Images[tolva[tel]];
                string myndtolvu = imageList1.Images.Keys[tolva[tel]].ToString();

                myndspilara = myndspilara.Substring(0, (myndspilara.Length - 4));
                myndtolvu = myndtolvu.Substring(0, (myndtolvu.Length - 4));
                // string nafnmyndar = imageList1.Images.Keys(spilari[tel]).ToString();
               // rtbVann.Text = myndspilara + "\n";
               // rtbVann.Text += myndtolvu + "\n\n";
                panel1.Visible = false;

                rtbVann.Text += "veldu flokkinn sem þú vilt keppa í";
            }
            else
            {
                if (spilari.Count > tolva.Count)
                {
                    MessageBox.Show("Húrra!!! Þú vannst");
                }
                else
                {
                    MessageBox.Show("Awwwwwww Þú tapaðir");
                }
                MessageBox.Show("spilið búið");
            }           
        }

        private void btKilo_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            string myndspilara = imageList1.Images.Keys[spilari[tel]].ToString();
            string myndtolvu = imageList1.Images.Keys[tolva[tel]].ToString();
            myndspilara = myndspilara.Substring(0, (myndspilara.Length - 4));
            myndtolvu = myndtolvu.Substring(0, (myndtolvu.Length - 4));
            
            double playerUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("kilothyngd", myndspilara));
            double tolvaUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("kilothyngd", myndtolvu));

            rtbVann.Text = playerUt + "\n";
            rtbVann.Text += tolvaUt + "\n\n";

            if (playerUt > tolvaUt)
            {
                rtbVann.Text += "Þú vannst þessa lotu";
                spilari.Add(tolva[tel]);
                tolva.Remove(tolva[tel]);
            }
            else if (playerUt < tolvaUt)
            {
                rtbVann.Text += "tölvan vann þessa lotu";
                tolva.Add(spilari[tel]);
                spilari.Remove(spilari[tel]);
            }
            else
            {
                rtbVann.Text += "það var jafntefli";
                aukastokkur.Add(tolva[tel]);
                aukastokkur.Add(spilari[tel]);
            }
            panel1.Visible = true;
            tel++;
            tel2++;
        }

        private void btMjolk_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            string myndspilara = imageList1.Images.Keys[spilari[tel]].ToString();
            string myndtolvu = imageList1.Images.Keys[tolva[tel]].ToString();
            myndspilara = myndspilara.Substring(0, (myndspilara.Length - 4));
            myndtolvu = myndtolvu.Substring(0, (myndtolvu.Length - 4));

            double playerUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("mjolkurlagni", myndspilara));
            double tolvaUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("mjolkurlagni", myndtolvu));

            rtbVann.Text = playerUt + "\n";
            rtbVann.Text += tolvaUt + "\n\n";

            if (playerUt > tolvaUt)
            {
                rtbVann.Text += "Þú vannst þessa lotu";
                spilari.Add(tolva[tel]);
                tolva.Remove(tolva[tel]);
            }
            else if (playerUt < tolvaUt)
            {
                rtbVann.Text += "tölvan vann þessa lotu";
                tolva.Add(spilari[tel]);
                spilari.Remove(spilari[tel]);
            }
            else
            {
                rtbVann.Text += "það var jafntefli";
                aukastokkur.Add(tolva[tel]);
                aukastokkur.Add(spilari[tel]);
            }
            panel1.Visible = true;
            tel++;
            tel2++;
        }

        private void btUll_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            string myndspilara = imageList1.Images.Keys[spilari[tel]].ToString();
            string myndtolvu = imageList1.Images.Keys[tolva[tel]].ToString();
            myndspilara = myndspilara.Substring(0, (myndspilara.Length - 4));
            myndtolvu = myndtolvu.Substring(0, (myndtolvu.Length - 4));

            double playerUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("ullareinkunn", myndspilara));
            double tolvaUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("ullareinkunn", myndtolvu));

            rtbVann.Text = playerUt + "\n";
            rtbVann.Text += tolvaUt + "\n\n";

            if (playerUt > tolvaUt)
            {
                rtbVann.Text += "Þú vannst þessa lotu";
                spilari.Add(tolva[tel]);
                tolva.Remove(tolva[tel]);
            }
            else if (playerUt < tolvaUt)
            {
                rtbVann.Text += "tölvan vann þessa lotu";
                tolva.Add(spilari[tel]);
                spilari.Remove(spilari[tel]);
            }
            else
            {
                rtbVann.Text += "það var jafntefli";
                aukastokkur.Add(tolva[tel]);
                aukastokkur.Add(spilari[tel]);
            }
            panel1.Visible = true;
            tel++;
            tel2++;
        }

        private void btBorn_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            string myndspilara = imageList1.Images.Keys[spilari[tel]].ToString();
            string myndtolvu = imageList1.Images.Keys[tolva[tel]].ToString();
            myndspilara = myndspilara.Substring(0, (myndspilara.Length - 4));
            myndtolvu = myndtolvu.Substring(0, (myndtolvu.Length - 4));

            double playerUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("fjoldibarna", myndspilara));
            double tolvaUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("fjoldibarna", myndtolvu));

            rtbVann.Text = playerUt + "\n";
            rtbVann.Text += tolvaUt + "\n\n";

            if (playerUt > tolvaUt)
            {
                rtbVann.Text += "Þú vannst þessa lotu";
                spilari.Add(tolva[tel]);
                tolva.Remove(tolva[tel]);
            }
            else if (playerUt < tolvaUt)
            {
                rtbVann.Text += "tölvan vann þessa lotu";
                tolva.Add(spilari[tel]);
                spilari.Remove(spilari[tel]);
            }
            else
            {
                rtbVann.Text += "það var jafntefli";
                aukastokkur.Add(tolva[tel]);
                aukastokkur.Add(spilari[tel]);
            }
            panel1.Visible = true;
            tel++;
            tel2++;
        }

        private void btLaeri_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            string myndspilara = imageList1.Images.Keys[spilari[tel]].ToString();
            string myndtolvu = imageList1.Images.Keys[tolva[tel]].ToString();
            myndspilara = myndspilara.Substring(0, (myndspilara.Length - 4));
            myndtolvu = myndtolvu.Substring(0, (myndtolvu.Length - 4));

            double playerUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("einkunnlaeris", myndspilara));
            double tolvaUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("einkunnlaeris", myndtolvu));

            rtbVann.Text = playerUt + "\n";
            rtbVann.Text += tolvaUt + "\n\n";

            if (playerUt > tolvaUt)
            {
                rtbVann.Text += "Þú vannst þessa lotu";
                spilari.Add(tolva[tel]);
                tolva.Remove(tolva[tel]);
            }
            else if (playerUt < tolvaUt)
            {
                rtbVann.Text += "tölvan vann þessa lotu";
                tolva.Add(spilari[tel]);
                spilari.Remove(spilari[tel]);
            }
            else
            {
                rtbVann.Text += "það var jafntefli";
                aukastokkur.Add(tolva[tel]);
                aukastokkur.Add(spilari[tel]);
            }
            panel1.Visible = true;
            tel++;
            tel2++;
        }

        private void btFrjo_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            string myndspilara = imageList1.Images.Keys[spilari[tel]].ToString();
            string myndtolvu = imageList1.Images.Keys[tolva[tel]].ToString();
            myndspilara = myndspilara.Substring(0, (myndspilara.Length - 4));
            myndtolvu = myndtolvu.Substring(0, (myndtolvu.Length - 4));

            double playerUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("frjosemi", myndspilara));
            double tolvaUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("frjosemi", myndtolvu));

            rtbVann.Text = playerUt + "\n";
            rtbVann.Text += tolvaUt + "\n\n";

            if (playerUt > tolvaUt)
            {
                rtbVann.Text += "Þú vannst þessa lotu";
                spilari.Add(tolva[tel]);
                tolva.Remove(tolva[tel]);
            }
            else if (playerUt < tolvaUt)
            {
                rtbVann.Text += "tölvan vann þessa lotu";
                tolva.Add(spilari[tel]);
                spilari.Remove(spilari[tel]);
            }
            else
            {
                rtbVann.Text += "það var jafntefli";
                aukastokkur.Add(tolva[tel]);
                aukastokkur.Add(spilari[tel]);
            }
            panel1.Visible = true;
            tel++;
            tel2++;
        }

        private void btBak_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            string myndspilara = imageList1.Images.Keys[spilari[tel]].ToString();
            string myndtolvu = imageList1.Images.Keys[tolva[tel]].ToString();
            myndspilara = myndspilara.Substring(0, (myndspilara.Length - 4));
            myndtolvu = myndtolvu.Substring(0, (myndtolvu.Length - 4));

            double playerUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("bakvodvi", myndspilara));
            double tolvaUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("bakvodvi", myndtolvu));

            rtbVann.Text = playerUt + "\n";
            rtbVann.Text += tolvaUt + "\n\n";

            if (playerUt > tolvaUt)
            {
                rtbVann.Text += "Þú vannst þessa lotu";
                spilari.Add(tolva[tel]);
                tolva.Remove(tolva[tel]);
            }
            else if (playerUt < tolvaUt)
            {
                rtbVann.Text += "tölvan vann þessa lotu";
                tolva.Add(spilari[tel]);
                spilari.Remove(spilari[tel]);
            }
            else
            {
                rtbVann.Text += "það var jafntefli";
                aukastokkur.Add(tolva[tel]);
                aukastokkur.Add(spilari[tel]);
            }
            panel1.Visible = true;
            tel++;
            tel2++;
        }

        private void btMal_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            string myndspilara = imageList1.Images.Keys[spilari[tel]].ToString();
            string myndtolvu = imageList1.Images.Keys[tolva[tel]].ToString();
            myndspilara = myndspilara.Substring(0, (myndspilara.Length - 4));
            myndtolvu = myndtolvu.Substring(0, (myndtolvu.Length - 4));

            double playerUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("malireinkun", myndspilara));
            double tolvaUt = Convert.ToDouble(Gagnagrunnur.LesautSQLToflu("malireinkun", myndtolvu));

            rtbVann.Text = playerUt + "\n";
            rtbVann.Text += tolvaUt + "\n\n";

            if (playerUt > tolvaUt)
            {
                rtbVann.Text += "Þú vannst þessa lotu";
                spilari.Add(tolva[tel]);
                tolva.Remove(tolva[tel]);
            }
            else if (playerUt < tolvaUt)
            {
                rtbVann.Text += "tölvan vann þessa lotu";
                tolva.Add(spilari[tel]);
                spilari.Remove(spilari[tel]);
            }
            else
            {
                rtbVann.Text += "það var jafntefli";
                aukastokkur.Add(tolva[tel]);
                aukastokkur.Add(spilari[tel]);
            }
            panel1.Visible = true;
            tel++;
            tel2++;
        }
    }
}