﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace JocRobot
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        List<Robot> capRobot;
        List<Tresor> tresor;
        Random random = new Random();
        double width = 100;
        double height = 100;

        private DireccioRobot direccio;
        int numMovs = 0;
        int count = 0;

        public DireccioRobot Direccio1 { get => direccio; set => direccio = value; }

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            capRobot = new List<Robot>();
            tresor = new List<Tresor>();
            capRobot.Add(new Robot(width, height));
            tresor.Add(new Tresor(random.Next(0, 37) * 10, random.Next(0, 35) * 10));
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            

            timer.Tick += Timer_Tick;
        }

        public void afeguirTresor()
        {
            tresor[0].posicioTresor();
            pantallaJoc.Children.Insert(0, tresor[0].tresor);

        }

        public void afeguirRobot()
        {
            foreach (Robot robot in capRobot)
            {
                robot.posicioRobot();
                pantallaJoc.Children.Add(robot.robot);
            }
        }

        public void moure()
        {
            int randomMov = random.Next(0, 4);//Ens dira en quina direcció es coloca el robot.
            int randomMov2 = random.Next(0, 5);//Ens dira si es moura o no el robot.

            if (randomMov == 0 || randomMov == 1)
            {
                Thread.Sleep(500);
                if (randomMov2 == 0 || randomMov2 == 1)
                {
                    direccio = DireccioRobot.Up;
                    height -= 20;
                    numMovs++;

                }
                else if (randomMov2 == 2)
                {
                    direccio = DireccioRobot.Left;
                    width -= 20;
                    numMovs++;
                }
                else if (randomMov2 == 3)
                {
                    direccio = DireccioRobot.Right;
                    width += 20;
                    numMovs++;
                }
                else if (randomMov2 == 4)
                {
                    direccio = DireccioRobot.Down;
                    height += 20;
                    numMovs++;
                }
                Thread.Sleep(500);
            }

            else if (randomMov == 2)
            {
                direccio = DireccioRobot.Left;
            }
            else if (randomMov == 3)
            {
                direccio = DireccioRobot.Right;
            }

            //Si el que hi ha a la pantalla es una ellipse l'elimina per retorna a "Pintar" la ellipse.
            for (int i = 0; i < pantallaJoc.Children.Count; i++)
            {
                if (pantallaJoc.Children[i] is Ellipse)
                    count++;
            }
            pantallaJoc.Children.RemoveRange(1, count);
            count = 0;
            afeguirRobot();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Cridem el mètode moure pq el robot es mogui.
            moure();

            //Nou robot per imprimir al canvas.
            capRobot[0] = new Robot(width, height);

            //Si el robot colisiona amb el tresor el joc acaba.
            if (capRobot[0].x == tresor[0].x && capRobot[0].y == tresor[0].y)
            {
                txtNumMovs.Text = "Total de moviments realitzats: " + numMovs;
                Thread.Sleep(2000);
                this.Close();
            }
        }

        //Segons la direccio es moura cap un costat o l'altre.
        public enum DireccioRobot
        {
            Up,
            Down,
            Right,
            Left
        }

        private void btnInicaJoc_Click(object sender, RoutedEventArgs e)
        {
            afeguirRobot();
            afeguirTresor();
            timer.Start();
        }
    }
}
