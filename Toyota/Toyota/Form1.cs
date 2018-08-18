using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Toyota
{
    public partial class Form1 : Form
    {

        public Form1()
        {


            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    CarPic.Image = Toyota.Properties.Resources.Toyota_Aurion_2012_wallpaper;
                    break;
                case 1:
                    CarPic.Image = Toyota.Properties.Resources.Lexus;
                    break;
            }
        }


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    Form2 Aurion = new Form2();
                    Aurion.Show();
                    break;
                case 1:
                    Form3 Lexus = new Form3();
                    Lexus.Show();
                    break;
            }
        }

        private void CarPic_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
