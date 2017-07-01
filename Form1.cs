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


namespace UIupdateFromThread
{
    public partial class Form1 : Form
    {
        public delegate void delUpdateUITextBox(string text);
        Thread myUpdateThread;
        //ThreadStart threadStart;
        string formloadthreadname;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.Name = "First Thread";
            formloadthreadname = Thread.CurrentThread.Name;
            //threadStart = new ThreadStart();
            myUpdateThread = new Thread(GetTheThreadStarted);
            //todo: Timer denemesi yapılabilir...
            //myTimer timer = new myTimer();
            myUpdateThread.Name = "Second Thread";
            myUpdateThread.Start();
        }
        private void GetTheThreadStarted()
        {
            delUpdateUITextBox DelUpdateUITextBox = new delUpdateUITextBox(UpdateUITextBox);
            this.textBox1.BeginInvoke(DelUpdateUITextBox, "I was updated from: " + myUpdateThread.Name + ", not " + formloadthreadname);
        }
        public void UpdateUITextBox(string textBoxString)
        {
            this.textBox1.Text = textBoxString;
            
        }
    }
}
