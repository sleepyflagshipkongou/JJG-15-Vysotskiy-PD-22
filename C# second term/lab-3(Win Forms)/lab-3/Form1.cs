using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_3
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        private int counter = 0;
        private bool buttonMinimiz = false;

        public Form1()
        {
            InitializeComponent();
            Controls.SetChildIndex(button1, 0);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ты меня поймал!!!", "Хитрец");
        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Location = new Point(rand.Next(this.Width / 2), rand.Next(this.Height / 2));
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y >= button1.Location.Y && e.Y <= button1.Location.Y + button1.Height)
            {
                if ((e.X >= button1.Location.X - button1.Width && e.X <= button1.Location.X))
                {
                    button1.Location = new Point(button1.Location.X + 1, button1.Location.Y);
                    buttonMinimiz = true;
                }
                if ((e.X <= button1.Location.X + button1.Width * 2 && e.X >= button1.Location.X))
                {
                    button1.Location = new Point(button1.Location.X - 1, button1.Location.Y);
                    buttonMinimiz = true;
                }
            }
            else
            {
                buttonMinimiz = false;
            }

            if (e.X >= button1.Location.X && e.X <= button1.Location.X + button1.Width)
            {
                if ((e.Y >= button1.Location.Y - button1.Height && e.Y <= button1.Location.Y))
                {
                    button1.Location = new Point(button1.Location.X, button1.Location.Y + 1);
                    buttonMinimiz = true;
                }
                if ((e.Y <= button1.Location.Y + button1.Height * 2 && e.Y >= button1.Location.Y))
                {
                    button1.Location = new Point(button1.Location.X, button1.Location.Y - 1);
                    buttonMinimiz = true;
                }
            }
            else
            {
                buttonMinimiz = false;
            }

            if (e.X >= button1.Location.X - button1.Width && e.X <= button1.Location.X)
            {
                if (e.Y >= button1.Location.Y - button1.Height && e.Y <= button1.Location.Y)
                {
                    button1.Location = new Point(button1.Location.X + 1, button1.Location.Y + 1);
                    buttonMinimiz = true;
                }
                if (e.Y <= button1.Location.Y + button1.Height * 2 && e.Y >= button1.Location.Y)
                {
                    button1.Location = new Point(button1.Location.X + 1, button1.Location.Y - 1);
                    buttonMinimiz = true;
                }
            }
            else
            {
                buttonMinimiz = false;
            }
            if (e.X <= button1.Location.X + button1.Width * 2 && e.X >= button1.Location.X)
            {
                if (e.Y >= button1.Location.Y - button1.Height && e.Y <= button1.Location.Y)
                {
                    button1.Location = new Point(button1.Location.X - 1, button1.Location.Y + 1);
                    buttonMinimiz = true;
                }
                if (e.Y <= button1.Location.Y + button1.Height * 2 && e.Y >= button1.Location.Y)
                {
                    button1.Location = new Point(button1.Location.X - 1, button1.Location.Y - 1);
                    buttonMinimiz = true;
                }
            }
            else
            {
                buttonMinimiz = false;
            }

            if ((button1.Location.X + button1.Width >= this.Width) 
                || (button1.Location.X <= 0) 
                || (button1.Location.Y <= 0)
                || (button1.Location.Y + button1.Height*2.5 >= this.Height))
            {
                button1.Location = new Point(rand.Next(this.Width / 2), rand.Next(this.Height / 2));
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (counter % 2 != 0 && counter <= 16)
                this.Text = "Нажмите кнопку \"Ок\"!!!";
            else
                this.Text = "";

            if(button1.Height == 0)
            {
                if (counter % 2 != 0)
                    this.Text = "Кнопка \"Ок\" не может быть нажата";
                else
                    this.Text = "";
            }

            counter++;
        }
        private void TimerForButton_Tick(object sender, EventArgs e)
        {
            if(buttonMinimiz)
                button1.Height -= 1;
            if (button1.Height <= 5)
                button1.Height = 0;
        }
    }
}
