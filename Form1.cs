﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS_OOP_1204041
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.MdiParent = this;
            f.Show();
        }

        private void mahasiswaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new Form3();
            f.MdiParent = this;
            f.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void prodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form4();
            f.MdiParent = this;
            f.Show();
        }

        private void prodiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new Form5();
            f.MdiParent = this;
            f.Show();
        }

      }
}
