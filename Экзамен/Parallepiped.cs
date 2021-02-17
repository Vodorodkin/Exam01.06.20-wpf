using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Экзамен
{

   public class Parallepiped
    {
        Point A;
        Point A1;
        Point B;
        Point B1;
        Point C;
        Point C1;
        Point D;
        Point D1;

        public Parallepiped(Point A, int heigth, int length, int width, Canvas canvas, Brush color1, int Thickness, Brush color2,bool checke,int checkedtest=0)
        {
            double x = A.X;
            double y = A.Y;
            this.A = A;
            B.X = x + Math.Cos(Math.PI / 4) + width;
            B.Y = y + Math.Sin(Math.PI / 4) - width;
            C.X = x + length + Math.Cos(Math.PI / 4) + width;
            C.Y = y + Math.Sin(Math.PI / 4) - width;
            D.X = x + length;
            D.Y = y;
            A1.X = x;
            A1.Y = y + heigth;
            B1.X = x + Math.Cos(Math.PI / 4) + width;
            B1.Y = y + heigth + Math.Sin(Math.PI / 4) - width;
            C1.X = x + length + Math.Cos(Math.PI / 4) + width;
            C1.Y = y + heigth + Math.Sin(Math.PI / 4) - width;
            D1.X = x + length;
            D1.Y = y + heigth;

            Label lable1 = new Label();
            lable1.Content = "Фигура выходит за пределы контейнера";

            if (Check(canvas, A) & Check(canvas, B) & Check(canvas, C) & Check(canvas, D) & Check(canvas, A1) & Check(canvas, B1) & Check(canvas, C1) & Check(canvas, D1))
            {
                if (checkedtest==2)
                {
                     if (!checke) create2_random(canvas, color2);
                    create(canvas, color1, Thickness, checke);
                }
                else if (!checke) create2(canvas, color2);
                create(canvas, color1, Thickness,checke);                
            }
            else
            {
                canvas.Children.Add(lable1);
            }
            
        }
        public Parallepiped(Point A, int heigth, int length, int width, Canvas canvas, Brush color1, int Thickness, Brush color2,int checkedtest = 0)
        {
            double x = A.X;
            double y = A.Y;
            this.A = A;
            B.X = x + Math.Cos(Math.PI / 4) + width;
            B.Y = y + Math.Sin(Math.PI / 4) - width;
            C.X = x + length + Math.Cos(Math.PI / 4) + width;
            C.Y = y + Math.Sin(Math.PI / 4) - width;
            D.X = x + length;
            D.Y = y;
            A1.X = x;
            A1.Y = y + heigth;
            C1.X = x + length + Math.Cos(Math.PI / 4) + width;
            C1.Y = y + heigth + Math.Sin(Math.PI / 4) - width;
            D1.X = x + length;
            D1.Y = y + heigth;

            Label lable1 = new Label();
            lable1.Content = "Фигура выходит за пределы контейнера";

            if (Check(canvas, A) & Check(canvas, B) & Check(canvas, C) & Check(canvas, D) & Check(canvas, A1) & Check(canvas, B1) & Check(canvas, C1) & Check(canvas, D1))
            {
                if (checkedtest == 2)
                {
                    if (!false) create2_random(canvas, color2);
                    create(canvas, color1, Thickness, false);
                }
                 else   if (!false) create2(canvas, color2);
                create(canvas, color1, Thickness, false);
            }
            else
            {
                canvas.Children.Add(lable1);
            }

        }
        void create (Canvas canvas, Brush color1,int Thickness,bool checke)
        {
            PointCollection myPointCollection = new PointCollection();
            PointCollection myPointCollection2 = new PointCollection();
            Polyline myPolyline = new Polyline();
            Polyline myPolyline2 = new Polyline();
            myPointCollection.Add(A);
            myPointCollection.Add(A1);
            myPointCollection.Add(D1);
            myPointCollection.Add(D);
            myPointCollection.Add(A);
            myPointCollection.Add(B);
            myPointCollection.Add(C);
            myPointCollection.Add(D);
            myPointCollection.Add(D1);
            myPointCollection.Add(C1);
            myPointCollection.Add(C);
            myPolyline.Points = myPointCollection;
            myPolyline.Stroke = color1;
            myPolyline.StrokeThickness = Thickness;           
            canvas.Children.Add(myPolyline);
            if (checke)
                {
                myPointCollection2.Add(B);
                myPointCollection2.Add(B1);
                myPointCollection2.Add(A1);
                myPointCollection2.Add(B1);
                myPointCollection2.Add(C1);
                myPolyline2.Points = myPointCollection2;
                myPolyline2.Stroke = color1;
                myPolyline2.StrokeThickness = Thickness;
                myPolyline2.StrokeDashArray.Add(2);
                canvas.Children.Add(myPolyline2);
            }
        }
        void create2(Canvas canvas, Brush color2)
        {
            Polygon polygon = new Polygon();
            Polygon polygon2 = new Polygon();
            Polygon polygon3 = new Polygon();
            PointCollection points1 = new PointCollection() {A,D,D1,A1};
            PointCollection points2 = new PointCollection() { A, B, C, D };
            PointCollection points3 = new PointCollection() { D,C,C1,D1 };
            polygon.Points = points1;
            polygon.Fill = color2;
            polygon2.Points = points2;
            polygon2.Fill = color2;
            polygon3.Points = points3;
            polygon3.Fill = color2;
            canvas.Children.Add(polygon);
            canvas.Children.Add(polygon2);
            canvas.Children.Add(polygon3);
        }
        void create2_random(Canvas canvas, Brush color2)
        {
            Random r = new Random();
            var converter = new System.Windows.Media.BrushConverter();
            Polygon polygon = new Polygon();
            Polygon polygon2 = new Polygon();
            Polygon polygon3 = new Polygon();
            PointCollection points1 = new PointCollection() { A, D, D1, A1 };
            PointCollection points2 = new PointCollection() { A, B, C, D };
            PointCollection points3 = new PointCollection() { D, C, C1, D1 };
            polygon.Points = points1;
            polygon.Fill = (Brush)converter.ConvertFromString($"#{r.Next(0, 9)}{r.Next(0, 9)}{r.Next(0, 9)}{r.Next(0, 9)}{r.Next(0, 9)}{r.Next(0, 9)}");
            polygon2.Points = points2;
            polygon2.Fill = (Brush)converter.ConvertFromString($"#{r.Next(0, 9)}{r.Next(0, 9)}{r.Next(0, 9)}{r.Next(0, 9)}{r.Next(0, 9)}{r.Next(0, 9)}");
            polygon3.Points = points3;
            polygon3.Fill = (Brush)converter.ConvertFromString($"#{r.Next(0, 9)}{r.Next(0, 9)}{r.Next(0, 9)}{r.Next(0, 9)}{r.Next(0, 9)}{r.Next(0, 9)}");
            canvas.Children.Add(polygon);
            canvas.Children.Add(polygon2);
            canvas.Children.Add(polygon3);
        }
        private bool Check(Canvas container, Point A)
        {
            return (A.X >= 0 & A.X < container.Width & A.Y >= 0 & A.Y < container.Height);
        }

    }
}
