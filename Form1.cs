using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Oduncu_vs_GerginGorunusluAdam
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        Savasci oduncu = new Savasci();
        Savasci GerginGorunusluAdam = new Savasci();

        int oduncu_x = 12;
        int gerginGorunusluAdam_x = 659;

        public Form1()
        {
            InitializeComponent();
        }
        public void SavasBaslar()
        {
            while (oduncu.Can>0 && GerginGorunusluAdam.Can>0)
            {
                Random rnd = new Random();
                bool siraOduncununMu = Convert.ToBoolean(rnd.Next(0, 2));

                if (siraOduncununMu) //oduncu başlar
                {
                    GerginGorunusluAdam.HasarYemek(oduncu.Hasar);
                    label5.Text = ($"Can: {GerginGorunusluAdam.Can}");
                    label5.Update();
                    Thread.Sleep(200);
                }
                else  //gergin görünüşlü adam başlar
                {
                    oduncu.HasarYemek(GerginGorunusluAdam.Hasar);
                    label2.Text = ($"Can: {oduncu.Can}");
                    label2.Update();
                    Thread.Sleep(200);
                }
            }
            label2.Text = ($"Can: {oduncu.Can}");
            label2.Update();
            label5.Text = ($"Can: {GerginGorunusluAdam.Can}");
            label5.Update();
            Thread.Sleep(200);
            KazananKim();

        }

        public void KazananKim()
        {
            if (oduncu.Can == 0)
            {
                MessageBox.Show("Kazanan Gergin Görünüşlü Adam!");
            }
            else if(GerginGorunusluAdam.Can==0)
            {
                MessageBox.Show("Kazanan Oduncu");
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = ($"Hız: {oduncu.Hiz}");
            label2.Text = ($"Can: {oduncu.Can}");  // oduncunun istatistikleri
            label3.Text = ($"Hasar: {oduncu.Hasar}");

            label4.Text = ($"Hız: {GerginGorunusluAdam.Hiz}");
            label5.Text = ($"Can: {GerginGorunusluAdam.Can}");  // Gergin Görünüşlü adamın istatistikleri
            label6.Text = ($"Hasar: {GerginGorunusluAdam.Hasar}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            oduncu_x += oduncu.Hiz;
            pictureBox1.Location = new Point(oduncu_x ,pictureBox1.Location.Y);
            if (pictureBox1.Right == pictureBox2.Left || pictureBox1.Right + 5 >= pictureBox2.Left)
            {
                timer1.Stop();
                timer2.Stop();
                SavasBaslar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            gerginGorunusluAdam_x -= GerginGorunusluAdam.Hiz;
            pictureBox2.Location = new Point(gerginGorunusluAdam_x, pictureBox2.Location.Y);
            if (pictureBox2.Left == pictureBox1.Right || pictureBox2.Left - 5 <= pictureBox1.Right)
            {
                timer1.Stop();
                timer2.Stop();
                SavasBaslar();
            }

        }
    }
}
