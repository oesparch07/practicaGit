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
    class Robot
    {
        public double x, y;
        public Ellipse robot = new Ellipse();
        public Robot(double x , double y)
        {
            this.x = x;
            this.y = y;
        }
        public void posicioRobot()
        {
            robot.Width = robot.Height = 20;
            robot.Fill = Brushes.Gray;
            Canvas.SetLeft(robot, x);
            Canvas.SetTop(robot, y);

        }
    }
}
