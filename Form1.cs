﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morskoi_Boi_v._04
{
    public partial class Form1 : Form
    {
        public Form2 frm2;
        public Help frm3;
        public Image boat;
        public Image booms;
        public Timer tim = new Timer();
        private EventHandler boom;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Морской бой";
            this.Width = 400;
            this.Height = 600;
            this.BackColor = Color.Aqua;
            this.Icon = new Icon("unnamed.ico");
            this.Paint += Ship;
            this.Paint += Seabattle;
            this.Paint += Boom;

            Init();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Init()
        {
            CreatemyMemu();
            tim.Interval = 5000;
            tim.Enabled = true;
            tim.Tick += boom;
        }

        private void Play_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            frm2.frm1 = this;
            this.Hide();
            frm2.Show();


        }
        private void Help_Click(object sender, EventArgs e)
        {
            frm3 = new Help();
            frm3.frm1 = this;
            this.Hide();
            frm3.Show();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void CreatemyMemu()
        {
            Button buttonM = new Button();
            buttonM.Location = new Point(120, 150);
            buttonM.Size = new Size(150, 60);
            buttonM.Font = new Font("Arial", 20, FontStyle.Regular);
            buttonM.Text = "Play";
            buttonM.Click += Play_Click;
            buttonM.BackColor = Color.Blue;
            this.Controls.Add(buttonM);

            Button buttonH = new Button();
            buttonH.Location = new Point(120, 260);
            buttonH.Size = new Size(150, 60);
            buttonH.Font = new Font("Arial", 20, FontStyle.Regular);
            buttonH.Text = "Help";
            buttonH.Click += Help_Click;
            buttonH.BackColor = Color.Blue;
            this.Controls.Add(buttonH);

            Button buttonE = new Button();
            buttonE.Location = new Point(120, 370);
            buttonE.Size = new Size(150, 60);
            buttonE.Font = new Font("Arial", 20, FontStyle.Regular);
            buttonE.Text = "Exit";
            buttonE.Click += Exit_Click;
            buttonE.BackColor = Color.Blue;
            this.Controls.Add(buttonE);

        }
        public void Ship(object sender, PaintEventArgs e)
        {
            boat = new Bitmap("menuboat.png");
            e.Graphics.DrawImage(boat, 0, 420, 330, 130);
        }
        public void Boom(object sender, PaintEventArgs e)
        {
            Random rnd = new Random();
            int Explosions = 8;
            booms = new Bitmap("booms.png");
            while (Explosions > 0)
            {
                int x = rnd.Next(0, 350);
                int y = rnd.Next(0, 500);
                int h = 40;
                int w = 40;
                e.Graphics.DrawImage(booms, x, y, h, w);
                Explosions--;
            }

        }

        public void Seabattle(object sender, PaintEventArgs e)
        {
            boat = new Bitmap("Seabattle.png");
            e.Graphics.DrawImage(boat, 95, -30, 200, 260);
        }

    }
}

