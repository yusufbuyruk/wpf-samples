using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DragDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isDragging = false;
        private Point _mouseStart;
        private Point _ellipseStart;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _mouseStart = e.GetPosition(canvas);

            var ellipse = (Ellipse)sender;
            _ellipseStart = new Point(Canvas.GetLeft(ellipse), Canvas.GetTop(ellipse));
            ellipse.CaptureMouse();

            var dropShadowEffect = (DropShadowEffect)ellipse.Effect;
            dropShadowEffect.ShadowDepth = 3;
            dropShadowEffect.BlurRadius = 3;
            dropShadowEffect.Opacity = .6;
        }

        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging)
                return;

            Point mouseEnd = e.GetPosition(canvas);
            Point ellipseEnd = _ellipseStart + (mouseEnd - _mouseStart);


            var ellipse = (Ellipse)sender;

            if (ellipseEnd.X < 0)
                ellipseEnd.X = 0;

            if (ellipseEnd.X > canvas.Width - ellipse.Width)
                ellipseEnd.X = canvas.Width - ellipse.Width;

            if (ellipseEnd.Y < 0)
                ellipseEnd.Y = 0;

            if (ellipseEnd.Y > canvas.Height - ellipse.Height)
                ellipseEnd.Y = canvas.Height - ellipse.Height;

            Canvas.SetLeft(ellipse, ellipseEnd.X);
            Canvas.SetTop(ellipse, ellipseEnd.Y);

            Point ellipseCenter = new(ellipseEnd.X + ellipse.Width/2, ellipseEnd.Y + ellipse.Height/2);
            
            ellipse.Tag = ellipseCenter;

            //if (path.Data is PathGeometry pathGeometry)
            //{
            //    PathFigure pathFigure = pathGeometry.Figures[0];

            //    if (pathFigure.Segments[0] is BezierSegment bezierSegment)
            //    {
            //        if (sender == c0)
            //            pathFigure.StartPoint = ellipseCenter;

            //        if (sender == c1)
            //            bezierSegment.Point1 = ellipseCenter;

            //        if (sender == c2)
            //            bezierSegment.Point2 = ellipseCenter;

            //        if (sender == c3)
            //            bezierSegment.Point3 = ellipseCenter;
            //    }
            //}
        }

        private void Ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;

            var ellipse = (Ellipse)sender;
            ellipse.ReleaseMouseCapture();

            var dropShadowEffect = (DropShadowEffect)ellipse.Effect;
            dropShadowEffect.ShadowDepth = 2;
            dropShadowEffect.BlurRadius = 2;
            dropShadowEffect.Opacity = .8;
        }
    }
}