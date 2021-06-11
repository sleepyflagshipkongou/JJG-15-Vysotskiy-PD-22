using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
            ButtonsField bf = new ButtonsField(textBox2);
            bf.drawField(tabPage2);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text == ""))
            {
                comboBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items.RemoveAt(comboBox1.Items.Count - 1);
            }
            catch
            {
                MessageBox.Show("И что мне удалять?", "Лист пуст!!!");
            }
        }
    }

    class ButtonsField
    {
        #region Fields
        private List<Button> Buttons = new List<Button>();
        private sbyte amountButtons = 16;
        private sbyte count = 0;
        private object textBoxForResult;
        #endregion
        public ButtonsField(object textBoxForResult)
        {
            sbyte yLocation = 28;

            for (int i = 0; i < amountButtons; i++)
            {
                Buttons.Add(new Button());

                Buttons[i].Text = (i + 1).ToString();
                Buttons[i].TabStop = false;
                Buttons[i].Size = new Size(30, 20);
                Buttons[i].Location = new Point(75 * ((i % 4) + 1), yLocation);

                Buttons[i].Click += new EventHandler(btn_handler);

                if ((i + 1) % 4 == 0)
                {
                    yLocation += 30;
                }
            }

            this.textBoxForResult = (textBoxForResult);
        }

        public void drawField(object getter)
        {
            shuffleButtons();
            for (int i = 0; i < amountButtons; i++)
                (getter as TabPage).Controls.Add(Buttons[i]);
        }
        public void shuffleButtons()
        {
            Random rand = new Random();

            for (int i = 0; i < amountButtons; i++)
            {
                int j = rand.Next(i);

                Point tmp = Buttons[j].Location;
                Buttons[j].Location = Buttons[i].Location;
                Buttons[i].Location = tmp;

            }
        }

        private void resetHidingButtons ()
        {
            shuffleButtons();
            for (int i = 0; i < amountButtons; i++)
                if (!Buttons[i].Visible)
                    Buttons[i].Show();

            count = 0;
        }

        private void btn_handler(object sender, EventArgs e)
        {
            if (count == (amountButtons - 1))
            {
                (textBoxForResult as TextBox).Text = "Молодец!!!";
                resetHidingButtons();
            }
            else
            {
                (textBoxForResult as TextBox).Text = "";
            }

            if ((sender as Button).Text == (count + 1).ToString())
            {
                shuffleButtons();
                (sender as Button).Hide();
                count++;
            }
            else
            {
                resetHidingButtons();
            }
        }
    }
}
