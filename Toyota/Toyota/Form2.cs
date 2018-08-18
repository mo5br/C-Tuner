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
using System.Reflection;

namespace Toyota
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            File.WriteAllBytes(System.IO.Path.GetTempPath() + "\\Aurion", Properties.Resources.BitBox_VR_89663_33652_20_08_1439_11_13);
            String path = System.IO.Path.GetTempPath() + "\\Aurion";
            int mtype = 0;
            int i;
            byte[] buffer = new byte[4];
            byte[] model1 = new byte[14];
            int j;
            int check=0;
            byte[] ByteBuffer = File.ReadAllBytes(path);
            byte[] StringBytes = Encoding.UTF8.GetBytes("89663-");
            for ( i = 0; i <= (ByteBuffer.Length - StringBytes.Length); i++)
            {
                if (ByteBuffer[i] == StringBytes[0])
                {
                    for (j = 1; j < StringBytes.Length && ByteBuffer[i + j] == StringBytes[j]; j++) ;
                    if (j == StringBytes.Length)
                    {
                        Console.WriteLine("String was found at offset {0}", i.ToString("X"));
                        mtype = i;
                        check++;
                    }
                    
                }
            }

            if (check != 2)
            {
                MessageBox.Show( "File is Corrupted");
            }
            
            textBox2.Text = path;
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            fs.Position = mtype;
            Console.WriteLine(mtype.ToString("X") + "          ");
            fs.Read(model1, 0, 14);
            Console.WriteLine(ConvertHexToString( BitConverter.ToString( model1).Replace("-", string.Empty)));
            label4.Text = ConvertHexToString(BitConverter.ToString(model1).Replace("-", string.Empty));
            fs.Position = 0x63BC;
            fs.Read(buffer, 0, 4);
            int result = BitConverter.ToInt32(buffer, 0);
            textBox1.Text = result.ToString();
            trackBar1.Value = int.Parse(textBox1.Text);
            fs.Dispose();
            fs.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
                       SaveFileDialog oo = new SaveFileDialog();
            if (oo.ShowDialog() == DialogResult.OK)
            {
                string path = oo.FileName;
                string path2 = textBox2.Text;
                byte[] array = File.ReadAllBytes(path2);
                System.IO.File.WriteAllBytes(path, array);
                byte[] buffer = new byte[4];
                FileStream fs = new FileStream(path, FileMode.Open);
                fs.Position = 0x63BC;
                if (int.Parse(textBox1.Text) > 10){
                    int intValue = int.Parse(textBox1.Text);
                    Console.WriteLine(intValue);
                    byte[] bytes = new byte[4];
                    bytes[0] = (byte)(int.Parse(textBox1.Text )>> 24);
                    bytes[1] = (byte)(int.Parse(textBox1.Text ) >> 16);
                    bytes[2] = (byte)(int.Parse(textBox1.Text ) >> 8);
                    bytes[3] = (byte)int.Parse(textBox1.Text );
                    fs.WriteByte( bytes[3] );
                    fs.WriteByte( bytes[2] );
                    fs.WriteByte(bytes[1]);
                    fs.WriteByte(bytes[0]);
                    Console.WriteLine("{0} breaks down to : {1} {2} {3} {4}",    intValue, bytes[0], bytes[1], bytes[2], bytes[3]);
                
       		}
                if (checkBox2.Checked )
                {
                    fs.Position = 0x106D8;
                    for (int i = 0; i < 16; i++)
                    {
                        fs.WriteByte(00);
                    }

                }
                if (checkBox1.Checked)
                {
                    fs.Position = 0x106F8;
                    for (int i = 0; i < 8; i++)
                    {
                        fs.WriteByte(00);
                    }

                }

                fs.Position = 0x942C;


                fs.Dispose();
                fs.Close();
        }
        }
        public static string ConvertHexToString(string HexValue)
        {
            string StrValue = "";
            Console.WriteLine(HexValue);
            while (HexValue.Length*2 > 0)
            {
                StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
                HexValue = HexValue.Substring(2, HexValue.Length - 2);
            }
            return StrValue;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Orange, 3);
            gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, 0, 5, 10, 5);
            gfx.DrawLine(p, 62, 5, e.ClipRectangle.Width - 2, 5);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);  
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }


    }
    }


