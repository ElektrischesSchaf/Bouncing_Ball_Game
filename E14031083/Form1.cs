
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Media;

namespace E14031083
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        SoundPlayer player = new SoundPlayer("...\\...\\ping.wav");
        SoundPlayer end_sound = new SoundPlayer("...\\...\\endgame.wav");
        SoundPlayer start_sound = new SoundPlayer("...\\...\\startsound.wav");
        bool drag = false;
        int myscore = 0;
        int sx, sy;
        bool ifstart = false;
       const double speed1 = 20;
        const double speed2 = 40;
        const double speed3 = 60;
        int speedsaber = 40;
        double tempx;
        double tempy;
        int margin = 80;
        int margin2 = 0;
        double marginball = 120;
        double ball1x = (speed1) * Math.Cos(30);
        double ball1y = (speed1) * Math.Sin(30);
        double ball2x = (speed1+10) * Math.Cos(45);
        double ball2y = (speed1+10) * Math.Sin(45);
        double ball3x = (speed1+20) * Math.Cos(60);
        double ball3y = (speed1+20) * Math.Sin(60);

        public Form1()
        {
            InitializeComponent();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            ball1.Top = random.Next(90,250);
            ball1.Left = random.Next(300, 500);

            ball2.Top = random.Next(90, 200);
            ball2.Left = random.Next(600,900);

            ball3.Top = random.Next(300, 400);
            ball3.Left = random.Next(300, 900);
            
            this.KeyPreview = true;  // 表單接收所有按鍵事件
           this.FormBorderStyle = FormBorderStyle.Fixed3D;  // 表單大小固定
            timer1.Enabled = false;	   
            timer1.Interval = 100;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            ball2.Visible = false;
            timer1.Enabled = false;
            ball3.Visible = false;
            textbox_score.Text = myscore.ToString();
            startbutton.Text = "GO";
            myscore = 0;
            textbox_score.Text = myscore.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ball1.Right > this.Width - margin)
            {
                ball1x = -Math.Abs(ball1x);
            }
            if (ball1.Left < 0 + margin)
            {
                ball1x = Math.Abs(ball1x);
            }
            if (ball2.Right > this.Width - margin)
            {
                ball2x = -Math.Abs(ball2x);

            }
            if (ball2.Left < 0 + margin)
            {
                ball2x = Math.Abs(ball2x);
            }
            if (ball3.Right > this.Width - margin)
            {

                ball3x = -Math.Abs(ball3x);
            }
            if (ball3.Left < 0 + margin)
            {
                ball3x = Math.Abs(ball3x);
            }

            if (ball1.Top < margin)
            {
                ball1y = Math.Abs(ball1y);
            }
            if(ball1.Bottom > this.Height - margin)
            {
                ball1y = -Math.Abs(ball1y);
            }

            if (ball1.Bottom > this.Height - margin &&ball1.Visible==true)
            {
                ball1y = -Math.Abs(ball1y);
                end_sound.Play();
                timer1.Enabled = false;
                ifstart = false;
                MessageBox.Show("遊戲結束");
                Form1_Load(sender, e);
            }

            if (ball2.Top < margin)
            {
                ball2y = Math.Abs(ball2y);

            }

            if (ball2.Bottom > this.Height - margin)
            {
                ball2y = -Math.Abs(ball2y);
            }

            if (ball2.Bottom > this.Height - margin && ball2.Visible==true)
            {
                ball2y = -Math.Abs(ball2y);
                end_sound.Play();
                timer1.Enabled = false;
                ifstart = false;
                MessageBox.Show("遊戲結束");
                Form1_Load(sender, e);
            }
            if (ball3.Top < margin)
            {
                ball3y = Math.Abs(ball3y);
            }

            if (ball3.Bottom > this.Height - margin)
            {
                ball3y = -Math.Abs(ball3y);
            }

            if (ball3.Bottom > this.Height - margin && ball3.Visible == true)
            {
                ball3y = -Math.Abs(ball3y);
                end_sound.Play();
                timer1.Enabled = false;
                ifstart = false;
                MessageBox.Show("遊戲結束");
                Form1_Load(sender, e);
            }
            double ball1centerx = (ball1.Left + ball1.Right) / 2;
            double ball1centery = (ball1.Top + ball1.Bottom) / 2;
            double ball2centerx = (ball2.Left + ball2.Right) / 2;
            double ball2centery = (ball2.Top + ball2.Bottom) / 2;
            double ball3centerx = (ball3.Left + ball3.Right) / 2;
            double ball3centery = (ball3.Top + ball3.Bottom) / 2;
            double distance12 = Math.Pow((ball1centerx - ball2centerx) * (ball1centerx - ball2centerx) + (ball1centery - ball2centery) * (ball1centery - ball2centery), 0.5);
            double distance23 = Math.Pow((ball2centerx - ball3centerx) * (ball2centerx - ball3centerx) + (ball2centery - ball3centery) * (ball2centery - ball3centery), 0.5);
            double distance31 = Math.Pow((ball3centerx - ball1centerx) * (ball3centerx - ball1centerx) + (ball3centery - ball1centery) * (ball3centery - ball1centery), 0.5);
            if (ball2.Visible == true)
            {
                if (distance12 < marginball)
                {
                    tempx = ball1x;
                    tempy = ball1y;
                    ball1x = ball2x;
                    ball1y = ball2y;
                    ball2x = tempx;
                    ball2y = tempy;
                }
            }
            if (ball2.Visible == true && ball3.Visible == true)
            {
                if (distance23 < marginball)
                {

                    tempx = ball2x;
                    tempy = ball2y;
                    ball2x = ball3x;
                    ball2y = ball3y;
                    ball3x = tempx;
                    ball3y = tempy;
                }
            }
            if (ball3.Visible == true)
            {
                if (distance31 < marginball)
                {
                    tempx = ball3x;
                    tempy = ball3y;
                    ball3x = ball1x;
                    ball3y = ball1y;
                    ball1x = tempx;
                    ball1y = tempy;
                }
            }
            ball1.Left += Convert.ToInt32(ball1x);
            ball1.Top += Convert.ToInt32(ball1y);
            ball2.Left += Convert.ToInt32(ball2x);
            ball2.Top += Convert.ToInt32(ball2y);
            ball3.Left += Convert.ToInt32(ball3x);
            ball3.Top += Convert.ToInt32(ball3y);      
            if(ball1.Bottom>saber.Top +margin2 && ball1.Left>saber.Left && ball1.Right<saber.Right && ball1y>0 &&ball1.Visible==true)
            {
                ball1y = -Math.Abs(ball1y);
                myscore++;
                textbox_score.Text = myscore.ToString();
                   player.Play();           
            }
            if (ball2.Bottom > saber.Top+margin2 && ball2.Left > saber.Left && ball2.Right < saber.Right &&ball2y>0&&ball2.Visible==true)
            {
                ball2y = -Math.Abs(ball2y);
                myscore++;
                textbox_score.Text = myscore.ToString();
                  player.Play();
              
            }
            
            if (ball3.Bottom > saber.Top+margin2 && ball3.Left > saber.Left && ball3.Right < saber.Right &&ball3y>0 && ball3.Visible==true)
            {
                ball3y = -Math.Abs(ball3y);
                myscore++;
                textbox_score.Text = myscore.ToString();
                   player.Play();            
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)        // 根據e.KeyCode分別執行
            {
                case Keys.Left:        // 若按向左鍵
                    if (saber.Left > 0)
                    {
                        saber.Left -= speedsaber;  // 左移s點}
                    }
                    break;
                case Keys.Right:       // 若按向右鍵
                    if (saber.Right < this.Width)
                    {
                        saber.Left += speedsaber;  // 右移s點
                    }
                    break;
            }
        }

        private void mouse_down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)    // 若按左鍵時
            {
                drag = true;                 // 設為可拖曳
                sx = e.X; sy = e.Y;          // 記錄滑鼠指標的座標値
            }
        }
        private void slow_ckecked(object sender, EventArgs e)
        {
            ball1x = (speed1) * Math.Cos(30);
             ball1y = (speed1) * Math.Sin(30);
           ball2x = (speed1 + 10) * Math.Cos(45);
             ball2y = (speed1 + 10) * Math.Sin(45);
            ball3x = (speed1 + 20) * Math.Cos(60);
           ball3y = (speed1 + 20) * Math.Sin(60);
        }

        private void medium_checked(object sender, EventArgs e)
        {
            ball1x = (speed2) * Math.Cos(30);
            ball1y = (speed2) * Math.Sin(30);
            ball2x = (speed2 + 10) * Math.Cos(45);
            ball2y = (speed2 + 10) * Math.Sin(45);
           ball3x = (speed2 + 20) * Math.Cos(60);
            ball3y = (speed2 + 20) * Math.Sin(60);
        }

        private void fast_checked(object sender, EventArgs e)
        {
             ball1x = (speed3) * Math.Cos(30);
             ball1y = (speed3) * Math.Sin(30);
             ball2x = (speed3 + 10) * Math.Cos(45);
             ball2y = (speed3 + 10) * Math.Sin(45);
           ball3x = (speed3 + 20) * Math.Cos(60);
            ball3y = (speed3 + 20) * Math.Sin(60);
        }

        private void show_one_ball(object sender, EventArgs e)
        {
            ball1.Visible = true;
            ball2.Visible = false;
            ball3.Visible = false;
        }

        private void show_two_ball(object sender, EventArgs e)
        {
            ball1.Visible = true;
            ball2.Visible = true;
            ball3.Visible = false;
        }

        private void show_three_ball(object sender, EventArgs e)
        {
            ball1.Visible = true;
            ball2.Visible = true;
            ball3.Visible = true;
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            if(ifstart==false)
            {
                start_sound.Play();
                timer1.Enabled = true;
                startbutton.Text = "STOP";
                ifstart = true;
            }
            else
            {
                startbutton.Text = "GO";
                timer1.Enabled = false;
                ifstart = false;
            }
        }

        private void mouse_move(object sender, MouseEventArgs e)
        {
            if (drag)   //若drag=true
            {
                saber.Left += (e.X - sx);   // 設圖片X位置                                       
            }
        }
    }

}
