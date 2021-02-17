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
using Xceed.Wpf.Toolkit;

namespace Экзамен
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point p;
        int maxz;
        Size s;
        public Point A;
        
        public MainWindow()
        {
            InitializeComponent();
            A_X.Maximum = (int)Container.Width;
            A_X.Minimum = 0;
            A_Y.Maximum = (int)Container.Height;
            A_Y.Minimum = 0;
            Height.Minimum = 0;
            Width.Minimum = 0;
            Length.Minimum = 0;
            Height.Maximum = (int)Container.Height;
            Width.Maximum = (int)Container.Width; ;
            Length.Maximum = (int)Container.Height;
            Thickness.Maximum = 10;
            Thickness.Minimum = 1;
            buttoncreate.Focus();
            A = new Point(100, 100);
            
        }       

        private void clear_click(object sender, RoutedEventArgs e)
        {
            Container.Children.Clear();
        }
        private void Create_click_but(object sender, RoutedEventArgs e)
        {
            if (!(A_X.Text == null ^ A_Y.Text == null ^ Height.Text == null ^ Length.Text == null ^ Width.Text == null ^ Thickness.Text == null))
            {
                try
                {
                    var converter = new System.Windows.Media.BrushConverter();
                    Container.Children.Clear();

                    if (Convert.ToBoolean(Checke.IsChecked))
                    {
                        Parallepiped newf = new Parallepiped(A, Convert.ToInt32(Height.Text), Convert.ToInt32(Length.Text), Convert.ToInt32(Width.Text), Container, (Brush)converter.ConvertFromString(colorlines.SelectedColorText), Convert.ToInt32(Thickness.Text), (Brush)converter.ConvertFromString(colorlines.SelectedColorText), Convert.ToBoolean(Checke.IsChecked));
                    }
                    else
                    {
                        Parallepiped newf = new Parallepiped(A, Convert.ToInt32(Height.Text), Convert.ToInt32(Length.Text), Convert.ToInt32(Width.Text), Container, (Brush)converter.ConvertFromString(colorlines.SelectedColorText), Convert.ToInt32(Thickness.Text), (Brush)converter.ConvertFromString(colorlines2.SelectedColorText));
                    }
                }
                catch
                {
                    
                }
            }
            }
        private void Create_click(object sender, RoutedEventArgs e)
        {
            if (!(A_X.Text == null & A_Y.Text == null & Height.Text == null & Length.Text == null & Width.Text == null & Thickness.Text == null))
            {
                try
                {
                    var converter = new System.Windows.Media.BrushConverter();
                Container.Children.Clear();


                if (Convert.ToBoolean(Checke.IsChecked))
                {
                    Parallepiped newf = new Parallepiped(A, Convert.ToInt32(Height.Text), Convert.ToInt32(Length.Text), Convert.ToInt32(Width.Text), Container, (Brush)converter.ConvertFromString(colorlines.SelectedColorText), Convert.ToInt32(Thickness.Text), (Brush)converter.ConvertFromString(colorlines.SelectedColorText), Convert.ToBoolean(Checke.IsChecked));
                }
                else
                {
                    Parallepiped newf = new Parallepiped(A, Convert.ToInt32(Height.Text), Convert.ToInt32(Length.Text), Convert.ToInt32(Width.Text), Container, (Brush)converter.ConvertFromString(colorlines.SelectedColorText), Convert.ToInt32(Thickness.Text), (Brush)converter.ConvertFromString(colorlines2.SelectedColorText));
                }
                A_X.Text = Convert.ToString(A.X);
                A_Y.Text = Convert.ToString(A.Y);
                }
                catch
                {

                }
            }
        }
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            A = Mouse.GetPosition(this);
            Create_click(sender, e);
        }

        private void Double_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                
                e.Handled = true;
               
            }
        }
        private void KeyEvents(object sender, KeyEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            switch (e.Key)
            {
                case Key.Up:
                    A.Y--;
                    Create_click(sender,e); break;
                case Key.Down:
                    A.Y++;
                    Create_click(sender, e); break; 
                case Key.Left:
                    A.X--;
                    Create_click(sender, e); break; 
                case Key.Right:
                    A.X++;
                    Create_click(sender, e); break; 
            }
        }
        private void canvas1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;

            if (e.Source == Container)
            {
                Title = "Mouse";
                return;
            }

            var a = e.Source as FrameworkElement;
            Point q = e.GetPosition(a);

            Canvas.SetZIndex(a, ++maxz);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Canvas.SetLeft(a, Math.Max(0, Canvas.GetLeft(a) + q.X - p.X));
                Canvas.SetTop(a, Math.Max(0, Canvas.GetTop(a) + q.Y - p.Y));
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                a.Width = Math.Max(20, s.Width + q.X - p.X);
                a.Height = Math.Max(20, s.Height + q.Y - p.Y);
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker();
            var converter = new System.Windows.Media.BrushConverter();
            A = new Point(50, 75);
            Height.Text = Convert.ToString(100);
            Width.Text = Convert.ToString(50);
            Length.Text = Convert.ToString(150);
            Container.Children.Clear();



                Parallepiped newf = new Parallepiped(A, Convert.ToInt32(Height.Text), Convert.ToInt32(Length.Text), Convert.ToInt32(Width.Text), Container, (Brush)converter.ConvertFromString("#FF0000"), Convert.ToInt32(Thickness.Text), (Brush)converter.ConvertFromString("#8B0000"), true);
            

            
            A_X.Text = Convert.ToString(A.X);
            A_Y.Text = Convert.ToString(A.Y);


        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker();
            var converter = new System.Windows.Media.BrushConverter();
            A = new Point(100, 150);
            Height.Text = Convert.ToString(50);
            Width.Text = Convert.ToString(75);
            Length.Text = Convert.ToString(30);
            
            Container.Children.Clear();

                Parallepiped newf = new Parallepiped(A, Convert.ToInt32(Height.Text), Convert.ToInt32(Length.Text), Convert.ToInt32(Width.Text), Container, (Brush)converter.ConvertFromString("#FF0000"), Convert.ToInt32(Thickness.Text), (Brush)converter.ConvertFromString("#8B0000"),2);
            
            A_X.Text = Convert.ToString(A.X);
            A_Y.Text = Convert.ToString(A.Y);
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            ColorPicker colorPicker = new ColorPicker();
            var converter = new System.Windows.Media.BrushConverter();
            A = new Point(500, 500);
            Height.Text = Convert.ToString(100);
            Width.Text = Convert.ToString(50);
            Length.Text = Convert.ToString(150);
            Container.Children.Clear();



            Parallepiped newf = new Parallepiped(A, Convert.ToInt32(Height.Text), Convert.ToInt32(Length.Text), Convert.ToInt32(Width.Text), Container, (Brush)converter.ConvertFromString("#FF0000"), Convert.ToInt32(Thickness.Text), (Brush)converter.ConvertFromString("#8B0000"), Convert.ToBoolean(Checke.IsChecked));



            A_X.Text = Convert.ToString(A.X);
            A_Y.Text = Convert.ToString(A.Y);
        }
    }
}
