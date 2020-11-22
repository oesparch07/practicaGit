using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private Direccio direccio;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            capRobot = new List<Robot>();
            tresor = new List<Tresor>();
            capRobot.Add(new Robot(width, height));
            tresor.Add(new Tresor(random.Next(0, 37) * 10, random.Next(0, 35) * 10));
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            
            direccio = Direccio.Down;
            timer.Tick += Timer_Tick;
        }

        public void afeguirTresor()
        {
            tresor[0].posicioTresor();
            pantallaJoc.Children.Insert(0, tresor[0].tresor);

        }

        public void afeguirRobot()
        {
            capRobot[0].posicioRobot();
            pantallaJoc.Children.Insert(0, capRobot[0].robot);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
            if (direccio == Direccio.Right)
            {
                capRobot[0].x += 10;
            }
            else if (direccio == Direccio.Left)
            {
                capRobot[0].x -= 10;
            }
            else if (direccio == Direccio.Up)
            {
                capRobot[0].y -= 10;
            }
            else if (direccio == Direccio.Down)
            {
                capRobot[0].y += 10;
            }

            capRobot[0] = new Robot(width, height);
            //Si el robot colisiona amb el tresor el joc acaba.
            if (capRobot[0].x == tresor[0].x && capRobot[0].y == tresor[0].y)
            {
                this.Close();
            }
        }

        public enum Direccio
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
