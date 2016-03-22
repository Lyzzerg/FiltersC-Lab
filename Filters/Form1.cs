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
using System.Drawing.Imaging;

namespace Filters
{
    public partial class Form1 : Form
    {
        Bitmap image, imageform;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int w, h;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files | *.png; *.jpg; *.bmp; | All Files (*.*)| *.*";
            if(dialog.ShowDialog()==DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                imageform = image;
            }
            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }

        private void filter1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
                image = ((Filters)e.Argument).processImage(image, backgroundWorker1);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Image = image;
            pictureBox1.Refresh();
            progressBar1.Value = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void razmitieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
      
        }

        private void gaussToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GreyScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sepia();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void stampingToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Filters filter = new Stamping();
                backgroundWorker1.RunWorkerAsync(filter);
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Brightness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void harshnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Harshness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void circuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Circuit();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Image Files | *.png; *.jpg; *.bmp; | All Files (*.*)| *.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
                image.Save(dialog.FileName, ImageFormat.Bmp);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Height = this.Height - 80;
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Wave1();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void wave2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Wave2();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void turnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Turn();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void moveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filters filter = new Move();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void greyWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GreyWorld(image);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void Form1_KeyPress(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
                if (e.KeyCode == Keys.Z)
                {
                    //pictureBox1.Image = imageform;
                    //pictureBox1.Refresh();
                    backgroundWorker1.CancelAsync();
                }
        }
    }
}
