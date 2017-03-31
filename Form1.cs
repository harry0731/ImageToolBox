using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToolBox
{
    public partial class Form1 : Form
    {
       public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "D:\\";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Bitmap old = new Bitmap(pictureBox1.Image);
            //Bitmap newone = old;
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            for(int i = 0; i < w;i++)
                for(int j = 0; j < h; j++)
                {
                   
                    int R = result.GetPixel(i, j).R;
                    int G = result.GetPixel(i, j).G;
                    int B = result.GetPixel(i, j).B;
                    double Gray = R * 0.3 + G * 0.59 + B * 0.11;

                    //double M = 256 * 50 * (Math.Log(1 + (Gray / 256)) / Math.Log(10));
                    

                    //if (M > 256) M = 255;
                   
                    newImage.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));
                    

                }
            pictureBox2.Image = newImage;
            
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            for(int i = 0; i < w;i++)
                for (int j = 0; j < h; j++)
                {

                    int R = result.GetPixel(i, j).R;
                    int G = result.GetPixel(i, j).G;
                    int B = result.GetPixel(i, j).B;
                    double Gray = R * 0.3 + G * 0.59 + B * 0.11;

                    newImage.SetPixel(i, j, Color.FromArgb((int)(255 - Gray), (int)(255 - Gray), (int)(255 - Gray)));
                }
            pictureBox2.Image = newImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            for(int i = 0; i < w;i++)
                for (int j = 0; j < h; j++)
                {

                    int R = result.GetPixel(i, j).R;
                    int G = result.GetPixel(i, j).G;
                    int B = result.GetPixel(i, j).B;
                    double Gray = R * 0.3 + G * 0.59 + B * 0.11;
                    double M = 256 * 50 * (Math.Log(1 + (Gray / 256)) / Math.Log(10));
                    if (M > 256) M = 255;
                    newImage.SetPixel(i, j, Color.FromArgb((int)M, (int)M, (int)M));
                }
            pictureBox2.Image = newImage;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            int[] count = new int[256];
            double[] p = new double[256];
            double[] o = new double[256];
            double[] z = new double[256];
            for (int u = 0; u < 256; u++)
                count[u] = 0;

                for (int i = 0; i < w; i++)
                    for (int j = 0; j < h; j++)
                    {

                        int R = result.GetPixel(i, j).R;
                        int G = result.GetPixel(i, j).G;
                        int B = result.GetPixel(i, j).B;
                        double Gray = R * 0.3 + G * 0.59 + B * 0.11;

                        newImage.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));

                        for (int r = 0; r < 256; r++)//累計
                        {
                            if ((int)Gray == r)
                                count[r] = count[r] + 1;
                        }

                    }
            int g = w * h;
            for(int x = 0; x < 256; x++)//機率
            {
                p[x] = count[x] / (g * 1.0);
            }
            for(int i = 0; i < 256; i++)//機率累加
            {
                for(int j = 0; j <= i; j ++)
                {
                    o[i] = o[i] + p[j];
                }
            }

            for(int i = 0; i < 256; i++)//機率*255
            {
                z[i] = o[i] * 255;
            }
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int R = newImage.GetPixel(i, j).R;
                    //int G = result.GetPixel(i, j).G;
                    //int B = result.GetPixel(i, j).B;
                    //double Gray = R * 0.3 + G * 0.59 + B * 0.11;

                    
                    for(int f = 0; f <256; f++)
                    {
                        if ((int)R == f)
                            newImage.SetPixel(i, j, Color.FromArgb((int)z[f], (int)z[f], (int)z[f]));
                    }

                }

            pictureBox2.Image = newImage;

    
     }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {

                    int R = result.GetPixel(i, j).R;
                    int G = result.GetPixel(i, j).G;
                    int B = result.GetPixel(i, j).B;
                    double Gray = R * 0.3 + G * 0.59 + B * 0.11;

                    newImage.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));
                    
                }
            for (int i = 1; i < w - 1; i++)
                for (int j = 1; j < h - 1; j++)
                {
                    double r = (result.GetPixel(i - 1, j - 1).R + result.GetPixel(i - 1, j).R + result.GetPixel(i, j - 1).R
                        + result.GetPixel(i, j).R + result.GetPixel(i + 1, j).R + result.GetPixel(i + 1, j - 1).R
                        + result.GetPixel(i, j + 1).R + result.GetPixel(i + 1, j + 1).R + result.GetPixel(i - 1, j+ 1).R) / 9.0;

                    newImage.SetPixel(i, j, Color.FromArgb((int)r, (int)r, (int)r));
                }

                    pictureBox2.Image = newImage;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {

                    int R = result.GetPixel(i, j).R;
                    int G = result.GetPixel(i, j).G;
                    int B = result.GetPixel(i, j).B;
                    double Gray = R * 0.3 + G * 0.59 + B * 0.11;

                    newImage.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));

                }
            for (int i = 1; i < w - 1; i++)
                for (int j = 1; j < h - 1; j++)
                {
                    double[] temp = new double[9];
                    double mid;

                    temp[0] = result.GetPixel(i, j).R;
                    temp[1] = result.GetPixel(i-1, j-1).R;
                    temp[2] = result.GetPixel(i-1, j).R;
                    temp[3] = result.GetPixel(i, j-1).R;
                    temp[4] = result.GetPixel(i+1, j).R;
                    temp[5] = result.GetPixel(i, j+1).R;
                    temp[6] = result.GetPixel(i+1, j+1).R;
                    temp[7] = result.GetPixel(i-1, j+1).R;
                    temp[8] = result.GetPixel(i+1, j-1).R;

                    for (int k = 1; k < 9; k++)
                        for (int m = 0; m < 8; m++)
                        {
                            if(temp[m] > temp[m + 1])
                            {
                                mid = temp[m];
                                temp[m] = temp[m + 1];
                                temp[m + 1] = mid;
                            }
                        }

                            newImage.SetPixel(i, j, Color.FromArgb((int)temp[4], (int)temp[4], (int)temp[4]));
                }

            pictureBox2.Image = newImage;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {

                    int R = result.GetPixel(i, j).R;
                    int G = result.GetPixel(i, j).G;
                    int B = result.GetPixel(i, j).B;
                    double Gray = R * 0.3 + G * 0.59 + B * 0.11;

                    newImage.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));
                }

            int mid = 127;
            double aaverage;
            double baverage;

            do
            {
                int a = 0;
                int b = 0;
                int temp;
                int count1 = 1;
                int count2 = 2;
                for (int i = 0; i < w; i++)
                    for (int j = 0; j < h; j++)
                    {
                        temp = result.GetPixel(i, j).R;
                        if (temp <= mid)
                        {
                            a = a + temp;
                            count1++;
                        }
                        else
                        {
                            b = b + temp;
                            count2++;
                        }
                    }
                aaverage = (double)a / (double)count1;
                baverage = (double)b / (double)count2;
                double g = (aaverage + baverage) / 2;

                if ((int)g < mid)
                    mid--;
                else if ((int)g > mid)
                    mid++;
                else break;
                Console.WriteLine(mid);

            } while ((int)aaverage != (int)baverage);

            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int R = result.GetPixel(i, j).R;
                    if (R <= mid)
                        R = 0;
                    else
                        R = 255;

                    newImage.SetPixel(i, j, Color.FromArgb((int)R, (int)R, (int)R));

                }

            pictureBox2.Image = newImage;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {

                    int R = result.GetPixel(i, j).R;
                    int G = result.GetPixel(i, j).G;
                    int B = result.GetPixel(i, j).B;

                    double Gray = R * 0.3 + G * 0.59 + B * 0.11;

                    double n = Math.Pow(2, ((int)numericUpDown1.Value)-1);

                    //string b = Convert.ToString((int)Gray, 2);
                    if ((((int)n & ((int)Gray)) == (int)n))
                        Gray = 255;
                    else
                        Gray = 0;

                    newImage.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));
                }
            pictureBox2.Image = newImage;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {

                    int R = result.GetPixel(i, j).R;
                    int G = result.GetPixel(i, j).G;
                    int B = result.GetPixel(i, j).B;
                    double Gray = R * 0.3 + G * 0.59 + B * 0.11;
                    double M = Math.Pow(Gray, 0.5);
                    if (M > 256) M = 255;
                    //M = 255 - M;
                    newImage.SetPixel(i, j, Color.FromArgb((int)M, (int)M, (int)M));
                }
            pictureBox2.Image = newImage;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {

                    int R = result.GetPixel(i, j).R;
                    int G = result.GetPixel(i, j).G;
                    int B = result.GetPixel(i, j).B;
                    double Gray = R * 0.3 + G * 0.59 + B * 0.11;

                    newImage.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));

                }
            for (int i = 1; i < w - 1; i++)
                for (int j = 1; j < h - 1; j++)
                {
                    double[] temp = new double[9];
                    double mid;

                    temp[0] = result.GetPixel(i, j).R;
                    temp[1] = result.GetPixel(i - 1, j - 1).R;
                    temp[2] = result.GetPixel(i - 1, j).R;
                    temp[3] = result.GetPixel(i, j - 1).R;
                    temp[4] = result.GetPixel(i + 1, j).R;
                    temp[5] = result.GetPixel(i, j + 1).R;
                    temp[6] = result.GetPixel(i + 1, j + 1).R;
                    temp[7] = result.GetPixel(i - 1, j + 1).R;
                    temp[8] = result.GetPixel(i + 1, j - 1).R;

                    mid = (temp[0] * 8) + (temp[1] * -1) + (temp[2] * -1) + (temp[3] * -1) + (temp[4] * -1) + (temp[5] * -1) + (temp[6] * -1) + (temp[7] * -1) + (temp[8] * -1);
                    if (mid > 255)
                        mid = 255;
                    if (mid < 0)
                        mid = 0;

                    newImage.SetPixel(i, j, Color.FromArgb((int)mid, (int)mid, (int)mid));
                }

            pictureBox2.Image = newImage;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {

                    int R = result.GetPixel(i, j).R;
                    int G = result.GetPixel(i, j).G;
                    int B = result.GetPixel(i, j).B;
                    double Gray = R * 0.3 + G * 0.59 + B * 0.11;

                    newImage.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));
                }

            int mid = 127;
            double aaverage;
            double baverage;

            do
            {
                int a = 0;
                int b = 0;
                int temp;
                int count1 = 1;
                int count2 = 2;
                for (int i = 0; i < w; i++)
                    for (int j = 0; j < h; j++)
                    {
                        temp = result.GetPixel(i, j).R;
                        if (temp <= mid)
                        {
                            a = a + temp;
                            count1++;
                        }
                        else
                        {
                            b = b + temp;
                            count2++;
                        }
                    }
                aaverage = a / (double)count1;
                baverage = b / (double)count2;
                double g = (aaverage + baverage) / 2;

                if ((int)g < mid)
                    mid--;
                else if ((int)g > mid)
                    mid++;
                else break;
                Console.WriteLine(mid);

            } while ((int)aaverage != (int)baverage);

            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int R = result.GetPixel(i, j).R;
                    if (R <= mid)
                        R = 0;
                    else
                        R = 255;

                    newImage.SetPixel(i, j, Color.FromArgb((int)R, (int)R, (int)R));
                                        
                }

            for (int i = 1; i < w - 1; i++)
                for (int j = 1; j < h - 1; j++)
                {
                    double[] temp = new double[9];
                    double t;

                    temp[0] = result.GetPixel(i, j).R;
                    temp[1] = result.GetPixel(i - 1, j - 1).R;
                    temp[2] = result.GetPixel(i - 1, j).R;
                    temp[3] = result.GetPixel(i, j - 1).R;
                    temp[4] = result.GetPixel(i + 1, j).R;
                    temp[5] = result.GetPixel(i, j + 1).R;
                    temp[6] = result.GetPixel(i + 1, j + 1).R;
                    temp[7] = result.GetPixel(i - 1, j + 1).R;
                    temp[8] = result.GetPixel(i + 1, j - 1).R;

                    if (temp[0] == 0 || temp[1] == 0 || temp[2] == 0 || temp[3] == 0 || temp[4] == 0 || temp[5] == 0 || temp[6] == 0 || temp[7] == 0 || temp[8] == 0)
                        t = 0;
                    else
                        t = 255;

                    newImage.SetPixel(i, j, Color.FromArgb((int)t, (int)t, (int)t));
                }

            pictureBox2.Image = newImage;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {

                    int R = result.GetPixel(i, j).R;
                    int G = result.GetPixel(i, j).G;
                    int B = result.GetPixel(i, j).B;
                    double Gray = R * 0.3 + G * 0.59 + B * 0.11;

                    newImage.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));
                }

            int mid = 127;
            double aaverage;
            double baverage;

            do
            {
                int a = 0;
                int b = 0;
                int temp;
                int count1 = 1;
                int count2 = 2;
                for (int i = 0; i < w; i++)
                    for (int j = 0; j < h; j++)
                    {
                        temp = result.GetPixel(i, j).R;
                        if (temp <= mid)
                        {
                            a = a + temp;
                            count1++;
                        }
                        else
                        {
                            b = b + temp;
                            count2++;
                        }
                    }
                aaverage = a / (double)count1;
                baverage = b / (double)count2;

                double g = (aaverage + baverage) / 2;

                if ((int)g < mid)
                    mid--;
                else if ((int)g > mid)
                    mid++;
                else break;
                Console.WriteLine(mid);

            } while ((int)aaverage != (int)baverage);

            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int R = result.GetPixel(i, j).R;
                    if (R <= mid)
                        R = 0;
                    else
                        R = 255;

                    newImage.SetPixel(i, j, Color.FromArgb((int)R, (int)R, (int)R));

                }

            for (int i = 1; i < w - 1; i++)
                for (int j = 1; j < h - 1; j++)
                {
                    double[] temp = new double[9];
                    double t;

                    temp[0] = result.GetPixel(i, j).R;
                    temp[1] = result.GetPixel(i - 1, j - 1).R;
                    temp[2] = result.GetPixel(i - 1, j).R;
                    temp[3] = result.GetPixel(i, j - 1).R;
                    temp[4] = result.GetPixel(i + 1, j).R;
                    temp[5] = result.GetPixel(i, j + 1).R;
                    temp[6] = result.GetPixel(i + 1, j + 1).R;
                    temp[7] = result.GetPixel(i - 1, j + 1).R;
                    temp[8] = result.GetPixel(i + 1, j - 1).R;

                    if (temp[0] == 255 || temp[1] == 255 || temp[2] == 255 || temp[3] == 255 || temp[4] == 255 || temp[5] == 255 || temp[6] == 255 || temp[7] == 255 || temp[8] == 255)
                        t = 255;
                    else
                        t = 0;

                    newImage.SetPixel(i, j, Color.FromArgb((int)t, (int)t, (int)t));
                }

            pictureBox2.Image = newImage;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);
            int w = pictureBox1.Image.Width;
            int h = pictureBox1.Image.Height;
            Bitmap newImage = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {

                    int R = result.GetPixel(i, j).R;
                    int G = result.GetPixel(i, j).G;
                    int B = result.GetPixel(i, j).B;
                    double Gray = R * 0.3 + G * 0.59 + B * 0.11;

                    newImage.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));

                }
            for (int i = 1; i < w - 1; i++)
                for (int j = 1; j < h - 1; j++)
                {
                    double[] temp = new double[9];
                    double mid1;
                    double mid2;
                    double mid3;

                    temp[0] = result.GetPixel(i, j).R;
                    temp[1] = result.GetPixel(i - 1, j - 1).R;
                    temp[2] = result.GetPixel(i - 1, j).R;
                    temp[3] = result.GetPixel(i, j - 1).R;
                    temp[4] = result.GetPixel(i + 1, j).R;
                    temp[5] = result.GetPixel(i, j + 1).R;
                    temp[6] = result.GetPixel(i + 1, j + 1).R;
                    temp[7] = result.GetPixel(i - 1, j + 1).R;
                    temp[8] = result.GetPixel(i + 1, j - 1).R;

                    mid1 = ((temp[1] * -1) + (temp[2] * -2) + (temp[4] * 2) + (temp[6] * 1) + (temp[7] * -1) + (temp[8] * 1));
                    
                    mid2 = ((temp[1] * -1) + (temp[3] * -2) + (temp[5] * 2) + (temp[6] * 1) + (temp[7] * 1) + (temp[8] * -1));
                    
                    mid3 = Math.Pow((mid1 * mid1 + mid2 * mid2), 0.5);

                    if (mid3 > 255)
                        mid3 = 255;
                    if (mid3 < 0)
                        mid3 = 0;
                    
                    newImage.SetPixel(i, j, Color.FromArgb((int)mid3, (int)mid3, (int)mid3));
                }

            pictureBox2.Image = newImage;
        }
    }
    }

