using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TriangleDrawer
{
    public partial class Form1 : Form
    {
        int l, r, t, b;
        int unit;
        int width1, height1;
        public Form1()
        {
            InitializeComponent();
            //pictureBox1.Width = Width;
            //pictureBox1.Height = Height;
            l = pictureBox1.Left;
            r = pictureBox1.Right;
            t = pictureBox1.Top;
            b = pictureBox1.Bottom;
            unit = 70;
            width1 = Convert.ToInt32(pictureBox1.Width / 2);
            height1 = Convert.ToInt32(pictureBox1.Height / 2);
            countpoint = 0;
        }
        
      
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red);
            p.Width = 3;
            Pen p1 = new Pen(Color.Black);
            p1.Width = 1;

            g.DrawLine(p, (l + r) / 2, t, (l + r) / 2, b);
            g.DrawString("0", new Font("Consolas", 12), Brushes.Black, new Point((l + r) / 2, (t + b) / 2));
            g.DrawLine(p, 1, (t + b) / 2, r, (t + b) / 2);
            int cnt=0;
            for (int i=(l+r)/2-unit;i>=l;i-=unit)
            {
                g.DrawLine(p1, i, t, i, b);
                cnt--;
                g.DrawString(cnt.ToString(), new Font("Consolas", 12), Brushes.Black, new Point(i, (t + b) / 2));
            }
            cnt = 0;

            for (int i = (l + r) / 2 + unit; i <=r; i += unit)
            {
                g.DrawLine(p1, i, t, i, b);
                cnt++;
                g.DrawString(cnt.ToString(), new Font("Consolas", 12), Brushes.Black, new Point(i, (t + b) / 2));
            }
            cnt = 0;

            for (int i = (t+b) / 2 - unit; i >=t; i -= unit)
            {
                g.DrawLine(p1, l, i, r, i);
                cnt++;
                g.DrawString(cnt.ToString(), new Font("Consolas", 12), Brushes.Black, new Point((l+r) / 2,i));
            }
            cnt = 0;
            for (int i = (t+b) / 2 + unit; i <= b; i += unit)
            {
                g.DrawLine(p1, l,i,r,i);
                cnt--;
                g.DrawString(cnt.ToString(), new Font("Consolas", 12), Brushes.Black, new Point((l+r) / 2,i));
            }
            cnt = 0;
        }

        int[] xcoordinate = new int[3];
        int[] ycoordinate = new int[3];
        int[] xcoorconvert = new int[3];
        int[] ycoorconvert = new int[3];
        int countpoint;
        int X, Y;
        Point oldpointtmp, currentpointtmp;

        private void UpdatePointsAndLine()
        {
            Pen RedPen = new Pen(Color.Blue, 4);
            Pen BlackPen = new Pen(Color.Black, 2);
            if (countpoint == 1)
            {
                xcoordinate[0] = xcoorconvert[0] * unit + width1;
                ycoordinate[0] = height1 - ycoorconvert[0] * unit;
                Rectangle rec1 = new Rectangle(xcoorconvert[0] * unit + width1 - 1, height1 - ycoorconvert[0] * unit - 1, 4, 4);
                pictureBox1.CreateGraphics().DrawEllipse(RedPen, rec1);
            }
            if (countpoint == 2)
            {
                xcoordinate[0] = xcoorconvert[0] * unit + width1;
                ycoordinate[0] = height1 - ycoorconvert[0] * unit;
                Rectangle rec1 = new Rectangle(xcoorconvert[0] * unit + width1 - 1, height1 - ycoorconvert[0] * unit - 1, 4, 4);
                pictureBox1.CreateGraphics().DrawEllipse(RedPen, rec1);
                xcoordinate[1] = xcoorconvert[1] * unit + width1;
                ycoordinate[1] = height1 - ycoorconvert[1] * unit;
                rec1 = new Rectangle(xcoorconvert[1] * unit + width1 - 1, height1 - ycoorconvert[1] * unit - 1, 4, 4);
                pictureBox1.CreateGraphics().DrawEllipse(RedPen, rec1);
                Point oldpoint = new Point(xcoordinate[0], ycoordinate[0]);
                Point currentpoint = new Point(xcoordinate[1], ycoordinate[1]);
                pictureBox1.CreateGraphics().DrawLine(BlackPen, oldpoint, currentpoint);
            }
            if (countpoint == 3)
            {
                xcoordinate[0] = xcoorconvert[0] * unit + width1;
                ycoordinate[0] = height1 - ycoorconvert[0] * unit;
                Rectangle rec1 = new Rectangle(xcoorconvert[0] * unit + width1 - 1, height1 - ycoorconvert[0] * unit - 1, 4, 4);
                pictureBox1.CreateGraphics().DrawEllipse(RedPen, rec1);
                xcoordinate[1] = xcoorconvert[1] * unit + width1;
                ycoordinate[1] = height1 - ycoorconvert[1] * unit;
                rec1 = new Rectangle(xcoorconvert[1] * unit + width1 - 1, height1 - ycoorconvert[1] * unit - 1, 4, 4);
                pictureBox1.CreateGraphics().DrawEllipse(RedPen, rec1);
                xcoordinate[2] = xcoorconvert[2] * unit + width1;
                ycoordinate[2] = height1 - ycoorconvert[2] * unit;
                rec1 = new Rectangle(xcoorconvert[2] * unit + width1 - 1, height1 - ycoorconvert[2] * unit - 1, 4, 4);
                pictureBox1.CreateGraphics().DrawEllipse(RedPen, rec1);
                Point oldpoint = new Point(xcoordinate[0], ycoordinate[0]);
                Point currentpoint = new Point(xcoordinate[1], ycoordinate[1]);
                pictureBox1.CreateGraphics().DrawLine(BlackPen, oldpoint, currentpoint);
                oldpoint = new Point(xcoordinate[1], ycoordinate[1]);
                currentpoint = new Point(xcoordinate[2], ycoordinate[2]);
                pictureBox1.CreateGraphics().DrawLine(BlackPen, oldpoint, currentpoint);
                oldpoint = new Point(xcoordinate[2], ycoordinate[2]);
                currentpoint = new Point(xcoordinate[0], ycoordinate[0]);
                pictureBox1.CreateGraphics().DrawLine(BlackPen, oldpoint, currentpoint);
            }
            switch (countpoint)
            {
                case 1:
                    pictureBox1.CreateGraphics().DrawString("A", new Font("Times New Roman", 12), Brushes.DarkBlue, new Point(xcoordinate[0] + 2, ycoordinate[0] + 2));
                    break;
                case 2:
                    pictureBox1.CreateGraphics().DrawString("A", new Font("Times New Roman", 12), Brushes.DarkBlue, new Point(xcoordinate[0] + 2, ycoordinate[0] + 2));
                    pictureBox1.CreateGraphics().DrawString("B", new Font("Times New Roman", 12), Brushes.DarkBlue, new Point(xcoordinate[1] + 2, ycoordinate[1] + 2));
                    break;
                case 3:
                    pictureBox1.CreateGraphics().DrawString("A", new Font("Times New Roman", 12), Brushes.DarkBlue, new Point(xcoordinate[0] + 2, ycoordinate[0] + 2));
                    pictureBox1.CreateGraphics().DrawString("B", new Font("Times New Roman", 12), Brushes.DarkBlue, new Point(xcoordinate[1] + 2, ycoordinate[1] + 2));
                    pictureBox1.CreateGraphics().DrawString("C", new Font("Times New Roman", 12), Brushes.DarkBlue, new Point(xcoordinate[2] + 2, ycoordinate[2] + 2));
                    break;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //pictureBox1.CreateGraphics().DrawLine(ErasePen, oldpointtmp, currentpointtmp);
            //pictureBox1.CreateGraphics().Clear(SystemColors.Control);
            if (countpoint != 3)
            {
                pictureBox1.Refresh();
                UpdatePointsAndLine();
                if (Math.Abs(Convert.ToInt32((e.X - width1)) % unit) <= unit / 2)
                {
                    X = Convert.ToInt32((e.X - width1) / unit);
                }
                else
                {
                    if (Convert.ToInt32((e.X - width1)) < 0)
                    {
                        X = Convert.ToInt32((e.X - width1) / unit) - 1;
                    }
                    else X = Convert.ToInt32((e.X - width1) / unit) + 1;
                }
                if (Math.Abs(Convert.ToInt32((height1 - e.Y)) % unit) <= unit / 2)
                {
                    Y = Convert.ToInt32((height1 - e.Y) / unit);
                }
                else
                {
                    if (Convert.ToInt32((height1 - e.Y)) < 0)
                    {
                        Y = Convert.ToInt32((height1 - e.Y) / unit) - 1;
                    }
                    else Y = Convert.ToInt32((height1 - e.Y) / unit) + 1;
                }
                Pen GrayPen = new Pen(Color.Gray, 2);
                Pen BrownPen = new Pen(Color.Brown, 4);
                currentpointtmp = new Point(X * unit + width1, height1 - Y * unit);
                Rectangle tmprec = new Rectangle(X * unit + width1 - 1, height1 - Y * unit -1, 4, 4);
                pictureBox1.CreateGraphics().DrawEllipse(BrownPen, tmprec);
                switch (countpoint)
                {
                    case 1:
                        oldpointtmp = new Point(xcoordinate[0], ycoordinate[0]);
                        pictureBox1.CreateGraphics().DrawLine(GrayPen, oldpointtmp, currentpointtmp);
                        break;
                    case 2:
                        oldpointtmp = new Point(xcoordinate[1], ycoordinate[1]);
                        pictureBox1.CreateGraphics().DrawLine(GrayPen, oldpointtmp, currentpointtmp);
                        break;
                }
            }        
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (countpoint == 3)
            {
                btn_reset.PerformClick();
            }
            if (countpoint <= 2)
            {
                if (Math.Abs(Convert.ToInt32((e.X - width1)) % unit) <= unit / 2)
                {
                    X = Convert.ToInt32((e.X - width1) / unit);
                }
                else
                {
                    if (Convert.ToInt32((e.X - width1)) < 0)
                    {
                        X = Convert.ToInt32((e.X - width1) / unit) - 1;
                    }
                    else X = Convert.ToInt32((e.X - width1) / unit) + 1;
                }
                if (Math.Abs(Convert.ToInt32((height1 - e.Y)) % unit) <= unit / 2)
                {
                    Y = Convert.ToInt32((height1 - e.Y) / unit);
                }
                else
                {
                    if (Convert.ToInt32((height1 - e.Y)) < 0)
                    {
                        Y = Convert.ToInt32((height1 - e.Y) / unit) - 1;
                    }
                    else Y = Convert.ToInt32((height1 - e.Y) / unit) + 1;
                }
                Pen RedPen = new Pen(Color.Blue, 4);
                Pen BlackPen = new Pen(Color.Black, 2);
                Rectangle rec1 = new Rectangle(X*unit+width1 - 1, height1 - Y*unit - 1, 4, 4);
                pictureBox1.CreateGraphics().DrawEllipse(RedPen, rec1);
                switch (countpoint)
                {
                    case 0:
                        pictureBox1.CreateGraphics().DrawString("A", new Font("Times New Roman", 12), Brushes.DarkBlue, new Point(X * unit + width1 + 4, height1 - Y * unit + 2));
                        break;
                    case 1:
                        pictureBox1.CreateGraphics().DrawString("B", new Font("Times New Roman", 12), Brushes.DarkBlue, new Point(X * unit + width1 + 4, height1 - Y * unit + 2));
                        break;
                    case 2:
                        pictureBox1.CreateGraphics().DrawString("C", new Font("Times New Roman", 12), Brushes.DarkBlue, new Point(X * unit + width1 + 4, height1 - Y * unit + 2));
                        break;
                }
                xcoordinate[countpoint] = X * unit + width1;
                ycoordinate[countpoint] = height1 - Y * unit;
                xcoorconvert[countpoint] = X;
                ycoorconvert[countpoint] = Y;
                if (countpoint==0)
                {
                    txt_x1.Text = Convert.ToString(X);
                    txt_y1.Text = Convert.ToString(Y);
                }
                if (countpoint == 1)
                {
                    Point oldpoint = new Point(xcoordinate[countpoint - 1], ycoordinate[countpoint - 1]);
                    Point currentpoint = new Point(xcoordinate[countpoint], ycoordinate[countpoint]);
                    pictureBox1.CreateGraphics().DrawLine(BlackPen, oldpoint, currentpoint);
                    txt_x2.Text = Convert.ToString(X);
                    txt_y2.Text = Convert.ToString(Y);
                }
                if (countpoint == 2)
                {
                    Point oldpoint = new Point(xcoordinate[0], ycoordinate[0]);
                    Point currentpoint = new Point(xcoordinate[2], ycoordinate[2]);
                    Point middlepoint = new Point(xcoordinate[1], ycoordinate[1]);
                    pictureBox1.CreateGraphics().DrawLine(BlackPen, middlepoint, currentpoint);
                    pictureBox1.CreateGraphics().DrawLine(BlackPen, currentpoint, oldpoint);
                    txt_x3.Text = Convert.ToString(X);
                    txt_y3.Text = Convert.ToString(Y);
                    Measure();
                }
                countpoint += 1;
            }
        }

        private void cmb_Size_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Size.Text == "50%")
                unit = 35;
            else if (cmb_Size.Text == "75%")
                unit = 53;
            else if (cmb_Size.Text == "25%")
                unit = 18;
            else if (cmb_Size.Text == "125%")
                unit = 88;
            else if (cmb_Size.Text == "175%")
                unit = 123;
            else if (cmb_Size.Text == "150%")
                unit = 105;
            else
                unit = 70;
            pictureBox1.Refresh();
            UpdatePointsAndLine();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            pictureBox1.CreateGraphics().Clear(SystemColors.Control);
            countpoint = 0;
            //unit = 70;
            pictureBox1.Refresh();
            //cmb_Size.Text = "100%";
            txt_area.Text = txt_perimeter.Text = txt_x1.Text = txt_x2.Text = txt_x3.Text = txt_y1.Text = txt_y2.Text = txt_y3.Text = "NA";
            label14.Text = "";
            isoceles = false;
            right = false;
        }

        bool isoceles=false, right=false;

        private void Measure()
        {
            double d1, d2, d3, p, S;
            int a = Convert.ToInt32(xcoorconvert[0]);
            int b = Convert.ToInt32(ycoorconvert[0]);
            int c = Convert.ToInt32(xcoorconvert[1]);
            int d = Convert.ToInt32(ycoorconvert[1]);
            int e = Convert.ToInt32(xcoorconvert[2]);
            int f = Convert.ToInt32(ycoorconvert[2]);
            int powerd1, powerd2, powerd3;
            d1 = Math.Sqrt((a - c) * (a - c) + (b - d) * (b - d));
            d2 = Math.Sqrt((a - e) * (a - e) + (b - f) * (b - f));
            d3 = Math.Sqrt((e - c) * (e - c) + (f - d) * (f - d));
            powerd1 = (a - c) * (a - c) + (b - d) * (b - d);
            powerd2 = (a - e) * (a - e) + (b - f) * (b - f);
            powerd3 = (e - c) * (e - c) + (f - d) * (f - d);
            p = (d1 + d2 + d3)/2;
            S = Math.Sqrt(p * (p - d1) * (p - d2) * (p - d3));
            txt_area.Text = Convert.ToString(Math.Round(S,2));
            txt_perimeter.Text = Convert.ToString(Math.Round(2*p, 2));
            if (d1 == d2 + d3 || d2 == d1 + d3 || d3 == d1 + d2) label14.Text = "Không phải tam giác";
            else
            {
                if (d1 == d2 && d2 == d3) label14.Text = "Tam giác đều";
                else if (d1 == d2 || d2 == d3 || d1 == d3)
                {
                    label14.Text = "Tam giác cân";
                    isoceles = true;
                    if ((powerd1 == powerd2 + powerd3) || (powerd2 == powerd1 + powerd3) || (powerd3 == powerd2 + powerd1))
                    {
                        label14.Text = "Tam giác vuông";
                        right = true;
                        if (isoceles == true && right == true) label14.Text = "Tam giác vuông cân";
                    }
                }
                else if ((powerd1 == powerd2 + powerd3) || (powerd2 == powerd1 + powerd3) || (powerd3 == powerd2 + powerd1))
                {
                    label14.Text = "Tam giác vuông";
                    right = true;
                    if (isoceles == true && right == true) label14.Text = "Tam giác vuông cân";
                }
                else if ((powerd1 > powerd2 + powerd3) || (powerd2 > powerd1 + powerd3) || (powerd3 > powerd2 + powerd1)) label14.Text = "Tam giác tù";
                else label14.Text = "Tam giác nhọn";
            }
        }

    }
}
