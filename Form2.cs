using System;
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
    public partial class Form2 : Form
    {
        public Form1 frm1;
        public bool Playmap = false;
        public int bSize = 30;
        public static int mapSize = 10;
        public string razmetka = "ABCDEFGHIJ";
        public int boat = 20;
        public int[,] myMap = new int[10, 10];
        public int[,] botMap = new int[10, 10];
        public Button[,] myButton = new Button[10, 10];
        public Button[,] botButton = new Button[10, 10];
        public II ii;
        public Form2()
        {
            InitializeComponent();
            this.Text = "Морской бой";
            this.Width = 852;
            this.Height = 564;
            this.BackColor = Color.Aqua;
            this.Icon = new Icon("unnamed.ico");
            Init();
        }
        public void Init()
        {
            boat = 20;
            Playmap = false;
            CreatemyMap();
            CreatebotMap();
            ii = new II(botMap, myMap, botButton, myButton);
            botMap = ii.Rasstanovka();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void PlayClick(object sender, EventArgs e)
        {
            if (boat > 0)
            {
                MessageBox.Show("Сначала расставьте корабли!");
            }
            else
            {
                Playmap = true;
            }
        }
        private void ExetClick(object sender, EventArgs e)
        {
            this.Hide();
            frm1.Show();
            
        }

        private void RestartClick(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Init();
        }

        private void MyVistrel(object sender, EventArgs e)
        {
            if (Playmap)
            {
                Button Vb = sender as Button;
                bool Pshoot = Vistrel(botMap, Vb);
                if (!Pshoot)
                {
                    ii.Vistrel();
                }
                if (!Ostatki())
                {
                    this.Controls.Clear();
                    Init();
                }
            }
        }


        public void CreatemyMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    myMap[i, j] = 0;
                    Button button = new Button();
                    button.Location = new Point(30 + j * bSize, 30 + i * bSize);
                    button.Size = new Size(bSize, bSize);
                    button.Click += bt_Click;
                    button.BackColor = Color.White;
                    button.Text = "0";
                    this.Controls.Add(button);
                    if (j == 0 || i == 0)
                    {
                        if (i == 0)
                        {
                            Label sch1 = new Label();
                            sch1.Size = new Size(bSize - 5, bSize - 5);
                            sch1.Text = razmetka[j].ToString();
                            sch1.Location = new Point(30 + j * bSize + 5, bSize - 20);
                            this.Controls.Add(sch1);
                        }
                        if (j == 0)
                        {
                            Label sch1 = new Label();
                            sch1.Size = new Size(bSize, bSize);
                            sch1.Text = (i + 1).ToString();
                            sch1.Location = new Point(j * bSize, 30 + i * bSize + 5);
                            this.Controls.Add(sch1);
                        }
                    }
                    myButton[i, j] = button;

                    Label myM = new Label();
                    myM.Text = "Моя карта";
                    myM.Location = new Point(mapSize * bSize / 2, mapSize * bSize + 30);
                    this.Controls.Add(myM);
                }
            }

            Button Play = new Button();
            Play.Location = new Point(340 + bSize, 70 + bSize);
            Play.Text = "Play";
            Play.BackColor = Color.Blue;
            Play.Click += PlayClick;
            this.Controls.Add(Play);
        }
        public void CreatebotMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    botMap[i, j] = 0;
                    Button button = new Button();
                    button.Location = new Point(500 + j * bSize, 30 + i * bSize);
                    button.Size = new Size(bSize, bSize);
                    button.BackColor = Color.White;
                    button.Click += MyVistrel;
                    this.Controls.Add(button);
                    if (j == 0 || i == 0)
                    {
                        if (i == 0)
                        {
                            Label sch1 = new Label();
                            sch1.Size = new Size(bSize - 5, bSize - 5);
                            sch1.Text = razmetka[j].ToString();
                            sch1.Location = new Point(470 + 30 + j * bSize + 5, bSize - 20);
                            this.Controls.Add(sch1);
                        }
                        if (j == 0)
                        {
                            Label sch1 = new Label();
                            sch1.Size = new Size(bSize, bSize);
                            sch1.Text = (i + 1).ToString();
                            sch1.Location = new Point(470 + j * bSize, 30 + i * bSize + 5);
                            this.Controls.Add(sch1);
                        }
                    }
                    botButton[i, j] = button;

                    Label botM = new Label();
                    botM.Text = "Карта бота";
                    botM.Location = new Point(470 + mapSize * bSize / 2, mapSize * bSize + 30);
                    this.Controls.Add(botM);
                }
            }

            Button Exet = new Button();
            Exet.Location = new Point(10, 470 + bSize);
            Exet.Text = "Exit";
            Exet.BackColor = Color.Blue;
            Exet.Click += ExetClick;
            this.Controls.Add(Exet);

            Button Restart = new Button();
            Restart.Location = new Point(750, 470 + bSize);
            Restart.Text = "Restart";
            Restart.BackColor = Color.Blue;
            Restart.Click += RestartClick;
            this.Controls.Add(Restart);
        }

        public void bt_Click(object sender, EventArgs e)
        {
            Button Tb = sender as Button;
            if (!Playmap)
            {
                if (boat > 0)
                {
                    if (myMap[(Tb.Location.Y - 30) / bSize, (Tb.Location.X - 30) / bSize] == 0)
                    {
                        Tb.Text = "1";
                        Tb.BackColor = Color.Blue;
                        myMap[(Tb.Location.Y - 30) / bSize, (Tb.Location.X - 30) / bSize] = 1;
                        boat = boat - 1;
                        //Tb.Text = $"{(Tb.Location.X-30) / bSize}";
                    }
                    else
                    {
                        Tb.BackColor = Color.White;
                        myMap[(Tb.Location.Y - 30) / bSize, (Tb.Location.X - 30) / bSize] = 0;
                        boat = boat + 1;
                        Tb.Text = "0";
                    }
                }
            }
        }
        public bool Vistrel(int[,] map, Button Tb)
        {
            bool probitie = false;
            if (Playmap)
            {
                if (Tb.BackColor == Color.White || Tb.BackColor == Color.Brown)
                {
                    if (map[(Tb.Location.Y - 30) / bSize, (Tb.Location.X - 500) / bSize] != 0 && map[(Tb.Location.Y - 30) / bSize, (Tb.Location.X - 500) / bSize] != 3)
                    {
                        probitie = true;
                        map[(Tb.Location.Y - 30) / bSize, (Tb.Location.X - 500) / bSize] = 0;
                        Tb.BackColor = Color.Red;
                        //Tb.Text = $"{(Tb.Location.X-500)/bSize}";
                    }
                    else
                    {
                        probitie = false;
                        Tb.BackColor = Color.Green;
                    }
                }
                else
                {
                    probitie = true;
                }
            }
            return probitie;
        }
        public bool Ostatki()
        {
            bool Iwin = true;
            bool iiwin = true;
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (myMap[i, j] != 0)
                        iiwin = false;
                    if (botMap[i, j] != 0 && botMap[i, j] != 3)
                        Iwin = false;
                }
            }
            if (Iwin || iiwin)
            {
                if (Iwin)
                {
                    MessageBox.Show("Вы выиграли!");
                }
                else
                {
                    MessageBox.Show("Вы проиграли!");
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
