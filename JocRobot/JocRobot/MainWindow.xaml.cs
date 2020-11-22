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

        int direccio = 0;
        int left = 4;
        int right = 6;
        int up = 8;
        int down = 2;

        int count = 0;

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

        private void Timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void btnInicaJoc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
