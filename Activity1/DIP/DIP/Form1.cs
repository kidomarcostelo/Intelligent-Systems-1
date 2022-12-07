using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIP
{
    public partial class Form1 : Form
    {
        Bitmap _loaded, _processed;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            _loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = _loaded;
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _processed = new Bitmap(_loaded.Width, _loaded.Height);
            for (int x = 0; x < _loaded.Width; x++)
            {
                for (int y = 0; y < _loaded.Height; y++)
                {
                    Color data = _loaded.GetPixel(x, y);
                    int grey = (data.R + data.G + data.B) / 3;
                    Color greyscale = Color.FromArgb(grey, grey, grey);
                    _processed.SetPixel(x, y, greyscale);

                }

            }

            pictureBox2.Image = _processed;
        }

        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _processed = new Bitmap(_loaded.Width, _loaded.Height);
            for (int x = 0; x < _loaded.Width; x++)
            {
                for (int y = 0; y < _loaded.Height; y++)
                {
                    Color data = _loaded.GetPixel(x, y);
                    _processed.SetPixel(x, y, data);
                }

            }

            pictureBox2.Image = _processed;
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _processed = new Bitmap(_loaded.Width, _loaded.Height);
            for (int x = 0; x < _loaded.Width; x++)
            {
                for (int y = 0; y < _loaded.Height; y++)
                {
                    Color data = _loaded.GetPixel(x, y);
                    _processed.SetPixel(x, y, Color.FromArgb(255 - data.R, 255 - data.G, 255 - data.B));
                }

            }

            pictureBox2.Image = _processed;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color sample;
            Color gray;
            Byte graydata;
            //Grayscale Convertion;
            for (int x = 0; x < _loaded.Width; x++)
            {
                for (int y = 0; y < _loaded.Height; y++)
                {
                    sample = _loaded.GetPixel(x, y);
                    graydata = (byte)((sample.R + sample.G + sample.B) / 3);
                    gray = Color.FromArgb(graydata, graydata, graydata);
                    _loaded.SetPixel(x, y, gray);
                }
            }

            //histogram 1d data;
            int[] histdata = new int[256]; // array from 0 to 255
            for (int x = 0; x < _loaded.Width; x++)
            {
                for (int y = 0; y < _loaded.Height; y++)
                {
                    sample = _loaded.GetPixel(x, y);
                    histdata[sample.R]++; // can be any color property r,g or b
                }
            }
            
            // Bitmap Graph Generation
            // Setting empty Bitmap with background color
            _processed = new Bitmap(256, 800);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    _processed.SetPixel(x, y, Color.White);
                }
            }
            // plotting points based from histdata
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histdata[x] / 5, _processed.Height - 1); y++)
                {
                    _processed.SetPixel(x, (_processed.Height - 1) - y, Color.Black);
                }
            }

            pictureBox2.Image = _processed;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _processed = new Bitmap(_loaded.Width, _loaded.Height);
            for (int x = 0; x < _loaded.Width; x++)
            {
                for (int y = 0; y < _loaded.Height; y++)
                {
                    Color pixel = _loaded.GetPixel(x, y);

                    int red = Math.Min(255, (int)(pixel.R * 0.189 + pixel.G * 0.769 + pixel.B * 0.393));
                    int green = Math.Min(255, (int)(pixel.R * 0.168 + pixel.G * 0.686 + pixel.B * 0.349));
                    int blue = Math.Min(255, (int)(pixel.R * 0.131 + pixel.G * 0.534 + pixel.B * 0.272));

                    //int red = Math.Min(255, (int)(pixel.R * 0.393 + pixel.G * 0.769 + pixel.B * 0.189));
                    //int green = Math.Min(255, (int)(pixel.R * 0.349 + pixel.G * 0.686 + pixel.B * 0.168));
                    //int blue = Math.Min(255, (int)(pixel.R * 0.272 + pixel.G * 0.534 + pixel.B * 0.131));

                    _processed.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
            }
            pictureBox2.Image = _processed;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "untitled";
            saveFileDialog1.Filter = " Joint Photographic Experts Group (*.jpg)|*.jpeg|Portable Network Graphics (*.png)|*.png";
            saveFileDialog1.ShowDialog(); //shows the saveFileDialog
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            _processed.Save(saveFileDialog1.FileName);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
