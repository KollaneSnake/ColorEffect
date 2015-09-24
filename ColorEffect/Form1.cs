using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ColorEffect
{
    public partial class Form1 : Form
    {
        
        Random rand = new Random();
        KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
        string[] colorArray = new string[10];
        string[] knownArray;
        int timerMode;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                string setColor="ColorBox"+i;

                
                Color randomColor = Color.FromKnownColor(names[rand.Next(names.Length)]);
                ((PictureBox)this.Controls[setColor]).BackColor =randomColor;
                colorArray[i] = Convert.ToString(randomColor);
            }

            knownArray = new string[names.Length];
            foreach (KnownColor number in names)
            {
                knownArray[(int)number-1] = Convert.ToString(names[(int)number-1]);
            }
               BoxColor.Items.AddRange(knownArray);

               textBox1.Text = Convert.ToString(timer1.Interval);

            button1.Enabled = true;
            button2.Enabled = true;
            
        }
        string selectedBox;
        private void BoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comb = sender as ComboBox;
            selectedBox = comb.Text;
            //selectedBox = ((ComboBox)sender).Text;
            int number = int.Parse(selectedBox[8].ToString());
            BoxColor.Text = colorArray[number];
            glowing.Enabled = true;
            
        }
        private void BoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((PictureBox)this.Controls[BoxName.Text]).BackColor = Color.FromName(((ComboBox)sender).Text);
        }
        string selectedRadio;
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            selectedRadio=((RadioButton)sender).Name;
            char choice=selectedRadio[11];
            if(choice=='1')
            {
                    timerMode = 1;
                    timerTick = 0;
                    timer1.Start();
            }
            else if(choice=='2')
            {
                    timerMode = 2;
                    timerTick = 0;
                    timer1.Start();
            }
            else if(choice=='3')
            {
                    timerMode = 3;
                    timerTick = 0;
                    timer1.Start();
            }
            else if(choice=='4')
            {
                    timerMode = 4;
                    timerTick = 0;
                    timer1.Start();
            }
            else if(choice=='5')
            {
                for (int i = 0; i < colorArray.Length;i++ )
                    {
                        ((PictureBox)this.Controls["ColorBox" + i]).BackColor = Color.FromName(getBetween(colorArray[i],"[","]"));
                    }
                    timerMode = 0;
                    timerTick = 0;
                    timer1.Stop();   
            }
        }
        int timerTick = 0;
        int colorTick = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerMode == 1) 
            {
                if(timerTick>9)
                {
                    timerTick = 0;
                    colorTick++;
                    if(colorTick>knownArray.Length-1)
                    {
                        colorTick = 1;
                    }
                }
                ((PictureBox)this.Controls["ColorBox" + timerTick]).BackColor = Color.FromName(knownArray[colorTick]);
                timerTick++;
                
            }
            else if(timerMode==2)
            {
                if (timerTick > 9)
                {
                    timerTick = 0;
                    colorTick++;
                    if (colorTick > knownArray.Length - 1)
                    {
                        colorTick = 1;
                    }
                }
                ((PictureBox)this.Controls["ColorBox" + (9 - timerTick)]).BackColor = Color.FromName(knownArray[colorTick]);
                timerTick++;
            }
            else if (timerMode == 3) 
            {
                if (timerTick > 2)//tocenter
                {
                    timerTick = 0;
                    colorTick++;
                    if (colorTick > knownArray.Length - 1)
                    {
                        colorTick = 1;
                    }
                }
                ((PictureBox)this.Controls["ColorBox" + (0 + timerTick)]).BackColor = Color.FromName(knownArray[colorTick]);

                ((PictureBox)this.Controls["ColorBox" + (4 - timerTick)]).BackColor = Color.FromName(knownArray[colorTick]);

                ((PictureBox)this.Controls["ColorBox" + (5 + timerTick)]).BackColor = Color.FromName(knownArray[colorTick]);

                ((PictureBox)this.Controls["ColorBox" + (9 - timerTick)]).BackColor = Color.FromName(knownArray[colorTick]);
                timerTick++;
            }
            else 
            {
                if (timerTick > 2)//fromcentre
                {
                    timerTick = 0;
                    colorTick++;
                    if (colorTick > knownArray.Length - 1)
                    {
                        colorTick = 1;
                    }
                }
                ((PictureBox)this.Controls["ColorBox" + (2 + timerTick)]).BackColor = Color.FromName(knownArray[colorTick]);

                ((PictureBox)this.Controls["ColorBox" + (2 - timerTick)]).BackColor = Color.FromName(knownArray[colorTick]);

                ((PictureBox)this.Controls["ColorBox" + (7 + timerTick)]).BackColor = Color.FromName(knownArray[colorTick]);

                ((PictureBox)this.Controls["ColorBox" + (7 - timerTick)]).BackColor = Color.FromName(knownArray[colorTick]);
                timerTick++;
            }
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        bool bBlinc=false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!bBlinc)
            {
                ((PictureBox)this.Controls[BoxName.Text]).Visible = false;
                bBlinc=true;
            }
            else
	        {
                ((PictureBox)this.Controls[BoxName.Text]).Visible = true;
                bBlinc=false;
	        }
            

            
        }
        bool bGolwing = false;
        private void glowing_Click(object sender, EventArgs e)
        {
            if (!bGolwing)
            {
                bGolwing = true;
                timer2.Start();
            }
            else
            {
                bGolwing = false;
                bBlinc = false;
                ((PictureBox)this.Controls[BoxName.Text]).Visible = true;
                timer2.Stop();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = int.Parse(textBox1.Text);
                timer2.Interval = int.Parse(textBox1.Text);
                timer3.Interval = int.Parse(textBox1.Text);

            }
            catch (Exception)
            {
            }
            
        }
        bool pair = false;
        bool notPair = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name=="button1"&&!pair)
            {
                pair = true;
                notPair = false;
                timer3.Start();                
            }
            else if (((Button)sender).Name == "button2"&&!notPair)
            {
                notPair = true;
                pair = false;
                timer3.Start();
            }
            else
            {
                pair = false;
                notPair = false;
                for (int i = 0; i < colorArray.Length; i++)
                {
                    ((PictureBox)this.Controls["ColorBox" + i]).Visible = true;
                }
                timer3.Stop();
            }
        }
        bool pairGlowing = false;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (pair&&!notPair&&!pairGlowing)
            {
                for (int i = 0; i < colorArray.Length; )
                {
                    ((PictureBox)this.Controls["ColorBox" + i]).Visible = false;
                    i += 2;
                }
                pairGlowing = true;
            }
            else if (!pair && notPair && !pairGlowing)
            {
                for (int i = 1; i < colorArray.Length; )
                {
                    ((PictureBox)this.Controls["ColorBox" + i]).Visible = false;
                    i += 2;
                }
                pairGlowing = true;
            }
            else
            {
                for (int i = 0; i < colorArray.Length; i++ )
                {
                    ((PictureBox)this.Controls["ColorBox" + i]).Visible = true;
                }
                pairGlowing = false;
            }
        }
    }
}
