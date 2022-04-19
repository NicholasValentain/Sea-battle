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
    public class II
    {
        public int[,] myMap = new int[10, 10];
        public int[,] botMap = new int[10, 10];
        public Button[,] myButton = new Button[10, 10];
        public Button[,] botButton = new Button[10, 10];
        public int nap;
        public Random rnd = new Random();

        public II(int[,] myMap, int[,] botMap, Button[,] myButton, Button[,] botButton)
        {
            this.myMap = myMap;
            this.botMap = botMap;
            this.myButton = myButton;
            this.botButton = botButton;
        }

        public bool VihodZaMap(int i, int j, int nap)
        {
            if (nap == 1)
            {
                if (i < 0 || j < 0 || i >= Form2.mapSize || j >= Form2.mapSize)
                {
                    return false;
                }
            }
            else
            {
                if (i < 0 || j < 0 || i >= Form2.mapSize || j >= Form2.mapSize)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Sozdannie(int i, int j, int length, int nap)
        {
            bool isEmpty = true;

            if (nap == 1)
            {
                for (int k = j; k < j + length; k++)
                {
                    if (myMap[i, k] != 0)
                    {
                        isEmpty = false;
                        break;
                    }
                }
            }
            else
            {
                for (int k = i; k < i + length; k++)
                {
                    if (myMap[k, j] != 0)
                    {
                        isEmpty = false;
                        break;
                    }
                }
            }

            return isEmpty;
        }

        public int[,] Rasstanovka()
        {
            int DlinaK = 4;
            int shtuk = 4;
            int Lodki = 10;
            int nap;
            Random rnd = new Random();
            int x;
            int y;
            while (Lodki > 0)
            {
                nap = rnd.Next(1, 3);
                if (nap == 1)
                {
                    for (int i = 0; i < shtuk / 4; i++)
                    {
                        x = rnd.Next(0, Form2.mapSize);
                        y = rnd.Next(0, Form2.mapSize);
                        while (!VihodZaMap(x, y + DlinaK - 1, nap) || !Sozdannie(x, y, DlinaK, nap))
                        {
                            x = rnd.Next(0, Form2.mapSize);
                            y = rnd.Next(0, Form2.mapSize);
                        }
                        for (int k = y; k < y + DlinaK; k++)
                        {
                            myMap[x, k] = 1;
                            myButton[x, k].BackColor = Color.White;
                            myButton[x, k].Text = $"{nap}";

                            if (DlinaK == 1)
                            {
                                if (x - 1 >= 0 && k - 1 >= 0 && x - 1 <= 9 && k - 1 <= 9)
                                {
                                    myMap[x - 1, k - 1] = 3;
                                    myButton[x - 1, k - 1].BackColor = Color.Brown;
                                }
                                if (x >= 0 && k - 1 >= 0 && x <= 9 && k - 1 <= 9)
                                {
                                    myMap[x, k - 1] = 3;
                                    myButton[x, k - 1].BackColor = Color.Brown;
                                }
                                if (x + 1 >= 0 && k - 1 >= 0 && x + 1 <= 9 && k - 1 <= 9)
                                {
                                    myMap[x + 1, k - 1] = 3;
                                    myButton[x + 1, k - 1].BackColor = Color.Brown;
                                }
                                if (x - 1 >= 0 && k >= 0 && x - 1 <= 9 && k <= 9)
                                {
                                    myMap[x - 1, k] = 3;
                                    myButton[x - 1, k].BackColor = Color.Brown;
                                }
                                if (x + 1 >= 0 && k >= 0 && x + 1 <= 9 && k <= 9)
                                {
                                    myMap[x + 1, k] = 3;
                                    myButton[x + 1, k].BackColor = Color.Brown;
                                }
                                if (x - 1 >= 0 && k + 1 >= 0 && x - 1 <= 9 && k + 1 <= 9)
                                {
                                    myMap[x - 1, k + 1] = 3;
                                    myButton[x - 1, k + 1].BackColor = Color.Brown;
                                }
                                if (x >= 0 && k + 1 >= 0 && x <= 9 && k + 1 <= 9)
                                {
                                    myMap[x, k + 1] = 3;
                                    myButton[x, k + 1].BackColor = Color.Brown;
                                }
                                if (x + 1 >= 0 && k + 1 >= 0 && x + 1 <= 9 && k + 1 <= 9)
                                {
                                    myMap[x + 1, k + 1] = 3;
                                    myButton[x + 1, k + 1].BackColor = Color.Brown;
                                }
                            }
                            else
                            {
                                if (k == y)
                                {

                                    if (x - 1 >= 0 && k - 1 >= 0 && x - 1 <= 9 && k - 1 <= 9)
                                    {
                                        myMap[x - 1, k - 1] = 3;
                                        myButton[x - 1, k - 1].BackColor = Color.Brown;
                                    }
                                    if (x >= 0 && k - 1 >= 0 && x <= 9 && k - 1 <= 9)
                                    {
                                        myMap[x, k - 1] = 3;
                                        myButton[x, k - 1].BackColor = Color.Brown;
                                    }
                                    if (x + 1 >= 0 && k - 1 >= 0 && x + 1 <= 9 && k - 1 <= 9)
                                    {
                                        myMap[x + 1, k - 1] = 3;
                                        myButton[x + 1, k - 1].BackColor = Color.Brown;
                                    }
                                }

                                if (k == y + DlinaK - 1)
                                {
                                    if (x - 1 >= 0 && k + 1 >= 0 && x - 1 <= 9 && k + 1 <= 9)
                                    {
                                        myMap[x - 1, k + 1] = 3;
                                        myButton[x - 1, k + 1].BackColor = Color.Brown;
                                    }
                                    if (x >= 0 && k + 1 >= 0 && x <= 9 && k + 1 <= 9)
                                    {
                                        myMap[x, k + 1] = 3;
                                        myButton[x, k + 1].BackColor = Color.Brown;
                                    }
                                    if (x + 1 >= 0 && k + 1 >= 0 && x + 1 <= 9 && k + 1 <= 9)
                                    {
                                        myMap[x + 1, k + 1] = 3;
                                        myButton[x + 1, k + 1].BackColor = Color.Brown;
                                    }
                                }

                                if (k >= y && k <= y + DlinaK - 1)
                                {
                                    if (x - 1 >= 0 && k >= 0 && x - 1 <= 9 && k <= 9)
                                    {
                                        myMap[x - 1, k] = 3;
                                        myButton[x - 1, k].BackColor = Color.Brown;
                                    }
                                    if (x + 1 >= 0 && k >= 0 && x + 1 <= 9 && k <= 9)
                                    {
                                        myMap[x + 1, k] = 3;
                                        myButton[x + 1, k].BackColor = Color.Brown;
                                    }
                                }
                            }
                        }
                        Lodki--;
                        if (Lodki <= 0)
                        {
                            break;
                        }
                    }
                    shtuk += 4;
                    DlinaK--;
                    nap = rnd.Next(1, 2);
                }
                else
                {
                    for (int i = 0; i < shtuk / 4; i++)
                    {
                        x = rnd.Next(0, Form2.mapSize);
                        y = rnd.Next(0, Form2.mapSize);
                        while (!VihodZaMap(x + DlinaK - 1, y, nap) || !Sozdannie(x, y, DlinaK, nap))
                        {
                            x = rnd.Next(0, Form2.mapSize);
                            y = rnd.Next(0, Form2.mapSize);
                        }
                        for (int k = x; k < x + DlinaK; k++)
                        {
                            myMap[k, y] = 1;
                            myButton[k, y].BackColor = Color.White;
                            myButton[k, y].Text = $"{nap}";

                            if (DlinaK == 1)
                            {
                                if (k - 1 >= 0 && y - 1 >= 0 && k - 1 <= 9 && y - 1 <= 9)
                                {
                                    myMap[k - 1, y - 1] = 3;
                                    myButton[k - 1, y - 1].BackColor = Color.Brown;
                                }
                                if (k >= 0 && y - 1 >= 0 && k <= 9 && y - 1 <= 9)
                                {
                                    myMap[k, y - 1] = 3;
                                    myButton[k, y - 1].BackColor = Color.Brown;
                                }
                                if (k + 1 >= 0 && y - 1 >= 0 && k + 1 <= 9 && y - 1 <= 9)
                                {
                                    myMap[k + 1, y - 1] = 3;
                                    myButton[k + 1, y - 1].BackColor = Color.Brown;
                                }
                                if (k - 1 >= 0 && y >= 0 && k - 1 <= 9 && y <= 9)
                                {
                                    myMap[k - 1, y] = 3;
                                    myButton[k - 1, y].BackColor = Color.Brown;
                                }
                                if (k + 1 >= 0 && y >= 0 && k + 1 <= 9 && y <= 9)
                                {
                                    myMap[k + 1, y] = 3;
                                    myButton[k + 1, y].BackColor = Color.Brown;
                                }
                                if (k - 1 >= 0 && y + 1 >= 0 && k - 1 <= 9 && y + 1 <= 9)
                                {
                                    myMap[k - 1, y + 1] = 3;
                                    myButton[k - 1, y + 1].BackColor = Color.Brown;
                                }
                                if (k >= 0 && y + 1 >= 0 && k <= 9 && y + 1 <= 9)
                                {
                                    myMap[k, y + 1] = 3;
                                    myButton[k, y + 1].BackColor = Color.Brown;
                                }
                                if (k + 1 >= 0 && y + 1 >= 0 && k + 1 <= 9 && y + 1 <= 9)
                                {
                                    myMap[k + 1, y + 1] = 3;
                                    myButton[k + 1, y + 1].BackColor = Color.Brown;
                                }
                            }
                            else
                            {
                                if (k == x)
                                {

                                    if (k - 1 >= 0 && y - 1 >= 0 && k - 1 <= 9 && y - 1 <= 9)
                                    {
                                        myMap[k - 1, y - 1] = 3;
                                        myButton[k - 1, y - 1].BackColor = Color.Brown;
                                    }
                                    if (k - 1 >= 0 && y >= 0 && k - 1 <= 9 && y <= 9)
                                    {
                                        myMap[k - 1, y] = 3;
                                        myButton[k - 1, y].BackColor = Color.Brown;
                                    }
                                    if (k - 1 >= 0 && y + 1 >= 0 && k - 1 <= 9 && y + 1 <= 9)
                                    {
                                        myMap[k - 1, y + 1] = 3;
                                        myButton[k - 1, y + 1].BackColor = Color.Brown;
                                    }
                                }

                                if (k == x + DlinaK - 1)
                                {
                                    if (k + 1 >= 0 && y >= 0 && k + 1 <= 9 && y <= 9)
                                    {
                                        myMap[k + 1, y] = 3;
                                        myButton[k + 1, y].BackColor = Color.Brown;
                                    }
                                    if (k + 1 >= 0 && y - 1 >= 0 && k + 1 <= 9 && y - 1 <= 9)
                                    {
                                        myMap[k + 1, y - 1] = 3;
                                        myButton[k + 1, y - 1].BackColor = Color.Brown;
                                    }
                                    if (k + 1 >= 0 && y + 1 >= 0 && k + 1 <= 9 && y + 1 <= 9)
                                    {
                                        myMap[k + 1, y + 1] = 3;
                                        myButton[k + 1, y + 1].BackColor = Color.Brown;
                                    }
                                }

                                if (k >= x && k <= x + DlinaK - 1)
                                {
                                    if (k >= 0 && y - 1 >= 0 && k <= 9 && y - 1 <= 9)
                                    {
                                        myMap[k, y - 1] = 3;
                                        myButton[k, y - 1].BackColor = Color.Brown;
                                    }
                                    if (k >= 0 && y + 1 >= 0 && k <= 9 && y + 1 <= 9)
                                    {
                                        myMap[k, y + 1] = 3;
                                        myButton[k, y + 1].BackColor = Color.Brown;
                                    }
                                }
                            }
                        }
                        Lodki--;
                        if (Lodki <= 0)
                        {
                            break;
                        }
                    }
                    shtuk += 4;
                    DlinaK--;
                    nap = rnd.Next(1, 2);
                }
            }
            return myMap;
        }
        public bool Vistrel()
        {
            bool probitie = false;
            Random rnd = new Random();
            int popx;
            int popy;

            int x = rnd.Next(0, Form2.mapSize);
            int y = rnd.Next(0, Form2.mapSize);

            while (botButton[x, y].BackColor == Color.Red || botButton[x, y].BackColor == Color.Black)
            {
                x = rnd.Next(0, Form2.mapSize);
                y = rnd.Next(0, Form2.mapSize);
            }

            if (botMap[x, y] != 0)
            {
                probitie = true;
                botMap[x, y] = 0;
                botButton[x, y].BackColor = Color.Red;
                botButton[x, y].Text = "X";
                popx = x;
                popy = y;
                if ((popx >= 0 && popy - 1 >= 0 && popx <= 9 && popy - 1 <= 9 && (botMap[popx, popy - 1] != 0)) || (popx - 1 >= 0 && popy >= 0 && popx - 1 <= 9 && popy <= 9 && (botMap[popx - 1, popy] != 0)) || (popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9 && (botMap[popx + 1, popy] != 0)) || (popx >= 0 && popy + 1 >= 0 && popx <= 9 && popy + 1 <= 9 && (botMap[popx, popy + 1] != 0)))
                {
                    Vistrel3(popx, popy);
                    probitie = false;
                }
            }
            else
            {
                probitie = false;
                botButton[x, y].BackColor = Color.Black;
                botMap[x, y] = 0;
            }
            if (probitie)
            {
                //Vistrel();
            }
            return probitie;
        }
        public void Vistrel2(int popx, int popy)
        {
            Random rnd = new Random();
            int x = popx;
            int y = popy;
            bool pravilnoe = false;

            int nap = rnd.Next(1, 5);
            if (nap == 1)
            {
                bool shoot1 = false;
                if (popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9)
                {
                    popx = popx + 1;
                    popy = popy;
                    if (botButton[popx, popy].BackColor == Color.White || botButton[popx, popy].BackColor == Color.Blue)
                    {
                        if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                        {
                            botMap[popx, popy] = 0;
                            botButton[popx, popy].BackColor = Color.Red;
                            botButton[popx, popy].Text = "X";
                            shoot1 = true;
                            if (popx >= 0 && popy - 1 >= 0 && popx <= 9 && popy - 1 <= 9 || popx - 1 >= 0 && popy >= 0 && popx - 1 <= 9 && popy <= 9 || popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9 || popx >= 0 && popy + 1 >= 0 && popx <= 9 && popy + 1 <= 9)
                            {
                                if ((popy != 0 && botMap[popx, popy - 1] != 0) || (popx != 0 && botMap[popx - 1, popy] != 0) || (popx < 9 && botMap[popx + 1, popy] != 0) || (popy < 9 && botMap[popx, popy + 1] != 0))
                                {
                                    while (shoot1)
                                    {
                                        if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                                        {
                                            botMap[popx, popy] = 0;
                                            botButton[popx, popy].BackColor = Color.Red;
                                            botButton[popx, popy].Text = "X";
                                            shoot1 = true;
                                            popx = popx + 1;
                                        }
                                        else
                                        {
                                            shoot1 = false;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            botButton[popx, popy].BackColor = Color.Black;
                        }
                    }
                    else
                    {
                        nap = rnd.Next(1, 5);
                        Vistrel2(x, y);
                    }
                }
                else
                {
                    nap = rnd.Next(1, 5);
                    Vistrel2(x, y);
                }

            }
            if (nap == 2)
            {
                bool shoot2 = false;
                if (popx - 1 >= 0 && popy >= 0 && popx - 1 <= 9 && popy <= 9)
                {
                    popx = popx - 1;
                    popy = popy;
                    if (botButton[popx, popy].BackColor == Color.White || botButton[popx, popy].BackColor == Color.Blue)
                    {
                        if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                        {
                            botMap[popx, popy] = 0;
                            botButton[popx, popy].BackColor = Color.Red;
                            botButton[popx, popy].Text = "X";
                            shoot2 = true;
                            if (popx >= 0 && popy - 1 >= 0 && popx <= 9 && popy - 1 <= 9 || popx - 1 >= 0 && popy >= 0 && popx - 1 <= 9 && popy <= 9 || popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9 || popx >= 0 && popy + 1 >= 0 && popx <= 9 && popy + 1 <= 9)
                            {
                                if ((popy != 0 && botMap[popx, popy - 1] != 0) || (popx != 0 && botMap[popx - 1, popy] != 0) || (popx < 9 && botMap[popx + 1, popy] != 0) || (popy < 9 && botMap[popx, popy + 1] != 0))
                                {
                                    while (shoot2)
                                    {
                                        if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                                        {
                                            botMap[popx, popy] = 0;
                                            botButton[popx, popy].BackColor = Color.Red;
                                            botButton[popx, popy].Text = "X";
                                            shoot2 = true;
                                            popx = popx - 1;
                                        }
                                        else
                                        {
                                            shoot2 = false;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            botButton[popx, popy].BackColor = Color.Black;
                        }
                    }
                    else
                    {
                        nap = rnd.Next(1, 5);
                        Vistrel2(x, y);
                    }
                }
                else
                {
                    nap = rnd.Next(1, 5);
                    Vistrel2(x, y);
                }

            }
            if (nap == 3)
            {
                bool shoot3 = false;
                if (popx >= 0 && popy + 1 >= 0 && popx <= 9 && popy + 1 <= 9)
                {
                    popx = popx;
                    popy = popy + 1;
                    if(botButton[popx, popy].BackColor == Color.White || botButton[popx, popy].BackColor == Color.Blue)
                    {
                        if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                        {
                            botMap[popx, popy] = 0;
                            botButton[popx, popy].BackColor = Color.Red;
                            botButton[popx, popy].Text = "X";
                            shoot3 = true;
                            if (popx >= 0 && popy - 1 >= 0 && popx <= 9 && popy - 1 <= 9 || popx - 1 >= 0 && popy >= 0 && popx - 1 <= 9 && popy <= 9 || popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9 || popx >= 0 && popy + 1 >= 0 && popx <= 9 && popy + 1 <= 9)
                            {
                                if ((popy != 0 && botMap[popx, popy - 1] != 0) || (popx != 0 && botMap[popx - 1, popy] != 0) || (popx < 9 && botMap[popx + 1, popy] != 0) || (popy < 9 && botMap[popx, popy + 1] != 0))
                                {
                                    while (shoot3)
                                    {
                                        if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                                        {
                                            botMap[popx, popy] = 0;
                                            botButton[popx, popy].BackColor = Color.Red;
                                            botButton[popx, popy].Text = "X";
                                            shoot3 = true;
                                            popy = popy + 1;  
                                        }
                                        else
                                        {
                                            shoot3 = true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            botButton[popx, popy].BackColor = Color.Black;
                        }
                    }
                    else
                    {
                        nap = rnd.Next(1, 5);
                        Vistrel2(x, y);
                    }
                }
                else
                {
                    nap = rnd.Next(1, 5);
                    Vistrel2(x, y);
                }

            }
            if (nap == 4)
            {
                bool shoot4 = false;
                if (popx >= 0 && popy - 1 >= 0 && popx <= 9 && popy - 1 <= 9)
                {
                    popx = popx;
                    popy = popy - 1;
                    if (botButton[popx, popy].BackColor == Color.White || botButton[popx, popy].BackColor == Color.Blue)
                    {
                        if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                        {
                            botMap[popx, popy] = 0;
                            botButton[popx, popy].BackColor = Color.Red;
                            botButton[popx, popy].Text = "X";
                            shoot4 = true;
                            if (popx >= 0 && popy - 1 >= 0 && popx <= 9 && popy - 1 <= 9 || popx - 1 >= 0 && popy >= 0 && popx - 1 <= 9 && popy <= 9 || popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9 || popx >= 0 && popy + 1 >= 0 && popx <= 9 && popy + 1 <= 9)
                            {
                                if ((popy != 0 && botMap[popx, popy - 1] != 0) || (popx != 0 && botMap[popx - 1, popy] != 0) || (popx < 9 && botMap[popx + 1, popy] != 0) || (popy < 9 && botMap[popx, popy + 1] != 0))
                                {
                                    while (shoot4)
                                    {
                                        if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                                        {
                                            botMap[popx, popy] = 0;
                                            botButton[popx, popy].BackColor = Color.Red;
                                            botButton[popx, popy].Text = "X";
                                            shoot4 = true;
                                            popy = popy - 1;
                                        }
                                        else
                                        {
                                            shoot4 = false;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            botButton[popx, popy].BackColor = Color.Black;
                        }
                    }
                    else
                    {
                        nap = rnd.Next(1, 5);
                        Vistrel2(x, y);
                    }
                }
                else
                {
                    nap = rnd.Next(1, 5);
                    Vistrel2(x, y);
                }

            }
        }
        public void Vistrel3(int popx, int popy)
        {
            int x = popx;
            int y = popy;
            nap = rnd.Next(1, 5);
            if ((popx >= 0 && popy - 1 >= 0 && popx <= 9 && popy - 1 <= 9 && (botMap[popx, popy - 1] != 0)) || (popx - 1 >= 0 && popy >= 0 && popx - 1 <= 9 && popy <= 9 && (botMap[popx - 1, popy] != 0)) || (popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9 && (botMap[popx + 1, popy] != 0)) || (popx >= 0 && popy + 1 >= 0 && popx <= 9 && popy + 1 <= 9 && (botMap[popx, popy + 1] != 0)))
            {
                if (nap == 1)
                {
                    bool shoot1;
                    if ((popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9) && (botButton[popx + 1, popy].BackColor == Color.White || botButton[popx + 1, popy].BackColor == Color.Blue))
                    {
                        popx = popx + 1;
                        popy = popy;
                        shoot1 = true;
                        while (shoot1 && popx >= 0 && popy >= 0 && popx <= 9 && popy <= 9)
                        {
                            if (popx >= 0 && popy >= 0 && popx <= 9 && popy <= 9)
                            {
                                if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                                {
                                    botMap[popx, popy] = 0;
                                    botButton[popx, popy].BackColor = Color.Red;
                                    botButton[popx, popy].Text = "X";
                                    shoot1 = true;
                                    popx = popx + 1;
                                }
                                else
                                {
                                    botButton[popx, popy].BackColor = Color.Black;
                                    botMap[popx, popy] = 0;
                                    shoot1 = false;
                                }
                            }
                            else
                            {
                                shoot1 = false;
                            }
                        }
                    }
                    else
                    {
                        if ((popx >= 0 && popy - 1 >= 0 && popx <= 9 && popy - 1 <= 9 && (botMap[popx, popy - 1] != 0)) || (popx - 1 >= 0 && popy >= 0 && popx - 1 <= 9 && popy <= 9 && (botMap[popx - 1, popy] != 0)) || (popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9 && (botMap[popx + 1, popy] != 0)) || (popx >= 0 && popy + 1 >= 0 && popx <= 9 && popy + 1 <= 9 && (botMap[popx, popy + 1] != 0)))
                        {
                            Vistrel3(x, y);
                        }
                        shoot1 = false;
                    }

                }

                if (nap == 2)
                {
                    bool shoot2;
                    if ((popx - 1 >= 0 && popy >= 0 && popx - 1 <= 9 && popy <= 9) && (botButton[popx - 1, popy].BackColor == Color.White || botButton[popx - 1, popy].BackColor == Color.Blue))
                    {
                        popx = popx - 1;
                        popy = popy;
                        shoot2 = true;
                        while (shoot2 && popx >= 0 && popy >= 0 && popx <= 9 && popy <= 9)
                        {
                            if (popx >= 0 && popy >= 0 && popx <= 9 && popy <= 9)
                            {
                                if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                                {
                                    botMap[popx, popy] = 0;
                                    botButton[popx, popy].BackColor = Color.Red;
                                    botButton[popx, popy].Text = "X";
                                    shoot2 = true;
                                    popx = popx - 1;
                                }
                                else
                                {
                                    botButton[popx, popy].BackColor = Color.Black;
                                    botMap[popx, popy] = 0;
                                    shoot2 = false;
                                }
                            }
                            else
                            {
                                shoot2 = false;
                            }
                        }
                    }
                    else
                    {
                        if ((popx >= 0 && popy - 1 >= 0 && popx <= 9 && popy - 1 <= 9 && (botMap[popx, popy - 1] != 0)) || (popx - 1 >= 0 && popy >= 0 && popx - 1 <= 9 && popy <= 9 && (botMap[popx - 1, popy] != 0)) || (popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9 && (botMap[popx + 1, popy] != 0)) || (popx >= 0 && popy + 1 >= 0 && popx <= 9 && popy + 1 <= 9 && (botMap[popx, popy + 1] != 0)))
                        {
                            Vistrel3(x, y);
                        }
                        shoot2 = false;
                    }

                }

                if (nap == 3)
                {
                    bool shoot3;
                    if ((popx >= 0 && popy + 1 >= 0 && popx <= 9 && popy + 1 <= 9) && (botButton[popx, popy + 1].BackColor == Color.White || botButton[popx, popy + 1].BackColor == Color.Blue))
                    {
                        popx = popx;
                        popy = popy + 1;
                        shoot3 = true;
                        while (shoot3 && popx >= 0 && popy >= 0 && popx <= 9 && popy <= 9)
                        {
                            if (popx >= 0 && popy >= 0 && popx <= 9 && popy <= 9)
                            {
                                if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                                {
                                    botMap[popx, popy] = 0;
                                    botButton[popx, popy].BackColor = Color.Red;
                                    botButton[popx, popy].Text = "X";
                                    shoot3 = true;
                                    popy = popy + 1;
                                }
                                else
                                {
                                    botButton[popx, popy].BackColor = Color.Black;
                                    botMap[popx, popy] = 0;
                                    shoot3 = false;
                                }
                            }
                            else
                            {
                                shoot3 = false;
                            }
                        }
                    }
                    else
                    {
                        if ((popx >= 0 && popy - 1 >= 0 && popx <= 9 && popy - 1 <= 9 && (botMap[popx, popy - 1] != 0)) || (popx - 1 >= 0 && popy >= 0 && popx - 1 <= 9 && popy <= 9 && (botMap[popx - 1, popy] != 0)) || (popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9 && (botMap[popx + 1, popy] != 0)) || (popx >= 0 && popy + 1 >= 0 && popx <= 9 && popy + 1 <= 9 && (botMap[popx, popy + 1] != 0)))
                        {
                            Vistrel3(x, y);
                        }
                        shoot3 = false;
                    }

                }

                if (nap == 4)
                {
                    bool shoot4;
                    if ((popx >= 0 && popy - 1 >= 0 && popx <= 9 && popy - 1 <= 9) && (botButton[popx, popy - 1].BackColor == Color.White || botButton[popx, popy - 1].BackColor == Color.Blue))
                    {
                        popx = popx;
                        popy = popy - 1;
                        shoot4 = true;
                        while (shoot4 && popx >= 0 && popy >= 0 && popx <= 9 && popy <= 9)
                        {
                            if (popx >= 0 && popy >= 0 && popx <= 9 && popy <= 9)
                            {
                                if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                                {
                                    botMap[popx, popy] = 0;
                                    botButton[popx, popy].BackColor = Color.Red;
                                    botButton[popx, popy].Text = "X";
                                    shoot4 = true;
                                    popy = popy - 1;
                                }
                                else
                                {
                                    botButton[popx, popy].BackColor = Color.Black;
                                    botMap[popx, popy] = 0;
                                    shoot4 = false;
                                }
                            }
                            else
                            {
                                shoot4 = false;
                            }
                        }
                    }
                    else
                    {
                        if ((popx >= 0 && popy - 1 >= 0 && popx <= 9 && popy - 1 <= 9 && (botMap[popx, popy - 1] != 0)) || (popx - 1 >= 0 && popy >= 0 && popx - 1 <= 9 && popy <= 9 && (botMap[popx - 1, popy] != 0)) || (popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9 && (botMap[popx + 1, popy] != 0)) || (popx >= 0 && popy + 1 >= 0 && popx <= 9 && popy + 1 <= 9 && (botMap[popx, popy + 1] != 0)))
                        {
                            Vistrel3(x, y);
                        }
                        shoot4 = false;
                    }

                }
            }
        }
        public bool Vistrel4()
        {
            bool probitie = false;
            bool probitie2 = false;
            Random rnd = new Random();
            int popx;
            int popy;
            int nap = rnd.Next(1, 5);

            int x = rnd.Next(0, Form2.mapSize);
            int y = rnd.Next(0, Form2.mapSize);

            while (botButton[x, y].BackColor == Color.Red || botButton[x, y].BackColor == Color.Black)
            {
                x = rnd.Next(0, Form2.mapSize);
                y = rnd.Next(0, Form2.mapSize);
            }
            if (botMap[x, y] != 0)
            {
                probitie = true;
                botMap[x, y] = 0;
                botButton[x, y].BackColor = Color.Red;
                botButton[x, y].Text = "X";
                popx = x;
                popy = y;
                if ((popx + 1 >= 0 && popy >= 0 && popx + 1 <= 9 && popy <= 9) && (botButton[popx + 1, popy].BackColor == Color.White || botButton[popx + 1, popy].BackColor == Color.Blue))
                {
                    popx = popx + 1;
                    popy = popy;
                    bool shoot1 = true;
                    while (shoot1)
                    {
                        if (popx >= 0 && popy >= 0 && popx <= 9 && popy <= 9)
                        {
                            if (botMap[popx, popy] != 0 && botButton[popx, popy].BackColor == Color.Blue)
                            {
                                botMap[popx, popy] = 0;
                                botButton[popx, popy].BackColor = Color.Red;
                                botButton[popx, popy].Text = "X";
                                shoot1 = true;
                                popx = popx + 1;
                            }
                            else
                            {
                                shoot1 = false;
                                botButton[popx, popy].BackColor = Color.Black;
                                botMap[popx, popy] = 0;
                            }
                        }
                        else
                        {
                            shoot1 = false;
                        }
                    }
                }
                else
                {
                    Vistrel3(x, y);
                }
            }
            else
            {
                probitie = false;
                botButton[x, y].BackColor = Color.Black;
            }
            return probitie;
        }
    }

}
