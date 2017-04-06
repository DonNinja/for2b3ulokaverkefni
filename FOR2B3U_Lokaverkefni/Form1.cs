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
        Random rand1 = new Random();
        List<int> spilari = new List<int>();
        List<int> tolva = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btDraga_Click(object sender, EventArgs e)
        {
            panel1.BackgroundImage = imageList1.Images[rand1.Next(52)];
            panel2.BackgroundImage = imageList1.Images[rand1.Next(52)];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 53; i++)
            {
                if (i % 2 == 0)
                {
                    spilari.Add(i);
                }
                else
                {
                    tolva.Add(i);
                }
            }
        }
    }
}
