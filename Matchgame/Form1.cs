using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Matchgame
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        List<String> icons = new List<string>()
        {
            "!","!","N","N",",",",","k","k","b","b","v","v","w","w",
            "z","z"
        };
        Label firstclick = null;
        Label secondclick = null;
        public Form1()
        {
            InitializeComponent();
            Fillsquare();
        }
        private void Fillsquare()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Label iconlabel)
                {
                    int randompos = rand.Next(icons.Count);
                    iconlabel.Text = icons[randompos];
                    iconlabel.ForeColor = iconlabel.BackColor;
                    icons.RemoveAt(randompos);
                }
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled==true)
            {
                return;
            }
            if(sender is Label)
            {
                Label clicklabel = sender as Label;
                if(clicklabel.ForeColor==Color.Black)
                {
                    return;
                }
                if(firstclick==null)
                {
                    firstclick = clicklabel;
                    firstclick.ForeColor = Color.Black;
                    return;
                }
                secondclick = clicklabel;
                secondclick.ForeColor = Color.Black;
                checkforwining();
                if(firstclick.Text==secondclick.Text)
                {
                    firstclick = null;
                    secondclick = null;
                    return;
                }
                timer1.Start();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstclick.ForeColor = firstclick.BackColor;
            secondclick.ForeColor = secondclick.BackColor;
            firstclick = null;
            secondclick = null;
        }
        private void checkforwining()
        {
            foreach (Control con in tableLayoutPanel1.Controls)
            {
                if(con is Label labletemp)
                {
                    if(labletemp.ForeColor==labletemp.BackColor)
                    {
                        return;
                    }

                }
            }
            MessageBox.Show("cogruluation .you win!!");
            Close();
            
        }
    }
}
