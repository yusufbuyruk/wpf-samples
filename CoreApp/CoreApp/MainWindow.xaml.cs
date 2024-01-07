using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoreApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isDrawing = false;
        private Line _currentLine;

        private bool _isDragging = false;
        private Point _originalMousePosition;
        private Point _originalEllipsePosition;


        public MainWindow()
        {
            InitializeComponent();
        }


        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _originalMousePosition = e.GetPosition(this);

            var ellipse = (Ellipse)sender;
            _originalEllipsePosition = new Point(Canvas.GetLeft(ellipse), Canvas.GetTop(ellipse));
            ellipse.CaptureMouse();
        }

        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging)
                return;

            var ellipse = (Ellipse)sender;

            Point currentPosition = e.GetPosition(this);

            double deltaX = currentPosition.X - _originalMousePosition.X;
            double deltaY = currentPosition.Y - _originalMousePosition.Y;

            double newLeft = _originalEllipsePosition.X + deltaX;
            double newTop = _originalEllipsePosition.Y + deltaY;

            Canvas.SetLeft(ellipse, newLeft);
            Canvas.SetTop(ellipse, newTop);
        }

        private void Ellipse_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;

            var ellipse = (Ellipse)sender;
            ellipse.ReleaseMouseCapture();
        }




        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            log.Text = "Mouse Down";

            _isDrawing = true;

            _currentLine = new Line
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                X1 = e.GetPosition(canvas).X,
                Y1 = e.GetPosition(canvas).Y,
                X2 = e.GetPosition(canvas).X,
                Y2 = e.GetPosition(canvas).Y,
            };

            canvas.Children.Add(_currentLine);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            log.Text = "Mouse Move";

            if (_isDrawing && _currentLine != null)
            {
                _currentLine.X2 = e.GetPosition(canvas).X;
                _currentLine.Y2 = e.GetPosition(canvas).Y;
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            log.Text = "Mouse Up";

            _isDrawing = false;
            _currentLine = null;
        }
    }
}