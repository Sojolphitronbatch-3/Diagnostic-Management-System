using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagnostic_Management_System
{
    public partial class Progressbarfrm : Form
    {
        public Progressbarfrm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ppanel.Width += 3;
            if (ppanel.Width >= panel1.Width)
            {
                timer1.Stop();
                Loginfrm lg = new Loginfrm();
                lg.Show();
                this.Hide();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
