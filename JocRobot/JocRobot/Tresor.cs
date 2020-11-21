using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace JocRobot
{
    class Tresor
    {
        public double x, y;
        public Rectangle tresor = new Rectangle();
        public Tresor(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void posicioTresor()
        {
            tresor.Width = tresor.Height = 20;
            tresor.Fill = Brushes.Gold;
            Canvas.SetLeft(tresor, x);
            Canvas.SetTop(tresor, y);

        }

    }
}
