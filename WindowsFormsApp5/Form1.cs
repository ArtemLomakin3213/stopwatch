using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {

        DateTime date;
        public Form1()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToLongDateString();
            textBox2.Text = DateTime.Now.ToString("dddd");
            textBox3.Text = DateTime.Now.ToLongTimeString();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            date = DateTime.Now;
            timer2.Interval = 10;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();

            button2.Enabled = true;
            button2.BackColor = SystemColors.Window;
            button3.Enabled = true;
            button3.BackColor = SystemColors.Window;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - date.Ticks;
            DateTime stopWatch = new DateTime(tick);
            textBox4.Text = String.Format("{0:HH:mm:ss:ff}", stopWatch);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.Text == "Пауза")
            {
                timer2.Stop();
                button2.Text = "Продолжить";
            }
            else
            {
                timer2.Start();
                button2.Text = "Пауза";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            textBox4.Text = "00:00:00:00";
            button2.Enabled = false;
            button2.BackColor = Color.Gray;
            button3.Enabled = false;
            button3.BackColor = Color.Gray;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
